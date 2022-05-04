using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;

/// <summary>
/// 群信息
/// </summary>
public record class GroupInfo
{
    /// <summary>
    /// 群号
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// 群名
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 群备注
    /// </summary>
    public string Memorandum { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public int CreateTime { get; set; }
    /// <summary>
    /// 群等级
    /// </summary>
    public int Level { get; set; }
    /// <summary>
    /// 成员数
    /// </summary>
    public int MemberCount { get; set; }
    /// <summary>
    /// 群容量
    /// </summary>
    public int MaxMemberCount { get; set; }

    /// <summary>
    /// 获取群头像图片链接
    /// </summary>
    /// <returns></returns>
    public string GetAvatarUrl()
    {
        return $"https://p.qlogo.cn/gh/{Id}/{Id}/640";
    }
}
