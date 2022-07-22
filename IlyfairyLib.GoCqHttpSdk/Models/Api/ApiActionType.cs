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
    public static ApiActionType SendGroupMessage => new("send_group_msg");
    public static ApiActionType SendPrivateMessage => new("send_private_msg");
    public static ApiActionType SendMessage => new("send_msg");
    public static ApiActionType DeleteMessage => new("delete_msg");
    public static ApiActionType GetMessage => new("get_msg");
    public static ApiActionType GetGroupInfo => new("get_group_info");
    public static ApiActionType AgreeFriendRequest => new("set_friend_add_request ");
    public static ApiActionType AgreeGroupRequest => new("set_group_add_request");
    /// <summary>
    /// 上传群文件
    /// </summary>
    public static ApiActionType UploadGroupFile => new("upload_group_file");
    /// <summary>
    /// 获取群文件系统信息
    /// </summary>
    public static ApiActionType GetGroupFileSystemInfo => new("get_group_file_system_info");
    /// <summary>
    /// 获取群根目录文件列表
    /// </summary>
    public static ApiActionType GetGroupRootFiles => new("get_group_root_files");
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
    /// <summary>
    /// 群组单人禁言
    /// </summary>
    public static ApiActionType SetGroupBan => new("set_group_ban");
}
