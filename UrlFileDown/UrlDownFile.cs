using System;
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

        public event Action<string> DownEvent;
        private List<Options> options;
        public UrlDownFile(List<Options> _options)
        {
            options = _options;
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
                }
            }
        }
        private void DownLogic(Options model)
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
                        if (model.IsDetail) //如果捕获的是详细页面
                        {
                            var detailhtml = GetHtml(detailurl, _encoding);
                            detailhtml.ContinueWith(d =>
                            {
                                var detail = d.Result;
                                if (_detailReg.IsMatch(detail)) //详细也内容
                                {
                                    var _detailmatch = _detailReg.Matches(detail);//详细页面匹配的内容
                                    foreach (Match dmc in _detailmatch)
                                    {
                                        var url = dmc.Groups["url"].Value;
                                        LoadHref(url, _encoding, model);//捕获列表页资源

                                    }
                                }
                            });
                        }
                        else
                        {
                            LoadHref(detailurl, _encoding, model);//捕获列表页资源
                        }
                    }
                }
                if (model.IsNextPage)
                {
                    if (_nextpageReg.IsMatch(m.Result))
                    {
                        model.MainUrl = _nextpageReg.Match(m.Result).Groups["nextpage"].Value;
                        DownLogic(model);
                    }
                }
            });
        }

        private void LoadHref(string url, Encoding encoding, Options option)
        {
            switch (option.FileType)
            {
                case OptionFileType.File:
                    DownFiles(url, encoding, option);
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
                throw ex;
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
        /// 保存文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        private async void DownFiles(string url, Encoding encoding, Options option)
        {
            string file;
            var stream = GetResponseStream(url, out file);
            if (stream != null)
            {
                using (StreamReader streamreader = new StreamReader(stream, encoding))
                {
                    DownEventTag(string.Format("下载文件:{0}", file));
                    string filename = option.SavePath + "\\" + option.Title + "\\";
                    if (!Directory.Exists(filename))
                    {
                        Directory.CreateDirectory(filename);
                    }
                    filename += file;
                    using (var locstrem = new FileStream(filename, FileMode.Create))
                    {
                        int totalsize = 0;
                        byte[] by = new byte[1024]; //1kb
                        int osize = stream.Read(by, 0, by.Length);
                        int mb = 0;
                        while (osize > 0)
                        {
                            totalsize += osize;
                            await locstrem.WriteAsync(by, 0, osize);
                            osize = stream.Read(by, 0, by.Length);
                            int tempmb = totalsize / (1024 * 1024);
                            if (tempmb != mb)
                            {
                                mb = tempmb;
                                DownEventTag(string.Format("文件{1} 已下载:{0}MB", mb, file));
                            }
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
            if (webrequest != null) ;
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
                Thread.Sleep(1000 * 5);
                DownEventTag(string.Format("请求异常:{0}", ex.Message + ex.InnerException));
            }
            return null;
            //return "";
        }
    }
}
