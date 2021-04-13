
using Prism.Mvvm;
using TMS.Core.Data.Entity;
using TMS.Core.Data.VO;

namespace TMS.Core.Service
{
    public class SessionService : BindableBase
    {
        private static SessionService instance;

        public static SessionService Instance
        {
            get
            {
                instance ??= new SessionService();
                return instance;
            }
        }

        private SessionService() { }

        private User user;
        public User User
        {
            get => user;
            set
            {
                user = value;
                RaisePropertyChanged();
            }
        }

        private MyCompanyItemVO nowCompanyInfo;
        public MyCompanyItemVO NowCompanyInfo
        {
            get => nowCompanyInfo;
            set
            {
                nowCompanyInfo = value;
                RaisePropertyChanged();
            }
        }
    }
}
