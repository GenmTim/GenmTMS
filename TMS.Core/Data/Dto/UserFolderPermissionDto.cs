using Newtonsoft.Json;
using System;

namespace TMS.Core.Data.Dto
{
    public class UserFolderPermissionDto
    {
        /// <summary>
        /// id
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }

        /// <summary>
        /// 文件夹id
        /// </summary>
        [JsonProperty("folder_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? FolderId { get; set; }

        /// <summary>
        /// 拥有权限用户id
        /// </summary>
        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? UserId { get; set; }

        /// <summary>
        /// 权限id
        /// </summary>
        [JsonProperty("permission_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? PermissionId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("create_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateAt { get; set; }

        /// <summary>
        /// 最近更新时间
        /// </summary>
        [JsonProperty("update_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdateAt { get; set; }
    }
}
