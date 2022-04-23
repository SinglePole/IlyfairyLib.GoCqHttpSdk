namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 表情
/// </summary>
public sealed class FaceChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.at;

    private int id;

    public int ID
    {
        get { return id; }
        set { id = value; Data["id"] = value; }
    }

    public FaceChunk(int id)
    {
        ID = id;
    }
    
    public static new FaceChunk? Parse(JToken json)
    {
        var data = json["data"];
        var face = new FaceChunk(data.Value<int>("id"));
        face.Data = data as JObject;
        return face;
    }
}
