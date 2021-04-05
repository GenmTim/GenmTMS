using Prism.Mvvm;
using TMS.Core.Data.VO.Notification;

namespace TMS.DeskTop.UserControls.Common.ViewModels.ChatBubbles
{
    public class Sender_ContacterRequestChatBubbleViewModel : BindableBase
    {
        public Sender_ContacterRequestChatBubbleViewModel()
        {

        }

        private string message;

        public string Message
        {
            get => message;
            set
            {
                message = value;
                RaisePropertyChanged();
            }
        }


        private ContactRequest contactRequest;
        public ContactRequest ContactRequest
        {
            get => contactRequest;
            set
            {
                contactRequest = value;
                switch (contactRequest.State)
                {
                    case (ContactRequestState.Accept):
                        Message = "对方已经同意你的申请";
                        break;
                    case (ContactRequestState.Refuse):
                        Message = "对方已经拒绝了你的申请";
                        break;
                    default:
                        Message = "正在等待对方的处理";
                        break;
                }
            }
        }

    }
}
