using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.Api;

public struct MessageApiResult
{
    public MessageApiResult(JObject? data, int returnCode, string wording)
    {
        Data = data;
        ReturnCode = returnCode;
        Wording = wording;
    }

    public JObject? Data { get; set; }
    public int ReturnCode { get; set; }
    public string Wording { get; set; }
    public bool Success { get => ReturnCode == 0 || ReturnCode == 1; }

}
