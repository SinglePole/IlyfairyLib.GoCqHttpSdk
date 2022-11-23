using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Utils;

/// <summary>
/// 工具扩展
/// </summary>
public static class UtilsExtentsion
{
    // , &#44;
    // & &amp;
    // [ &#91;
    // ] &#93;
    internal static Dictionary<string, string> RawToText = new()
    {
        { "&amp;", "&" },
        { "&#91;", "[" },
        { "&#93;", "]" },
    };
    internal static Dictionary<string, string> TextToRaw = new()
    {
        { "&", "&amp;" },
        { "[", "&#91;" },
        { "]", "&#93;" },
    };
    internal static Dictionary<string, string> JsonToRaw = new()
    {
        { ",", "&#44;" },
        { "&", "&amp;" },
        { "[", "&#91;" },
        { "]", "&#93;" },
    };
    internal static Dictionary<string, string> RawToJson = new()
    {
        { "&#44;", "," },
        { "&amp;", "&" },
        { "&#91;", "[" },
        { "&#93;", "]" },
    };

    [return: NotNullIfNotNull(nameof(rawText))]
    public static string? ToText(this string rawText)
        => rawText?.ReplaceAll(RawToText);

    [return: NotNullIfNotNull(nameof(text))]
    public static string? ToRawText(this string text)
        => text?.ReplaceAll(TextToRaw);

    [return: NotNullIfNotNull(nameof(jsonText))]
    public static string? ToJsonRawText(this string jsonText)
        => jsonText?.ReplaceAll(JsonToRaw);

    [return: NotNullIfNotNull(nameof(jsonRawText))]
    public static string? ToJsonText(this string jsonRawText)
        => jsonRawText.ReplaceAll(RawToJson);

    internal static string ReplaceAll(this string source, Dictionary<string, string> replacements)
    {
        bool StringEquals(string source1, string source2, int offset1, int offset2, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (source1[offset1 + i] != source2[offset2 + i])
                    return false;
            }
            return true;
        }
        StringBuilder s = new();
        for (int i = 0; i < source.Length;)
        {
            bool matched;
            do
            {
                matched = false;
                foreach (var kv in replacements)
                {
                    if (i >= source.Length)
                        break;
                    int count = Math.Min(source.Length - i, kv.Key.Length);
                    if (StringEquals(source, kv.Key, i, 0, count))
                    {
                        matched |= true;
                        s.Append(kv.Value);
                        i += kv.Key.Length;
                    }
                }
            }
            while (matched && i < source.Length);
            if (!matched)
            {
                s.Append(source[i]);
                i++;
            }
        }
        return s.ToString();
    }
}
