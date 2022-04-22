namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 链接分享
/// </summary>
public sealed class LocationChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.location;
    public double Lat { get; }
    public double Lon { get; }
    public LocationChunk(double lat, double lon)
    {
        Lat = lat;
        Lon = lon;
        Data["lat"] = lat;
        Data["lon"] = lon;
    }
}
