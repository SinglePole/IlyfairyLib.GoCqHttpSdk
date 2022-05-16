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
            return rawText
                .Replace("&amp;", "&")
                .Replace("&#91;", "[")
                .Replace("&#93;", "]");
        }
        
        public static string? ToRawText(this string? text)
        {
            if (text is null) return null;
            return text
                .Replace("&", "&amp;")
                .Replace("[", "&#91;")
                .Replace("]", "&#93;");
        }
    }
}
