using Flurl.Http;
using IlyfairyLib.GoCqHttpSdk.Models.Api;
using IlyfairyLib.GoCqHttpSdk.Models.Chunks;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using IlyfairyLib.GoCqHttpSdk.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Api;

/// <summary>
/// 消息Api扩展
/// </summary>
public static class MessageApiExtentsion
{
    private static MediaTypeHeaderValue JsonContentType { get; } = new MediaTypeHeaderValue("application/json");
    private static async Task<string> SendApiAsync(this Session server, string text)
    {
        var content = new StringContent(text);
        content.Headers.ContentType = JsonContentType;
        return await server.HttpUrl.SendAsync(HttpMethod.Post, content).ReceiveString();
    }
    private static async Task<string> SendApiAsync(Session server, ApiActionType action, JObject @params)
    {
        JObject json = new();
        json["action"] = action.ToString();
        json["params"] = @params;
        return await SendApiAsync(server, json.ToString());
    }

    internal static async Task<MessageApiResult> SendApiMessageAsync(Session server, ApiActionType action, JObject @params)
    {
        var result = await SendApiAsync(server, action, @params);
        try
        {
            var json = JObject.Parse(result);
            var data = json["data"] as JObject;
            var ret = json.Value<int>("ret");
            var wording = json.Value<string>("wording") ?? "";
            return new MessageApiResult(data, ret, wording);
        }
        catch (Exception)
        {
            return new MessageApiResult(null, -1, string.Empty);
        }
    }

