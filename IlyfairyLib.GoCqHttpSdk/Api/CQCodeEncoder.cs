using Flurl.Http;
using IlyfairyLib.GoCqHttpSdk.Models.Api;
using IlyfairyLib.GoCqHttpSdk.Models.Chunks;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using IlyfairyLib.GoCqHttpSdk.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

/// <summary>
/// CQ码
/// </summary>
namespace IlyfairyLib.GoCqHttpSdk.Api
{
    public static class CQCodeEncoder
    {
        /// <summary>
        /// QQ 表情
        /// </summary>
        /// <param name="id">QQ 表情 ID</param>
        /// <returns></returns>
        public static string Face(int id)
        {
            return "[CQ:face,id=" + id + "]";
        }
        /// <summary>
        /// 语音
        /// </summary>
        /// <param name="file">语音文件名</param>
        /// <param name="magic">发送时可选, 默认 0, 设置为 1 表示变声</param>
        /// <param name="cache">只在通过网络 URL 发送时有效, 表示是否使用已缓存的文件, 默认 1</param>
        /// <param name="proxy">只在通过网络 URL 发送时有效, 表示是否通过代理下载文件 ( 需通过环境变量或配置文件配置代理 ) , 默认 1</param>
        /// <returns></returns>
        public static string Record(string file, int magic = 0, int cache = 1,int proxy = 1)
        {
            return "[CQ:record,file=" + file + ",magic=" + magic + ",cache=" + cache + ",proxy=" + proxy +"]";
        }
        /// <summary>
        /// 短视频
        /// </summary>
        /// <param name="file">视频地址, 支持http和file发送</param>
        /// <param name="cover">视频封面, 支持http, file和base64发送, 格式必须为jpg</param>
        /// <param name="c">通过网络下载视频时的线程数, 默认单线程. (在资源不支持并发时会自动处理)</param>
        /// <returns></returns>
        public static string Video(string file, string cover = null, int c = 1)
        {
            return "[CQ:video,file=" + file + ",cover=" + cover + ",c=" + c + "]";
        }
        /// <summary>
        /// @某人
        /// </summary>
        /// <param name="qq">@的 QQ 号, all 表示全体成员</param>
        /// <param name="name">当在群中找不到此QQ号的名称时才会生效</param>
        /// <returns></returns>
        public static string At(long qq,string name = null)
        {
            return "[CQ:at,qq=" + qq + ",name=" + name + "]";
        }
        /// <summary>
        /// 链接分享
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="title">标题</param>
        /// <param name="content">发送时可选, 内容描述</param>
        /// <param name="image">发送时可选, 图片 URL</param>
        /// <returns></returns>
        public static string Share(string url,string title,string content = null,string image = null)
        {
            return "[CQ:share,url=" + url + ",title=" + title + ",content=" + content + ",image="+ image + "]";
        }
        /// <summary>
        /// 音乐分享
        /// </summary>
        /// <param name="type">分别表示使用 QQ 音乐、网易云音乐、虾米音乐</param>
        /// <param name="id">歌曲 ID</param>
        /// <returns></returns>
        public static string Music(string type, int id)
        {
            return "[CQ:music,type=" + type+ ",id=" + id + "]";
        }
        /// <summary>
        /// 音乐自定义分享
        /// </summary>
        /// <param name="url">点击后跳转目标 URL</param>
        /// <param name="audio">音乐 URL</param>
        /// <param name="title">标题</param>
        /// <param name="content">发送时可选, 内容描述</param>
        /// <param name="image">发送时可选, 图片 URL</param>
        /// <returns></returns>
        public static string Music(string url, string audio, string title, string content = null, string image = null)
        {
            return "[CQ:music,type=custom,url=" + url + ",audio=" + audio +  ",title=" + title + ",content=" + content + ",image=" + image + "]";
        }
        /// <summary>
        /// 图片
        /// </summary>
        /// <param name="file">图片文件名</param>
        /// <param name="type">图片类型, flash 表示闪照, show 表示秀图, 默认普通图片</param>
        /// <param name="subType">图片子类型, 只出现在群聊.</param>
        /// <param name="url">图片 URL</param>
        /// <param name="cache">只在通过网络 URL 发送时有效, 表示是否使用已缓存的文件, 默认 1</param>
        /// <param name="id">发送秀图时的特效id, 默认为40000</param>
        /// <param name="c">通过网络下载图片时的线程数, 默认单线程. (在资源不支持并发时会自动处理)</param>
        /// <returns></returns>
        public static string Image(string file, string type = null, int subType = 0, string url = null, int cache = 1, int id = 40000, int c = 1)
        {
            return "[CQ:image,file=" + file + ",type=" + type + ",subType=" + subType + ",url=" + url +",cache=" + cache + ",id=" + id + ",c=" + c + "]";
        }
        /// <summary>
        /// 回复
        /// </summary>
        /// <param name="id">回复时所引用的消息id, 必须为本群消息.</param>
        /// <param name="text">自定义回复的信息</param>
        /// <param name="qq">自定义回复时的自定义QQ, 如果使用自定义信息必须指定.</param>
        /// <returns></returns>
        public static string Reply(int id, string text, long qq = 0, long time = 0)
        {
            return "[CQ:reply,id=" + id + ",text=" + text + ",qq=" + qq + ",time=" + time + "]";
        }
        /// <summary>
        /// 戳一戳
        /// </summary>
        /// <param name="qq">需要戳的成员</param>
        /// <returns></returns>
        public static string Poke(long qq)
        {
            return "[CQ:poke,qq=" + qq + "]";
        }
        /// <summary>
        /// 礼物
        /// </summary>
        /// <param name="qq">接收礼物的成员</param>
        /// <param name="id">礼物的类型</param>
        /// <returns></returns>
        public static string Gift(long qq, int id)
        {
            return "[CQ:gift,qq=" + qq + ",id=" + id + "]";
        }
        /// <summary>
        /// 合并转发
        /// </summary>
        /// <param name="id">合并转发ID, 需要通过 /get_forward_msg API获取转发的具体内容</param>
        /// <returns></returns>
        public static string Forward(string id)
        {
            return "[CQ:forward,id=" + id + "]";
        }
        /// <summary>
        /// XML消息
        /// </summary>
        /// <param name="data">xml内容, xml中的value部分, 记得实体化处理</param>
        /// <returns></returns>
        public static string Xml(string data)
        {
            return "[CQ:xml,data=" + data + "]";
        }
        /// <summary>
        /// JSON消息
        /// </summary>
        /// <param name="data">json内容, json的所有字符串记得实体化处理(自动转义字符)</param>
        /// <returns></returns>
        public static string Json(string data) 
        {
            data = data
                .Replace(",", "&#44;")
                .Replace("&", "&amp;")
                .Replace("[", "&#91;")
                .Replace("]", "&#93;");
            return "[CQ:json,data=" + data + "]";
        }
        /// <summary>
        /// cardimage - 一种xml的图片消息（装逼大图）
        /// </summary>
        /// <param name="file">和image的file字段对齐, 支持也是一样的</param>
        /// <param name="minwidth">默认不填为400, 最小width</param>
        /// <param name="minheight">默认不填为400, 最小height</param>
        /// <param name="maxwidth">	默认不填为500, 最大width</param>
        /// <param name="maxheight">默认不填为1000, 最大height</param>
        /// <param name="source">分享来源的名称, 可以留空</param>
        /// <param name="icon">分享来源的icon图标url, 可以留空</param>
        /// <returns></returns>
        public static string cardimage(string file, long minwidth = 400, long minheight = 400, long maxwidth = 500, long maxheight = 1000, string source = "", string icon = "")
        {
            return "[CQ:cardimage,file=" + file + ",minwidth=" + minwidth + ",minheight=" + minheight + ",maxwidth=" + maxwidth + ",maxheight=" + maxheight + ",source=" + source + ",icon=" + icon + "]";
        }
    }
}
