using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.Shared
{
    /// <summary>
    /// 群文件系统信息
    /// </summary>
    public record GroupFileSystemInfo()
    {
        public long GroupId { get; set; }

        /// <summary>
        /// 文件总数
        /// </summary>
        public int FileCount { get; init; }
        /// <summary>
        /// 文件上限
        /// </summary>
        public int LimitCount { get; init; }
        /// <summary>
        /// 已使用空间
        /// </summary>
        public long UsedSpace { get; init; }
        /// <summary>
        /// 空间上限
        /// </summary>
        public long TotalSpace { get; init; }

        internal GroupFileSystemInfo(long groupId, int fileCount, int limitCount, long usedSpace, long totalSpace) : this()
        {
            this.GroupId = groupId;
            this.FileCount = fileCount;
            this.LimitCount = limitCount;
            this.UsedSpace = usedSpace;
            this.TotalSpace = totalSpace;
        }
    }
}
