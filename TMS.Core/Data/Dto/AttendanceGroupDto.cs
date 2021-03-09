using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Dto
{
	public class AttendanceGroupDto
	{
		/// <summary>
		/// 考勤组ID
		/// </summary>
		[JsonProperty("attendanceGroup_id")]
		public int AttendanceGroupId { get; set; }

		/// <summary>
		/// 考勤组名称
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 考勤班次
		/// </summary>
		[JsonProperty("attendance_shifts")]
		public string AttendanceShifts { get; set; }

		/// <summary>
		/// 考勤方式
		/// </summary>
		[JsonProperty("attendance_methods")]
		public string AttendanceMethods { get; set; }

		/// <summary>
		/// 所属企业
		/// </summary>
		[JsonProperty("company_id")]
		public int CompanyId { get; set; }

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
