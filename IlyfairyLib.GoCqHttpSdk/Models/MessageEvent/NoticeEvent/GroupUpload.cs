using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using IlyfairyLib.GoCqHttpSdk.Models.Shared.NoticeEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent.NoticeEvent;

public class GroupUpload : MessageEventBase, IGroupUpload
{
    public override MessageType MessageSubType => MessageType.NoticeGroupUpload;
    /// <summary>
    /// 发送者 QQ 号
    /// </summary>
    public long UserId { get; init; }
    /// <summary>
    /// 事件发生的时间戳
    /// </summary>
    public long Time { get; init; }
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 文件信息
    /// </summary>
    public GroupUploadFile File { get; init; }
    public GroupUpload(Session session, JToken json) : base(session, json)
    {
        session.RobotQQ = json.Value<long>("self_id");
        UserId = json.Value<long>("user_id");
        Time = json.Value<long>("time");
        GroupId = json.Value<long>("group_id");

        JObject FileInfo = json.Value<JObject>("file");
        Console.WriteLine(FileInfo.ToString());
        File.Id = FileInfo.Value<string>("id") ?? "";
        File.Name = FileInfo.Value<string>("name") ?? "";
        File.Size = FileInfo.Value<long>("size");
        File.BusId = FileInfo.Value<long>("busid");
    }
}
