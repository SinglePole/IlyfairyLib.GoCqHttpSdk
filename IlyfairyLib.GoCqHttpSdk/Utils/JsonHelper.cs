using IlyfairyLib.GoCqHttpSdk.Models.Chunks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Utils;

internal static class JsonHelper
{
    public static JArray ToJArray(this MessageChunk[] chunks)
    {
        return ToJArray(chunks.Cast<MessageChunk>());
    }
    public static JArray ToJArray(this IEnumerable<MessageChunk> chunks)
    {
        JArray array = new();
        foreach (var chunk in chunks)
        {
            array.Add(chunk.ToJson());
        }
        return array;
    }
}
