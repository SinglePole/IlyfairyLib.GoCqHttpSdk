using IlyfairyLib.GoCqHttpSdk;
using IlyfairyLib.GoCqHttpSdk.Api;

Session session = new("ws://127.0.0.1:6700", "http://127.0.0.1:5700");

//接收所有群消息
session.UseGroupMessage(async v =>
{
    Console.WriteLine($"消息json: \n{v.Message.ToJson()}");
    return true; //继续向下传递
});

//复读机示例
session.MapGroup(@"^echo\s*(?<content>.*)$", async (v, group) =>
{
    await session.SendRawGroupMessageAsync(v.GroupId, group["content"].Value);
});

session.Build();

new AutoResetEvent(false).WaitOne();
