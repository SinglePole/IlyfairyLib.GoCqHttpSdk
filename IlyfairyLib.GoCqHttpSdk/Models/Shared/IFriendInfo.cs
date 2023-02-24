using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;

public interface IFriendInfo
{
    /// <summary>
    /// 发送请求的QQ号
    /// </summary>
    public long QQ { get; init; }
    /// <summary>
    /// 陌生人信息
    /// </summary>
    public StrangerInfo StrangerInfo { get; init; }
}
