using Flurl.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;
/// <summary>
/// 获取陌生人信息
/// </summa.ry>
public class StrangerInfo
{
    /// <summary>
    /// QQ 号
    /// </summary>
    public long qq { get; set; }
    /// <summary>
    /// 昵称
    /// </summary>
    public string nickname { get; set; }
    /// <summary>
    /// 性别, male 或 female 或 unknown
    /// </summary>
    public string sex { get; set; }
    /// <summary>
    /// 年龄
    /// </summary>
    public int age { get; set; }
    /// <summary>
    /// qid ID身份卡
    /// </summary>
    public string qid { get; set; }
    /// <summary>
    /// 等级
    /// </summary>
    public int level { get; set; }
    /// <summary>
    /// 等级
    /// </summary>
    public int login_days { get; set; }
}