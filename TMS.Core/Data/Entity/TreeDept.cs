using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Entity
{
	public class TreeDept
	{
        /// <summary>
        /// 部门ID
        /// </summary>
        [JsonProperty("deptId", NullValueHandling = NullValueHandling.Ignore)]
        public int? DeptId { get; set; }

        /// <summary>
        /// 企业ID
        /// </summary>
        [JsonProperty("companyId", NullValueHandling = NullValueHandling.Ignore)]
        public int? CompanyId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }

        /// <summary>
        /// 上级部门
        /// </summary>
        [JsonProperty("parentDept", NullValueHandling = NullValueHandling.Ignore)]
        public int? ParentDept { get; set; }

        /// <summary>
        /// 下级部门列表
        /// </summary>
        [JsonProperty("ChildDepartments", NullValueHandling = NullValueHandling.Ignore)]
        public List<TreeDept> ChildDepts { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("createAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateAt { get; set; }

        /// <summary>
        /// 最近更新时间
        /// </summary>
        [JsonProperty("updateAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdateAt { get; set; }
    }
}
