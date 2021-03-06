﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using UrlFileDown.Tool;
namespace UrlFileDown
{

    public class UrlDownFile
    {
        /// <summary>
        /// 下载文件保存的地方
        /// </summary>
        public static string FileSavePath { get; set; }
        public event Action<string> DownEvent;
        private List<Options> options;
        public UrlDownFile(List<Options> _options)
        {
            options = _options;
            if (string.IsNullOrWhiteSpace(FileSavePath))
            {
                throw new AggregateException("保存路径不正确");
            }
        }

        public void DownEventTag(string content)
        {
            var tempevent = DownEvent;
            if (tempevent != null)
                tempevent(content);
        }

        public void GetFiles()
        {
            if (options != null && options.Count > 0)
            {
                foreach (var o in options)
                {
                    DownEventTag(string.Format("开始下载:{0}", o.Title));
                    DownLogic(o);
                    Thread.Sleep(1000 * 5);
                }
            }
        }
        private void DownLogic(Options model)
        {
            try
            {
                Encoding _encoding = !string.IsNullOrWhiteSpace(model.Encoding) ? Encoding.GetEncoding(model.Encoding) : Encoding.Default;
                Regex _mainListReg = new Regex(model.DownFileReg, RegexOptions.IgnoreCase);
                Regex _detailReg = model.IsDetail ? new Regex(model.DetailReg, RegexOptions.IgnoreCase) : null;
                Regex _nextpageReg = model.IsNextPage ? new Regex(model.NextPageReg, RegexOptions.IgnoreCase) : null;
                var mainhtml = GetHtml(model.MainUrl, _encoding);
                mainhtml.ContinueWith(m =>
                {

                    if (_mainListReg.IsMatch(m.Result))
                    {
                        var _mainmatch = _mainListReg.Matches(m.Result);
                        foreach (Match mc in _mainmatch)
                        {
                            var detailurl = mc.Groups["listurl"].Value.ReplaceUrlHtmlTag();
                            var listtitle = mc.Groups["title"].Value;
                            if (model.IsDetail) //如果捕获的是详细页面
                            {
                                bool iswww = detailurl.Contains("www.");
                                if (!iswww)
                                    detailurl = model.Host + detailurl;
                                var detailhtml = GetHtml(detailurl, _encoding);
                                detailhtml.ContinueWith(d =>
                                {
                                    try
                                    {
                                        var detail = d.Result;

                                        if (_detailReg.IsMatch(detail)) //详细也内容
                                        {
                                            var _detailmatch = _detailReg.Matches(detail);//详细页面匹配的内容
                                            foreach (Match dmc in _detailmatch)
                                            {
                                                var url = dmc.Groups["url"].Value;
                                                var title = dmc.Groups["title"].Value;
                                                LoadHref(url, _encoding, model, title);//捕获列表页资源

                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        DownEventTag(string.Format("详情页异常:{0}", ex.Message + ex.InnerException+detailurl));
                                    }
                                });
                            }
                            else
                            {
                                LoadHref(detailurl, _encoding, model, listtitle);//捕获列表页资源
                            }
                        }
                    }
                    if (model.IsNextPage)
                    {
                        if (_nextpageReg.IsMatch(m.Result))
                        {
                            var nexturl = _nextpageReg.Match(m.Result).Groups["nextpage"].Value;
                            DownEventTag(nexturl);
                            bool iswww = nexturl.Contains("www.");
                            if (!iswww)
                                model.MainUrl = model.Host + nexturl;
                            else
                                model.MainUrl = nexturl;
                            DownLogic(model);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                DownEventTag(string.Format("异常:{0}", ex.Message + ex.InnerException));
            }
        }

        private void LoadHref(string url, Encoding encoding, Options option, string title)
        {
            switch (option.FileType)
            {
                case OptionFileType.File:
                    DownFiles(url, encoding, option, title);
                    break;
                case OptionFileType.Text:
                    DownTxt(url, encoding, option);
                    break;

            }
        }
        /// <summary>
        /// 获取页面的html代码
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private async Task<string> GetHtml(string url, Encoding encoding)
        {
            var stream = GetResponseStream(url);
            try
            {
                using (StreamReader streamreader = new StreamReader(stream, encoding))
                {
                    string html = await streamreader.ReadToEndAsync();
                    return html;
                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(2000 * 5);
                DownEventTag(string.Format("请求异常:{0}",url+ ex.Message + ex.InnerException));
                return string.Empty;
            }

        }
        /// <summary>
        /// 保存txt
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        private void DownTxt(string url, Encoding encoding, Options option)
        {
            var html = GetHtml(url, encoding);

        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url">文件路径</param>
        /// <param name="encoding">编码</param>
        /// <param name="option">保存信息</param>
        /// <param name="title">文件alt或者title</param>
        private async void DownFiles(string url, Encoding encoding, Options option, string title)
        {
        label:
            string file;
            var stream = GetResponseStream(url, out file);
            if (stream == null)
            {
                option.ErrorTime += 1;
                if (option.ErrorTime <= 5)//允许请求异常5次
                {
                    goto label;
                }
            }
            if (stream != null)
            {
                using (StreamReader streamreader = new StreamReader(stream, encoding))
                {
                    string filename = FileSavePath + "\\" + option.Title + "\\";
                    if (!Directory.Exists(filename))
                    {
                        Directory.CreateDirectory(filename);
                    }
                    if (!string.IsNullOrWhiteSpace(title))
                    {
                        title = title.Replace("\\", "");
                        filename += title;
                    }
                    var tempfilename = filename += file;
                    if (File.Exists(tempfilename))
                        return;
                    DownEventTag(string.Format("下载文件:{0}", filename));
                   
                    using (var locstrem = new FileStream(filename, FileMode.Create))
                    {
                        int totalsize = 0;
                        byte[] by = new byte[1024]; //1kb
                        int osize = stream.Read(by, 0, by.Length);
                        int mb = 0;
                        try
                        {
                            while (osize > 0)
                            {

                                totalsize += osize;
                                await locstrem.WriteAsync(by, 0, osize);
                                osize = stream.Read(by, 0, by.Length);
                                int tempmb = totalsize / (1024 * 1024);
                                if (tempmb != mb)
                                {
                                    mb = tempmb;
                                    DownEventTag(string.Format("文件{1} 已下载:{0}MB", mb, filename));
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            DownEventTag(string.Format("下载异常:{0}", ex.Message + ex.InnerException));
                        }
                        locstrem.Flush();
                    }
                    DownEventTag(string.Format("结束下载文件:{0}", file));
                }
            }

        }
        private Stream GetResponseStream(string url)
        {
            HttpWebRequest webrequest = WebRequest.Create(url) as HttpWebRequest;
            webrequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";

            webrequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            webrequest.Headers.Set("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.6,en;q=0.4");
            if (webrequest != null)
            {
                var webResponse = webrequest.GetResponse();
                Stream responsestream = webResponse.GetResponseStream();
                return responsestream;

            }
            return null;
            //return "";
        }
        private Regex _fileNameExtReg = new Regex("/(?<filename>[^/\\.=]*\\.[a-zA-Z0-9]+$)", RegexOptions.IgnoreCase);
        private Stream GetResponseStream(string url, out string filenameandext)
        {
            filenameandext = string.Empty;

            try
            {
                HttpWebRequest webrequest = WebRequest.Create(url) as HttpWebRequest;
                if (webrequest != null) ;
                {
                    var webResponse = webrequest.GetResponse();
                    Stream responsestream = webResponse.GetResponseStream();
                    if (_fileNameExtReg.IsMatch(url))
                        filenameandext = _fileNameExtReg.Match(url).Groups["filename"].Value;
                    else if (webResponse.ResponseUri != null &&
                             _fileNameExtReg.IsMatch(webResponse.ResponseUri.AbsolutePath))
                    {
                        filenameandext =
                            _fileNameExtReg.Match(webResponse.ResponseUri.AbsolutePath).Groups["filename"].Value;
                    }
                    return responsestream;

                }
            }
            catch (Exception ex)
            {
<<<<<<< HEAD
 
=======
>>>>>>> 5ef4d249aa3c4ec382e57e1d90245aff63308ae6
                Thread.Sleep(2000 * 5);
                DownEventTag(string.Format("请求异常:{0}",url+ ex.Message + ex.InnerException));
            }
            return null;
            //return "";
        }
    }
}
