using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Utils
{
    public static class UtilsExtentsion
    {
        // & &amp;
        // [ &#91;
        // ] &#93;


        public static string? ToText(this string? rawText)
        {
            if (rawText is null) return null;
            StringBuilder s = new(rawText);
            s.Replace("&amp;", "&");
            s.Replace("&#91;", "[");
            s.Replace("&#93;", "]");
            return s.ToString();
        }

        public static string? ToRawText(this string? text)
        {
            if (text is null) return null;
            StringBuilder s = new(text);
            s.Replace("&", "&amp;");
            s.Replace("[", "&#91;");
            s.Replace("]", "&#93;");
            return s.ToString();
        }

        public static string? ToJsonRawText(this string? jsonText)
        {
            if (jsonText is null) return null;
            StringBuilder s = new(jsonText);
            s.Replace(",", "&#44;");
            s.Replace("&", "&amp;");
            s.Replace("[", "&#91;");
            s.Replace("]", "&#93;");
            return s.ToString();
        }

        public static string? ToJsonText(this string? jsonRawText)
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
