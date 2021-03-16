using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.DeskTop.ViewModels.Register
{
    public struct Birthday
    {
        public int year;
        public int month;
    }

    public struct BasicInfo
    {
        public string Name { get; set; }
        public Birthday Birthday { get; set; }

    }

    public struct WorkExperience
    {
        public string FirstWorkTime { get; set; }
        public string NowJob { get; set; }
        public string NowCompany { get; set; }
        public string DescriptionNowJobContent { get; set; }
    }

    public struct EducationExperience
    {
        public string EducationBackground { get; set; }
        public string SchoolName { get; set; }
        public string Specialty { get; set; }
        public int EnrollmentTime { get; set; }
        public int GraduationTime { get; set; }
    }

    public struct InitialUserInfo
    {
         
    }

    public class QuestionViewModel
    {
    }
}
