using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlFileDown.Tool
{
    public static class ExtendMethods
    {
        /// <summary>
        /// 替换url中被编码过的符号
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ReplaceUrlHtmlTag(this string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                input = input.Replace("&amp;", "&");
            }
            return input;
        }
    }
}
