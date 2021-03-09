using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class AttendancePrincipalDto
	{
		/// <summary>
		/// 考勤组ID
		/// </summary>
		[JsonProperty("attendanceGroup_id")]
		public int AttendanceGroupId { get; set; }

		/// <summary>
		/// 负责人的用户ID
		/// </summary>
		[JsonProperty("principal_id")]
		public int PrincipalId { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[JsonProperty("create_at")]
		public DateTime CreateAt { get; set; }

		/// <summary>
		/// 最近更新时间
		/// </summary>
		[JsonProperty("update_at")]
		public DateTime UpdateAt { get; set; }
	}
}
