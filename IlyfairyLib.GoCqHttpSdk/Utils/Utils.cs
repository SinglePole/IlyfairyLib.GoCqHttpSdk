using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Utils
{
    /// <summary>
    /// 工具扩展
    /// </summary>
    public static class UtilsExtentsion
    {
        // , &#44;
        // & &amp;
        // [ &#91;
        // ] &#93;

        [return: NotNullIfNotNull(nameof(rawText))]
        public static string? ToText(this string rawText)
        {
            if (rawText is null) return null;
            StringBuilder s = new(rawText);
            s.Replace("&amp;", "&");
            s.Replace("&#91;", "[");
            s.Replace("&#93;", "]");
            return s.ToString();
        }

        [return: NotNullIfNotNull(nameof(text))]
        public static string? ToRawText(this string text)
        {
            if (text is null) return null;
            StringBuilder s = new(text);
            s.Replace("&", "&amp;");
            s.Replace("[", "&#91;");
            s.Replace("]", "&#93;");
            return s.ToString();
        }

        [return: NotNullIfNotNull(nameof(jsonText))]
        public static string? ToJsonRawText(this string jsonText)
        {
            if (jsonText is null) return null;
            StringBuilder s = new(jsonText);
            s.Replace(",", "&#44;");
            s.Replace("&", "&amp;");
            s.Replace("[", "&#91;");
            s.Replace("]", "&#93;");
            return s.ToString();
        }

        [return: NotNullIfNotNull(nameof(jsonRawText))]
        public static string? ToJsonText(this string jsonRawText)
        {
            if (jsonRawText is null) return null;
            StringBuilder s = new(jsonRawText);
            s.Replace("&#44;", ",");
            s.Replace("&amp;", "&");
            s.Replace("&#91;", "[");
            s.Replace("&#93;", "]");
            return s.ToString();
        }
    }
}
