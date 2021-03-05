using System;

namespace TMS.DeskTop.Tools.Helper
{
    class TimeHelper
    {
        public static readonly String DateFormat = "yyyy-MM-dd";
        /// <summary>
        /// 获取本地时间的世界时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetNowTimeStamp()
        {
            var TimeStamps = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
            return TimeStamps;
        }
        /// <summary>
        /// 将时间转换为时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long ToTimeStamp(DateTime dateTime)
        {
            var TimeStamps = (dateTime.Ticks - 621355968000000000) / 10000;
            return TimeStamps;
        }
        /// <summary>
        /// 获取本地时间的世界时间的偏移量
        /// </summary>
        /// <returns></returns>
        public static long GetUtcOffsets()
        {

            long UtcOffsets = TimeZoneInfo.Local.GetUtcOffset(new DateTime()).Ticks / 10000;
            return UtcOffsets;
        }

        /// <summary>
        /// 将时间戳转换为时间
        /// </summary>
        /// <returns></returns>
        public static DateTime ToDateTime(long TimeStamps)
        {
            var date = new DateTime(1970, 1, 1, 8, 0, 0).AddMilliseconds(TimeStamps);
            //new DateTime().AddMilliseconds(621355968000000000/10000).AddMilliseconds(TimeStamps);//效果同上
            return date;
        }

        public static int GetAgeByBirthdate(long birthdate)
        {
            return GetAgeByBirthdate(ToDateTime(birthdate));
        }

        public static int GetAgeByBirthdate(DateTime birthdate)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthdate.Year;
            if (now.Month < birthdate.Month || (now.Month == birthdate.Month && now.Day < birthdate.Day))
            {
                age--;
            }
            return age < 0 ? 0 : age;
        }


        public static DateTime StringToDatetime(string sdate)
        {
            return sdate == string.Empty ? Convert.ToDateTime("0001/1/1") : Convert.ToDateTime(sdate);
        }
    }
}
