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
    public static ApiActionType SendGroupMessage => new ApiActionType("send_group_msg");
    public static ApiActionType SendPrivateMessage => new ApiActionType("send_private_msg");
    public static ApiActionType SendMessage => new ApiActionType("send_msg");
    public static ApiActionType DeleteMessage => new ApiActionType("delete_msg");
    public static ApiActionType GetMessage => new ApiActionType("get_msg");
    public static ApiActionType GetGroupInfo => new ApiActionType("get_group_info");
    public static ApiActionType AgreeFriendRequest => new ApiActionType("set_friend_add_request ");
    public static ApiActionType AgreeGroupRequest => new ApiActionType("set_group_add_request");
}