    /// <summary>
    /// 发送群消息
    /// </summary>
    /// <param name="session"></param>
    /// <param name="groupId">群ID</param>
    /// <param name="message">消息</param>
    /// <returns>成功返回消息id,否则为null</returns>
    public static async Task<int?> SendGroupMessageAsync(this Session session, long groupId, params MessageChunk[] message)
    {
        return await SendGroupMessageAsync(session, groupId, new MessageBuilder(message));
    }
    /// <summary>
    /// 发送群消息
    /// </summary>
    /// <param name="session"></param>
    /// <param name="groupId">群ID</param>
    /// <param name="message">消息</param>
    /// <returns>成功返回消息id,否则为null</returns>
    public static async Task<int?> SendGroupMessageAsync(this Session session, long groupId, MessageBuilder message)
    {
        var json = JsonEx.Create()
            .Set("group_id", groupId)
            .Set("message", message.ToJArray());
        var result = await SendApiMessageAsync(session, ApiActionType.SendGroupMessage, json);
        if (result.Success)
        {
            return result.Data?.Value<int>("message_id");
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 发送原始CQ群消息
    /// </summary>
    /// <param name="session"></param>
    /// <param name="groupId">群号</param>
    /// <param name="message">消息</param>
    /// <returns></returns>
    public static async Task<int?> SendRawGroupMessageAsync(this Session session, long groupId, string message)
    {
        var json = JsonEx.Create()
            .Set("group_id", groupId)
            .Set("message", message);

        var result = await SendApiMessageAsync(session, ApiActionType.SendGroupMessage, json);
        if (result.Success)
        {
            return result.Data?.Value<int>("message_id");
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// 发送私聊消息
    /// </summary>
    /// <param name="session"></param>
    /// <param name="qq">QQ</param>
    /// <param name="message">消息</param>
    /// <returns>成功返回消息id,否则为null</returns>
    public static async Task<int?> SendPrivateMessageAsync(this Session session, long qq, MessageBuilder message)
    {
        var json = JsonEx.Create()
            .Set("user_id", qq)
            .Set("message", message.ToJArray());

        var result = await SendApiMessageAsync(session, ApiActionType.SendPrivateMessage, json);
        if (result.Success)
        {
            return result.Data?.Value<int>("message_id");
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// 发送消息 <br/>会根据参数自动判断发送到私聊还是群组
    /// </summary>
    /// <param name="session"></param>
    /// <param name="group">群ID</param>
    /// <param name="qq">QQ</param>
    /// <param name="message">消息</param>
    /// <returns>成功返回消息id,否则为null</returns>
    public static async Task<int?> SendMessageAsync(this Session session, long group, long qq, MessageBuilder message)
    {

        var json = JsonEx.Create()
            .Set("group_id", group)
            .Set("user_id", qq)
            .Set("message", message.ToJArray());

        var result = await SendApiMessageAsync(session, ApiActionType.SendMessage, json);
        if (result.Success)
        {
            return result.Data?.Value<int>("message_id");
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 获取群信息
    /// </summary>
    /// <param name="session"></param>
    /// <param name="groupId">群ID</param>
    /// <param name="useCache">是否使用缓存</param>
    /// <returns>成功返回群信息,否则为null</returns>
    public static async Task<GroupInfo?> GetGroupInfoAsync(this Session session, long groupId, bool useCache = true)
    {
        var json = JsonEx.Create()
            .Set("group_id", groupId)
            .Set("no_cache", !useCache);

        var result = await SendApiMessageAsync(session, ApiActionType.GetGroupInfo, json);
        if (result.Success)
        {
            var info = new GroupInfo()
            {
                Id = result.Data?.Value<long>("group_id") ?? 0,
                Name = result.Data?.Value<string>("group_name") ?? "",
                Level = result.Data?.Value<int>("group_level") ?? 0,
                MemberCount = result.Data?.Value<int>("member_count") ?? 0,
                MaxMemberCount = result.Data?.Value<int>("max_member_count") ?? 0,
            };

            info.Memorandum = result.Data?.Value<string>("group_memo") ?? "";
            if (string.IsNullOrEmpty(info.Memorandum)) info.Memorandum = info.Name;
            info.CreateTime = result.Data?.Value<int>("group_create_time") ?? 0;

            return info;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 允许好友请求
    /// </summary>
    /// <param name="session"></param>
    /// <param name="flag">flag</param>
    /// <param name="approve">是否同意加好友请求</param>
    /// <param name="remark">备注</param>
    public static async Task<bool> AgreeFriendRequest(this Session session, string flag, bool approve = true, string? remark = null)
    {
        var json = JsonEx.Create()
            .Set("flag", flag)
            .Set("approve", approve)
            .Set("remark", remark);

        return (await SendApiMessageAsync(session, ApiActionType.AgreeFriendRequest, json)).Success;
    }

    /// <summary>
    /// 允许加群请求
    /// </summary>
    /// <param name="session"></param>
    /// <param name="flag">flag</param>
    /// <param name="type">请求类型 需要一致</param>
    /// <param name="approve">是否同意加加群请求</param>
    /// <param name="reason">拒绝理由</param>
    public static async Task<bool> AgreeGroupRequestAsync(this Session session, string flag, GroupRequestType type, bool approve = true, string? reason = null)
    {
        var json = JsonEx.Create()
            .Set("flag", flag)
            .Set("type", type switch
            {
                GroupRequestType.Add => "add",
                GroupRequestType.Invite => "invite",
                _ => "",
            })
            .Set("approve", approve)
            .Set("reason", reason);

        return (await SendApiMessageAsync(session, ApiActionType.AgreeGroupRequest, json)).Success;
    }

    /// <summary>
    /// 撤回消息
    /// </summary>
    /// <param name="session"></param>
    /// <param name="messageId">消息ID</param>
    /// <returns></returns>
    public static async Task<bool> DeleteMessageAsync(this Session session, int messageId)
    {
        JObject json = new();
        json["message_id"] = messageId;

        return (await SendApiMessageAsync(session, ApiActionType.DeleteMessage, json)).Success;
    }

    /// <summary>
    /// 获取消息
    /// </summary>
    /// <param name="session"></param>
    /// <param name="messageId">消息ID</param>
    /// <returns></returns>
    public static async Task<HistoryMessage?> GetMessageAsync(this Session session, int messageId)
    {
        JObject json = new();
        json["message_id"] = messageId;
        var result = await SendApiMessageAsync(session, ApiActionType.GetMessage, json);
        if (result.Success && result.Data != null)
        {
            return HistoryMessage.Parse(session, result.Data);
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 上传群文件<br/>
    /// 只能上传本地文件, 需要上传 http 文件的话请先调用 download_file API下载
    /// </summary>
    /// <param name="session"></param>
    /// <param name="groupId">群号</param>
    /// <param name="file">本地文件路径</param>
    /// <param name="name">储存名称</param>
    /// <param name="folder">父目录ID<br/>null则上传到根目录</param>
    /// <returns></returns>
    public static async Task<bool> UploadGroupFileAsync(this Session session, long groupId, string file, string name, string? folder = null)
    {
        var json = JsonEx.Create()
            .Set("group_id", groupId)
            .Set("file", file)
            .Set("name", name)
            .Set("folder", folder);

        var result = await SendApiMessageAsync(session, ApiActionType.UploadGroupFile, json);
        return result.Success;
    }

    /// <summary>
    /// 获取群文件系统信息
    /// </summary>
    /// <param name="session"></param>
    /// <param name="groupId">群号</param>
    /// <returns></returns>
    public static async Task<GroupFileSystemInfo?> GetGroupFileSystemInfoAsync(this Session session, long groupId)
    {
        var json = JsonEx.Create()
            .Set("group_id", groupId);

        var result = await SendApiMessageAsync(session, ApiActionType.GetGroupFileSystemInfo, json);

        if (result.Success)
        {
            var file_count = result.Data?.Value<int>("file_count") ?? 0;
            var limit_count = result.Data?.Value<int>("limit_count") ?? 0;
            var used_space = result.Data?.Value<long>("used_space") ?? 0;
            var total_space = result.Data?.Value<long>("total_space") ?? 0;
            return new GroupFileSystemInfo(groupId, file_count, limit_count, used_space, total_space);
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 获取群根目录文件列表
    /// </summary>
    /// <param name="session"></param>
    /// <param name="groupId">群号</param>
    /// <returns></returns>
    public static async Task<(GroupFolderInfo[] folders, GroupFileInfo[] files)> GetGroupRootFilesAsync(this Session session, long groupId)
    {
        var json = JsonEx.Create()
            .Set("group_id", groupId);

        var result = await SendApiMessageAsync(session, ApiActionType.GetGroupRootFiles, json);

        if (result.Success)
        {
            List<GroupFileInfo> files = new();
            List<GroupFolderInfo> folders = new();

            foreach (var item in result.Data?["files"]?.ToArray() ?? Array.Empty<JToken>())
            {
                var info = new GroupFileInfo(item);
                info.fileUrlLazy = new Lazy<Task<string>>(async () =>
                {
                    return await session.GetGroupFileUrlAsync(groupId, info.FileId, info.Busid);
                });
                files.Add(info);
            }

            foreach (var item in result.Data?["folders"]?.ToArray() ?? Array.Empty<JToken>())
            {
                var info = new GroupFolderInfo(item);
                info.subFileInfo = new Lazy<Task<(GroupFolderInfo[] folders, GroupFileInfo[] files)>>(async () =>
                {
                    return await session.GetGroupSubFolder(groupId, info.FolderId);
                });
                folders.Add(info);
            }

            return (folders.ToArray(), files.ToArray());
        }
        else
        {
            return (null, null);
        }
    }

    /// <summary>
    /// 获取群子目录文件列表
    /// </summary>
    /// <param name="session"></param>
    /// <param name="groupId">群号</param>
    /// <param name="folderId">文件夹ID</param>
    /// <returns></returns>
    public static async Task<(GroupFolderInfo[] folders, GroupFileInfo[] files)> GetGroupSubFolder(this Session session, long groupId, string folderId)
    {
        var json = JsonEx.Create()
            .Set("group_id", groupId)
            .Set("folder_id", folderId);

        var result = await SendApiMessageAsync(session, ApiActionType.GetGroupFilesByFolder, json);

        if (result.Success)
        {
            List<GroupFileInfo> files = new();
            List<GroupFolderInfo> folders = new();

            foreach (var item in result.Data?["files"]?.ToArray() ?? Array.Empty<JToken>())
            {
                var info = new GroupFileInfo(item);
                info.fileUrlLazy = new Lazy<Task<string>>(async () =>
                {
                    return await session.GetGroupFileUrlAsync(groupId, info.FileId, info.Busid);
                });
                files.Add(info);
            }

            foreach (var item in result.Data?["folders"]?.ToArray() ?? Array.Empty<JToken>())
            {
                var info = new GroupFolderInfo(item);
                info.subFileInfo = new Lazy<Task<(GroupFolderInfo[] folders, GroupFileInfo[] files)>>(async () =>
                {
                    return await session.GetGroupSubFolder(groupId, info.FolderId);
                });
                folders.Add(info);
            }

            return (folders.ToArray(), files.ToArray());
        }
        else
        {
            return (null, null);
        }
    }

    /// <summary>
    /// 获取群文件链接
    /// </summary>
    /// <param name="session"></param>
    /// <param name="groupId">群号</param>
    /// <param name="fileId">文件ID</param>
    /// <param name="busid">Busid</param>
    /// <returns>返回Url</returns>
    public static async Task<string?> GetGroupFileUrlAsync(this Session session, long groupId, string fileId, int busid)
    {
        var json = JsonEx.Create()
            .Set("group_id", groupId)
            .Set("file_id", fileId)
            .Set("busid", busid);

        var result = await SendApiMessageAsync(session, ApiActionType.GetGroupFileUrl, json);

        if (result.Success)
        {
            return result.Data?.Value<string>("url");
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 获取合并转发内容
    /// </summary>
    /// <param name="session"></param>
    /// <param name="forwardId">合并转发ID</param>
    /// <returns>返回Url</returns>
    internal static async Task<JArray?> GetForwardMessageAsync(this Session session, string forwardId)
    {
        var json = JsonEx.Create()
            .Set("message_id", forwardId);

        var result = await SendApiMessageAsync(session, ApiActionType.GetForwardMessage, json);

        if (result.Success)
        {
            return result.Data?["messages"] as JArray;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 发送合并转发 (群)
    /// </summary>
    /// <param name="session"></param>
    /// <param name="groupId">群号</param>
    /// <param name="nodes">消息</param>
    /// <returns>返回Url</returns>
    public static async Task SendGroupForwardMessageAsync(this Session session, long groupId, params NodeChunk[] nodes)
    {
        JArray array = new();
        foreach (var item in nodes)
        {
            array.Add(item.ToJson());
        }
        var json = JsonEx.Create()
            .Set("group_id", groupId)
            .Set("messages", array);

        var result = await SendApiMessageAsync(session, ApiActionType.SendGroupForwardMessage, json);
    }
    /// <summary>
    /// 群组单人禁言
    /// </summary>
    /// <param name="session"></param>
    /// <param name="groupId">群号</param>
    /// <param name="qq">禁言的qq</param>
    /// <param name="duration">禁言时长</param>
    /// <returns>返回Url</returns>
    public static async Task SetGroupBan(this Session session, long groupId, long qq, long duration = 30 * 60)
    {
        var json = JsonEx.Create()
            .Set("group_id", groupId)
            .Set("user_id", qq)
            .Set("duration", duration);

        await SendApiMessageAsync(session, ApiActionType.SetGroupBan, json);
    }
    /// <summary>
    /// 群组踢人
    /// </summary>
    /// <param name="session"></param>
    /// <param name="groupId">群号</param>
    /// <param name="qq">要禁言的 QQ 号</param>
    /// <param name="duration">	禁言时长, 单位秒, 0 表示取消禁言</param>>
    /// <returns>成功返回消息true,否则为null</returns>
    public static async Task<bool> SetGroupKickAsync(this Session session, long groupId, long qq, bool reject_add_request = false)
    {
        var json = JsonEx.Create()
            .Set("group_id", groupId)
            .Set("user_id", qq)
            .Set("reject_add_request", reject_add_request);
        var result = await SendApiMessageAsync(session, ApiActionType.SetGroupKick, json);
        return result.Success;
    }
    /// <summary>
    /// 获取群成员信息
    /// </summary>
    /// <param name="session"></param>
    /// <param name="groupId">群号</param>
    /// <param name="qq">QQ</param>
    /// <param name="no_cache">是否不使用缓存（使用缓存可能更新不及时, 但响应更快）</param>
    /// <returns>成功返回群成员信息,否则为null</returns>
    public static async Task<GroupMemberInfo?> GetGroupMemberInfoAsync(this Session session, long groupId, long qq, bool no_cache = false)
    {
        var json = JsonEx.Create()
        .Set("group_id", groupId)
        .Set("user_id", qq)
        .Set("no_cache", no_cache);
        var result = await SendApiMessageAsync(session, ApiActionType.GetGroupMemberInfo, json);
        if (result.Success)
        {
            GroupMemberInfo info = new GroupMemberInfo();
            info.groupId = result.Data?.Value<long>("group_id") ?? 0;
            info.qq = result.Data?.Value<long>("user_id") ?? 0;
            info.nickname = result.Data?.Value<string>("nickname") ?? "";
            info.card = result.Data?.Value<string>("card") ?? "";
            info.sex = result.Data?.Value<string>("sex") ?? "";
            info.age = result.Data?.Value<int>("age") ?? 0;
            info.area = result.Data?.Value<string>("area") ?? "";
            info.join_time = result.Data?.Value<int>("join_time") ?? 0;
            info.last_sent_time = result.Data?.Value<int>("last_sent_time") ?? 0;
            info.level = result.Data?.Value<string>("level") ?? "";
            info.role = result.Data?.Value<string>("role") ?? "";
            info.unfriendly = result.Data?.Value<bool>("unfriendly") ?? false;
            info.title = result.Data?.Value<string>("title") ?? "";
            info.title_expire_time = result.Data?.Value<long>("title_expire_time") ?? 0;
            info.card_changeable = result.Data?.Value<bool>("card_changeable") ?? true;
            info.shut_up_timestamp = result.Data?.Value<long>("shut_up_timestamp") ?? 0;
            return info;
        }
        return null;
    }
    /// <summary>
    /// 获取陌生人信息
    /// </summary>
    /// <param name="session"></param>
    /// <param name="qq">QQ</param>
    /// <param name="no_cache">是否不使用缓存（使用缓存可能更新不及时, 但响应更快，默认不使用）</param>
    /// <returns>成功返回消息id,否则为null</returns>
    public static async Task<StrangerInfo?> GetStrangerInfoAsync(this Session session, long qq, bool no_cache = false)
    {
        var json = JsonEx.Create()
            .Set("user_id", qq)
            .Set("no_cache", no_cache);
        var result = await SendApiMessageAsync(session, ApiActionType.GetStrangerInfo, json);
        if (result.Success)
        {
            StrangerInfo info = new StrangerInfo();
            info.qq = result.Data?.Value<long>("user_id") ?? 0;
            info.nickname = result.Data?.Value<string>("nickname") ?? "";
            info.sex = result.Data?.Value<string>("sex") ?? "";
            info.age = result.Data?.Value<int>("age") ?? 0;
            info.qid = result.Data?.Value<string>("qid") ?? "";
            info.level = result.Data?.Value<int>("level") ?? 0;
            info.login_days = result.Data?.Value<int>("login_days") ?? 0;
            return info;
        }
        else
        {
            return null;
        }
    }
}
