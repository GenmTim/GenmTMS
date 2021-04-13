using System;
using System.Collections.Generic;
using System.Linq;

namespace login_test
{
    public class DateTimeSpace
    {
        public DateTime StartTime;
        public DateTime EndTime;

        //public DateTime FindInTimeSpacePosition(List<>, DateTime datetime)
        //      {

        //      }
    }


    static class TimeHelper
    {
        public static DateTime GetNowYearFirstWeekStart()
        {
            var datetime = new DateTime(DateTime.Today.Year, 1, 1);
            while (Convert.ToInt32(datetime.DayOfWeek.ToString("d")) != 1)
            {
                datetime = TimeHelper.NextDay(datetime);
            }
            Console.WriteLine(datetime.DayOfWeek.ToString("d"));
            return datetime;
        }

        public static DateTime NextDay(DateTime datetime)
        {
            return datetime.AddDays(1);
        }

        public static List<DateTimeSpace> GetYearAllWeakTimeSpace()
        {
            List<DateTimeSpace> timeSpaceOfWeakList = new List<DateTimeSpace>();
            var yearEnd = new DateTime(DateTime.Today.Year, 12, 31);

            var datetime = TimeHelper.GetNowYearFirstWeekStart();
            while (datetime <= yearEnd)
            {
                timeSpaceOfWeakList.Add(new DateTimeSpace { StartTime = datetime, EndTime = datetime.AddDays(6) });
                datetime = datetime.AddDays(7);
            }

            return timeSpaceOfWeakList;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = Day[Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"))].ToString();
            var datetime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            var nextDateTime = datetime.AddDays(1);

            var timeSpaceOfWeakList = TimeHelper.GetYearAllWeakTimeSpace();

            var findedVal = timeSpaceOfWeakList.FirstOrDefault((timespace) => { return timespace.StartTime <= datetime && datetime <= timespace.EndTime; });
            Console.WriteLine(findedVal.StartTime.ToString("yyyy-MM-dd"));

            //int index = 0;
            //foreach (var dateTimeSpace in weakDaySpace)
            //         {
            //	++index;
            //	Console.WriteLine("第{0}周，{1} - {2}", index, dateTimeSpace.StartTime.ToString("yyyy-MM-dd"), dateTimeSpace.EndTime.ToString("yyyy-MM-dd"));
            //         }
        }
    }
}
