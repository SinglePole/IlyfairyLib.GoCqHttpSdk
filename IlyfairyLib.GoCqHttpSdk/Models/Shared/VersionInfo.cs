using Flurl.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;
/// <summary>
/// 版本信息
/// </summary>
public class VersionInfo
{
    /// <summary>
    /// 默认值 go-cqhttp，应用标识, 如 go-cqhttp 固定值
    /// </summary>
    public string app_name { get; set; }
    /// <summary>
    /// 应用版本, 如 v0.9.40-fix4
    /// </summary>
    public string app_version { get; set; }
    /// <summary>
    /// 应用完整名称
    /// </summary>
    public string app_full_name { get; set; }
    /// <summary>
    /// 默认值 v11, OneBot 标准版本 固定值
    /// </summary>
    public string protocol_version { get; set; }
    /// <summary>
    /// 固定值 pro, 原Coolq版本 固定值
    /// </summary>
    public string coolq_edition { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string coolq_directory { get; set; }
    /// <summary>
    /// 默认值 true，是否为go-cqhttp 固定值
    /// </summary>
    public bool go_cqhttp { get; set; }
    /// <summary>
    /// 默认值 4.15.0, 固定值
    /// </summary>
    public string plugin_version { get; set; }
    /// <summary>
    /// 默认值 99, 固定值
    /// </summary>
    public int plugin_build_number { get; set; }
    /// <summary>
    /// 默认值 release, 固定值
    /// </summary>
    public string plugin_build_configuration { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string runtime_version { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string runtime_os { get; set; }
    /// <summary>
    /// 应用版本, 如 v0.9.40-fix4
    /// </summary>
    public string version { get; set; }
    /// <summary>
    /// 默认值 0/1/2/3/-1, 当前登陆使用协议类型
    /// </summary>
    public int protocol { get; set; }
}
