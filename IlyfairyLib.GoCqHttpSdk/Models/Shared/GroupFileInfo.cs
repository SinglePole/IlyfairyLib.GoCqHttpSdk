using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;

/// <summary>
/// 群文件信息
/// </summary>
public class GroupFileInfo
{
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 文件ID
    /// </summary>
    public string FileId { get; init; }
    /// <summary>
    /// 文件名
    /// </summary>
    public string FileName { get; init; }
    /// <summary>
    /// Busid
    /// </summary>
    public int Busid { get; init; }
    /// <summary>
    /// 文件大小
    /// </summary>
    public long FileSize { get; init; }
    /// <summary>
    /// 上传时间
    /// </summary>
    public DateTime UploadTime { get; init; }
    /// <summary>
    /// 过期时间
    /// </summary>
    public DateTime DeadTime { get; init; }
    /// <summary>
    /// 最后修改时间
    /// </summary>
    public DateTime ModifyTime { get; init; }
    /// <summary>
    /// 下载次数
    /// </summary>
    public int DownloadTimes { get; init; }
    /// <summary>
    /// 上传者QQ
    /// </summary>
    public long UploaderQQ { get; init; }
    /// <summary>
    /// 上传者名称
    /// </summary>
    public string UploaderName { get; init; }

    internal Lazy<Task<string>> fileUrlLazy;
    public async Task<string> GetFileUrl()
    {
        return await fileUrlLazy.Value;
    }

    internal GroupFileInfo(JToken json)
    {
        GroupId = json.Value<int>("group_id");
        FileId = json.Value<string>("file_id");
        FileName = json.Value<string>("file_name");
        Busid = json.Value<int>("busid");
        FileSize = json.Value<long>("file_size");
        UploadTime = DateTimeOffset.FromUnixTimeSeconds(json.Value<long>("upload_time")).DateTime;
        DeadTime = DateTimeOffset.FromUnixTimeSeconds(json.Value<long>("dead_time")).DateTime;
        ModifyTime = DateTimeOffset.FromUnixTimeSeconds(json.Value<long>("modify_time")).DateTime;
        DownloadTimes = json.Value<int>("download_times");
        UploaderQQ = json.Value<long>("uploader");
        UploaderName = json.Value<string>("uploader_name");
    }

    /// <summary>
    /// 比较两个文件是否相同
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(GroupFileInfo left , GroupFileInfo right)
    {
        return left.GroupId == right.GroupId
                && left.FileId == right.FileId;
    }

    /// <summary>
    /// 比较两个文件是否不相同
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(GroupFileInfo left , GroupFileInfo right)
    {
        return !(left == right);
    }
}

/// <summary>
/// 群文件夹信息
/// </summary>
public class GroupFolderInfo
{
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 文件夹ID
    /// </summary>
    public string FolderId { get; init; }
    /// <summary>
    /// 文件夹名称
    /// </summary>
    public string FolderName { get; init; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; init; }
    /// <summary>
    /// 创建者QQ
    /// </summary>
    public long CreatorQQ { get; init; }
    /// <summary>
    /// 创建者名称
    /// </summary>
    public string CreatorName { get; init; }
    /// <summary>
    /// 文件夹的文件个数
    /// </summary>
    public int TotalFileCount { get; init; }

    internal Lazy<Task<(GroupFolderInfo[] folders, GroupFileInfo[] files)>> subFileInfo;
    /// <summary>
    /// 获取文件夹里的所有 文件/文件夹
    /// </summary>
    /// <returns></returns>
    public async Task<(GroupFolderInfo[] folders, GroupFileInfo[] files)> GetSubFilesInfo()
    {
        return await subFileInfo.Value;
    }

    public GroupFolderInfo(JToken json)
    {
        GroupId = json.Value<int>("group_id");
        FolderId = json.Value<string>("folder_id");
        FolderName = json.Value<string>("folder_name");
        CreateTime = DateTimeOffset.FromUnixTimeSeconds(json.Value<long>("create_time")).DateTime;
        CreatorQQ = json.Value<long>("creator");
        CreatorName = json.Value<string>("creator_name");
        TotalFileCount = json.Value<int>("total_file_count");
    }

    /// <summary>
    /// 比较两个文件夹是否相同
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(GroupFolderInfo left, GroupFolderInfo right)
    {
        return left.GroupId == right.GroupId
                && left.FolderId == right.FolderId;
    }

    /// <summary>
    /// 比较两个文件夹是否不相同
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(GroupFolderInfo left, GroupFolderInfo right)
    {
        return !(left == right);
    }
}
