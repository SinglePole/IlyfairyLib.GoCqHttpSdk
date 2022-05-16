using IlyfairyLib.GoCqHttpSdk.Models.Chunks;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;

/// <summary>
/// 群聊消息
/// </summary>
public sealed class GroupMessage : MessageBase<GroupSender>, IGroupInfo
{
    /// <summary>
    /// 群消息类型<br/>始终是MessageType.GroupMessage
    /// </summary>
    public override MessageType MessageSubType => MessageType.GroupMessage;
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 匿名消息
    /// </summary>
    public Anonymous? Anonymous { get; init; }

    private GroupInfo? groupInfo;
    /// <summary>
    /// 群信息
    /// </summary>
    public GroupInfo? GroupInfo
    {
        get
        {
            if (groupInfo == null) groupInfo = session.GetGroupInfoAsync(GroupId, true).GetAwaiter().GetResult();
            return groupInfo;
        }
    }

    GroupInfo IGroupInfo.GroupInfo { get => GroupInfo; init => groupInfo = value; }
    

    internal Lazy<Task<(GroupFolderInfo[] folders, GroupFileInfo[] files)>> groupFilesLazy;
    /// <summary>
    /// 获取根目录文件列表
    /// </summary>
    /// <returns></returns>
    public async Task<(GroupFolderInfo[] folders, GroupFileInfo[] files)> GetRootFiles()
    {
        return await groupFilesLazy.Value;
    }
    
    internal Lazy<Task<GroupFileSystemInfo>> groupFileSystemInfoLazy;
    /// <summary>
    /// 获取群文件系统信息
    /// </summary>
    /// <returns></returns>
    public async Task<GroupFileSystemInfo> GetFileSystemInfo()
    {
        return await groupFileSystemInfoLazy.Value;
    }

    /// <summary>
    /// 刷新群信息
    /// </summary>
    /// <returns></returns>
    public GroupInfo? RefreshGroupInfo()
    {
        groupInfo = session.GetGroupInfoAsync(GroupId, false).GetAwaiter().GetResult();
        return groupInfo;
    }

    /// <summary>
    /// 发送合并转发
    /// </summary>
    /// <param name="nodes">合并转发节点</param>
    /// <returns></returns>
    public async Task SendForwardMessageAsync(params NodeChunk[] nodes)
    {
        await session.SendGroupForwardMessageAsync(GroupId, nodes);
    }

    internal GroupMessage(Session session, JToken json) : base(session, json)
    {
        Sender = GroupSender.Get(json["sender"]);
        GroupId = json.Value<long>("group_id");
        groupFilesLazy = new(async () =>
        {
            return await session.GetGroupRootFilesAsync(GroupId);
        });
        groupFileSystemInfoLazy = new(async () =>
        {
            return await session.GetGroupFileSystemInfoAsync(GroupId);
        });
    }
}
