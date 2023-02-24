using IlyfairyLib.GoCqHttpSdk;
using IlyfairyLib.GoCqHttpSdk.Api;

//创建一个连接cqhttp的会话  使用ws来接收消息,http来发送消息
Session session = new("ws://127.0.0.1:6700", "http://127.0.0.1:5700");

//接收所有群消息
session.UseGroupMessage(async v =>
{
    Console.WriteLine($"消息: {v.Message.RawMessage}");
    return true; //继续向下传递
});

//好友请求示例
session.UseFriendRequestMessage(async v =>
{
    if (v.Comment == "Pass")
    {
        v.Agree();
    }
    return true;
});

//复读机示例
session.MapGroupMessage(@"^echo\s*(?<content>.*)$", async (v, group) =>
{
    await session.SendRawGroupMessageAsync(v.GroupId, group["content"].Value);
});

session.Build();

new AutoResetEvent(false).WaitOne();
