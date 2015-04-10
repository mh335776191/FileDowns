using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UrlFileDown
{
    [Serializable]
    public class Options
    {
        /// <summary>
        /// 采集网站名称
        /// </summary>
        public string Title { get; set; }
        private string mainurl;
        /// <summary>
        /// 抓取入口
        /// </summary>
        public string MainUrl
        {
            get
            {
                if (string.IsNullOrWhiteSpace(mainurl))
                    throw new ArgumentNullException("采集页面不能为空");
                return mainurl;
            }
            set { mainurl = value; }

        }
        /// <summary>
        /// 捕获资源的正则（如果有详细页则是列表页正则）
        /// </summary>
        public string DownFileReg { get; set; }
        /// <summary>
        /// 是否有分页
        /// </summary>
        public bool IsNextPage { get; set; }
        /// <summary>
        /// 分页正则
        /// </summary>
        public string NextPageReg { get; set; }
        /// <summary>
        /// 是否进入详情页获取
        /// </summary>
        public bool IsDetail { get; set; }
        /// <summary>
        /// 详细页资源正则
        /// </summary>
        public string DetailReg { get; set; }
        /// <summary>
        /// 保存到本地的路径
        /// </summary>
        public string SavePath { get; set; }

        /// <summary>
        /// 序列化实体的保存文件名称
        /// </summary>
        public string SaveFileName { get; set; }
        /// <summary>
        /// 网站编码格式
        /// </summary>
        public string Encoding { get; set; }
        /// <summary>
        /// 获取文件的类型
        /// </summary>
        public OptionFileType FileType { get; set; }
    }
    /// <summary>
    /// 获取资源的类型
    /// </summary>
    public enum OptionFileType
    {
        Text,
        File
    }

    public enum OptionsType
    {
        Add,
        Delete,
        Update
    }
}
