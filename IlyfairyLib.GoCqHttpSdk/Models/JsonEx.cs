namespace IlyfairyLib.GoCqHttpSdk.Models;

public class JsonEx
{
    public JObject Json { get; set; } = new();

    public JsonEx Set(string name, JToken value)
    {
        Json[name] = value;
        return this;
    }

    public static JsonEx Create()
    {
        return new JsonEx();
    }

    public static implicit operator JObject(JsonEx json)
    {
        return json.Json;
    }
}