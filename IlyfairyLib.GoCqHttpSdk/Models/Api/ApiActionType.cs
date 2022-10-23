namespace IlyfairyLib.GoCqHttpSdk.Models.Api;

public struct ApiActionType
{
    private readonly string action;
    private ApiActionType(string action)
    {
        this.action = action;
    }
    public override string ToString()
    {
        return action;
    }
    /// <summary>
    /// 设置在线机型
    /// </summary>
    public static ApiActionType SetModelShow => new ("_set_model_show");
    /// <summary>
    /// 获取在线机型
    /// </summary>
    public static ApiActionType GetModelShow => new("_get_model_show");
    /// <summary>
    /// 检查链接安全性
    /// </summary>
    public static ApiActionType CheckUrlSafely => new("check_url_safely");
    /// <summary>
    /// 获取精华消息列表
    /// </summary>
    public static ApiActionType GetEssenceMsgList => new ("get_essence_msg_list");
    /// <summary>
    /// 移出精华消息
    /// </summary>
    public static ApiActionType DeleteEssenceMsg => new("delete_essence_msg");
    /// <summary>
    /// 设置精华消息
    /// </summary>
    public static ApiActionType SetEssenceMsg => new("set_essence_msg");
    /// <summary>
    /// 获取群消息历史记录
    /// </summary>
    public static ApiActionType GetGroupMsgHistory => new("set_essence_msg");
    /// <summary>
    /// 获取当前账号在线客户端列表
    /// </summary>
    public static ApiActionType GetOnlineClients => new("get_online_clients");
    /// <summary>
    /// 下载文件到缓存目录
    /// </summary>
    public static ApiActionType DownloadFile => new("download_file");
    /// <summary>
    /// 重载事件过滤器
    /// </summary>
    public static ApiActionType ReloadEventFilter => new ("reload_event_filter");
    /// <summary>
    /// 获取群公告
    /// </summary>
    public static ApiActionType GetGroupNotice => new("_get_group_notice");
    /// <summary>
    /// 发送群公告
    /// </summary>
    public static ApiActionType SendGroupNotice => new ("_send_group_notice");
    /// <summary>
    /// 获取群根目录文件列表
    /// </summary>
    public static ApiActionType GetGroupRootFiles => new ("get_group_root_files");
    /// <summary>
    /// 上传群文件
    /// </summary>
    public static ApiActionType UploadGroupFile => new("upload_group_file");
    /// <summary>
    /// 上传私聊文件
    /// </summary>
    public static ApiActionType UploadPrivateFile => new("upload_private_file");
    /// <summary>
    /// 获取群系统消息
    /// </summary>
    public static ApiActionType GetGroupSystemMsg => new("get_group_system_msg");
    /// <summary>
    /// 设置群头像
    /// </summary>
    public static ApiActionType SetGroupPrtrait => new ("set_group_portrait");
    /// <summary>
    /// 重启 go-cqhttp
    /// </summary>
    public static ApiActionType SetRestart => new ("set_restart");
    /// <summary>
    /// 获取版本信息
    /// </summary>
    public static ApiActionType GetVersionInfo => new("get_version_info");
    /// <summary>
    /// 检查是否可以发送语音
    /// </summary>
    public static ApiActionType CanSendRecord => new("can_send_record");
    /// <summary>
    /// 检查是否可以发送图片
    /// </summary>
    public static ApiActionType CanSendImage = new("can_send_image");
    /// <summary>
    /// 删除好友
    /// </summary>
    public static ApiActionType DeleteFriend => new("elete_friend");
    /// <summary>
    /// 获取单向好友列表
    /// </summary>
    public static ApiActionType GetUnidirectionalFriendList => new("get_unidirectional_friend_list");
    /// <summary>
    /// 获取好友列表
    /// </summary>
    public static ApiActionType GetFriendList => new("get_friend_list");
    /// <summary>
    /// 设置登录号资料
    /// </summary>
    public static ApiActionType SetQqProfile => new("set_qq_profile");
    /// <summary>
    /// 获取登录号信息
    /// </summary>
    public static ApiActionType GetLoginInfo => new("get_login_info");
    /// <summary>
    /// 群打卡
    /// </summary>
    public static ApiActionType SendGroupSign => new("send_group_sign");
    /// <summary>
    /// 设置群组专属头衔
    /// </summary>
    public static ApiActionType SetGroupSpecialTitle => new("set_group_special_title");
    /// <summary>
    /// 设置群名
    /// </summary>
    public static ApiActionType SetGroupName => new("set_group_name");
    /// <summary>
    /// 设置群名片 ( 群备注 )
    /// </summary>
    public static ApiActionType SetGroupCard => new("set_group_card");
    /// <summary>
    /// 群组设置管理员
    /// </summary>
    public static ApiActionType GetGroupAdmin => new("set_group_admin");
    /// <summary>
    /// 群组全员禁言
    /// </summary>
    public static ApiActionType SetGroupWholeBan => new("set_group_whole_ban");
    /// <summary>
    /// 标记消息已读
    /// </summary>
    public static ApiActionType MarkMsgAsRead => new("mark_msg_as_read");
    /// <summary>
    /// 获取图片信息
    /// </summary>
    public static ApiActionType GetImage => new("get_image");
    /// <summary>
    /// 获取合并转发内容
    /// </summary>
    public static ApiActionType GetForwardMsg => new("get_forward_msg");
    /// <summary>
    /// 退出群组
    /// </summary>
    public static ApiActionType SetGroupLeave => new("set_group_leave");
    /// <summary>
    /// 获取陌生人信息
    /// </summary>
    public static ApiActionType GetStrangerInfo => new("get_stranger_info");
    /// <summary>
    /// 获取群成员信息
    /// </summary>
    public static ApiActionType GetGroupMemberInfo => new("get_group_member_info");
    /// <summary>
    /// 获取群成员列表
    /// </summary>
    public static ApiActionType GetGroupMemberList => new("get_group_member_list");
    /// <summary>
    /// 发送群消息
    /// </summary>
    public static ApiActionType SendGroupMessage => new("send_group_msg");
    /// <summary>
    /// 群组单人禁言
    /// </summary>
    public static ApiActionType SetGroupBan => new("set_group_ban");
    /// <summary>
    /// 群组踢人
    /// </summary>
    public static ApiActionType SetGroupKick => new("set_group_kick");
    /// <summary>
    /// 发送私聊消息
    /// </summary>
    public static ApiActionType SendPrivateMessage => new("send_private_msg");
    /// <summary>
    /// 发送消息
    /// </summary>
    public static ApiActionType SendMessage => new("send_msg");
    /// <summary>
    /// 撤回消息
    /// </summary>
    public static ApiActionType DeleteMessage => new("delete_msg");
    /// <summary>
    /// 获取消息
    /// </summary>
    public static ApiActionType GetMessage => new("get_msg");
    /// <summary>
    /// 获取群信息
    /// </summary>
    public static ApiActionType GetGroupInfo => new("get_group_info");
    /// <summary>
    /// 获取群列表
    /// </summary>
    public static ApiActionType GetGroupList => new("get_group_list");
    /// <summary>
    /// 处理加好友请求
    /// </summary>
    public static ApiActionType AgreeFriendRequest => new("set_friend_add_request");
    /// <summary>
    /// 处理加群请求／邀请
    /// </summary>
    public static ApiActionType AgreeGroupRequest => new("set_group_add_request");
    /// <summary>
    /// 获取群文件系统信息
    /// </summary>
    public static ApiActionType GetGroupFileSystemInfo => new("get_group_file_system_info");
    /// <summary>
    /// 获取群子目录文件列表
    /// </summary>
    public static ApiActionType GetGroupFilesByFolder => new("get_group_files_by_folder");
    /// <summary>
    /// 获取群文件资源链接
    /// </summary>
    public static ApiActionType GetGroupFileUrl => new("get_group_file_url");
    /// <summary>
    /// 获取合并转发内容
    /// </summary>
    public static ApiActionType GetForwardMessage => new("get_forward_msg");
    /// <summary>
    /// 发送合并转发 (群)
    /// </summary>
    public static ApiActionType SendGroupForwardMessage => new("send_group_forward_msg");
}
