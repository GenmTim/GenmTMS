using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Entity
{
	public class Payroll
	{
		public Payroll()
		{
		}

		public Payroll(string name, string month, int number, float money, string currency, int unpublished, int published, int withdrawn, string createTime)
		{
			Name = name;
			Month = month;
			Number = number;
			Money = money;
			Currency = currency;
			Unpublished = unpublished;
			Published = published;
			Withdrawn = withdrawn;
			CreateTime = createTime;
		}

		public string Name { get; set; }

		public string Month { get; set; }

		public int Number { get; set; }

		public double Money { get; set; }

		public string Currency { get; set; }

		public int Unpublished { get; set; }

		public int Published { get; set; }

		public int Withdrawn { get; set; }

		public string CreateTime { get; set; }

	}
}
