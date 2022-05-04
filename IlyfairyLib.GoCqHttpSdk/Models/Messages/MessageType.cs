namespace IlyfairyLib.GoCqHttpSdk.Models.Messages;

/// <summary>
/// 消息类型
/// </summary>
public enum MessageType
{
    Lifecycle, //生命周期
    Heartbeat, //心跳包
    PrivateMessage, //私聊消息
    GroupMessage, //群聊消息
    NoticeGroupUpload, //群文件上传
    NoticeGroupAdmin, //群管理员变动
    NoticeGroupDecrease, //群成员减少
    NoticeGroupIncrease, //群成员增加
    NoticeGroupBan, //群禁言 和 取消禁言
    NoticeFriendAdd, //好友添加
    NoticeGroupRecall, //群消息撤回
    NoticeFriendRecall, //好友消息撤回
    NoticePoke, //群内戳一戳
    NoticeLuckyKing, //群红包运气王
    NoticeHonor, //群成员荣誉变更
    RequestFriend, //好友请求
    RequestGroup, //群请求
}