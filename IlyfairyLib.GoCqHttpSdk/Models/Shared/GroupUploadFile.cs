using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;

public class GroupUploadFile
{
    /// <summary>
    /// 文件ID
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// 文件名
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 文件大小 ( 字节数 )
    /// </summary>
    public long Size { get; set; }
    /// <summary>
    /// busid ( 目前不清楚有什么作用 )
    /// </summary>
    public long BusId { get; set; }
}
