# IlyfairyLib.GoCqHttpSdk

一个cqhttp的C#Sdk  
使用了类似管道的模式  

## 使用  

前往[go-cqhttp Release](https://github.com/Mrs4s/go-cqhttp/releases)下载go-cqhttp  

将config.yml里的message.post-format改成array  

开启http和ws  

下载NuGet包: IlyfairyLib.GoCqHttpSdk  

## 说明  

### 接收消息事件
session.Use*可以选择是否继续向下传递  
session.Map*如果匹配到了 则不会向下传递  

### 

## 示例  

``` C#
using IlyfairyLib.GoCqHttpSdk;
using IlyfairyLib.GoCqHttpSdk.Api;

//创建一个连接cqhttp的会话  使用ws来接收消息,http来发送消息
Session session = new("ws://127.0.0.1:6700", "http://127.0.0.1:5700");

//接收所有群消息
session.UseGroupMessage(async v =>
{
    Console.WriteLine($"消息json: \n{v.Message.ToJson()}");
    return true; //继续向下传递
});

//复读机示例
session.MapGroupMessage(@"^echo\s*(?<content>.*)$", async (v, group) =>
{
    await session.SendRawGroupMessageAsync(v.GroupId, group["content"].Value);
});

session.Build();

new AutoResetEvent(false).WaitOne();

```
