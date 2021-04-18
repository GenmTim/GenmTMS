using System;

namespace TMS.Core.Data.Entity
{
    public class FileShard
    {
        /// <summary>
        /// id
        /// </summary>
        public long id;

        /// <summary>
        /// 相对路径
        /// </summary>
        public String path;

        /// <summary>
        /// 文件名
        /// </summary>
        public String name;

        /// <summary>
        /// 后缀
        /// </summary>
        public String suffix;

        /// <summary>
        /// 大小|字节B
        /// </summary>
        public int size;


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createdAt;

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime updatedAt;

        /// <summary>
        /// 已上传分片
        /// </summary>
        public int shardIndex;

        /// <summary>
        /// 分片大小|B
        /// </summary>
        public int shardSize;

        /// <summary>
        /// 分片总数
        /// </summary>
        public int shardTotal;

        /// <summary>
        /// 文件标识
        /// </summary>
        public String fileKey;
    }
}
