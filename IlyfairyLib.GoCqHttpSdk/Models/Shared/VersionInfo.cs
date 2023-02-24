using Flurl.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;
/// <summary>
/// �汾��Ϣ
/// </summary>
public class VersionInfo
{
    /// <summary>
    /// Ĭ��ֵ go-cqhttp��Ӧ�ñ�ʶ, �� go-cqhttp �̶�ֵ
    /// </summary>
    public string app_name { get; set; }
    /// <summary>
    /// Ӧ�ð汾, �� v0.9.40-fix4
    /// </summary>
    public string app_version { get; set; }
    /// <summary>
    /// Ӧ����������
    /// </summary>
    public string app_full_name { get; set; }
    /// <summary>
    /// Ĭ��ֵ v11, OneBot ��׼�汾 �̶�ֵ
    /// </summary>
    public string protocol_version { get; set; }
    /// <summary>
    /// �̶�ֵ pro, ԭCoolq�汾 �̶�ֵ
    /// </summary>
    public string coolq_edition { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string coolq_directory { get; set; }
    /// <summary>
    /// Ĭ��ֵ true���Ƿ�Ϊgo-cqhttp �̶�ֵ
    /// </summary>
    public bool go_cqhttp { get; set; }
    /// <summary>
    /// Ĭ��ֵ 4.15.0, �̶�ֵ
    /// </summary>
    public string plugin_version { get; set; }
    /// <summary>
    /// Ĭ��ֵ 99, �̶�ֵ
    /// </summary>
    public int plugin_build_number { get; set; }
    /// <summary>
    /// Ĭ��ֵ release, �̶�ֵ
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
    /// Ӧ�ð汾, �� v0.9.40-fix4
    /// </summary>
    public string version { get; set; }
    /// <summary>
    /// Ĭ��ֵ 0/1/2/3/-1, ��ǰ��½ʹ��Э������
    /// </summary>
    public int protocol { get; set; }
}
