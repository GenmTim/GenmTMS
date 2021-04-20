using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Entity
{
	public class Attendance
	{
		public string Name { get; set; }

		public int AttendanceNumber { get; set; }

		public int ActualAttendance { get; set; }

		public int Late { get; set; }

		public int LeaveEarly { get; set; }

		public int Absent { get; set; }

		public int Repair { get; set; }

		public int Leave { get; set; }

	}
}
