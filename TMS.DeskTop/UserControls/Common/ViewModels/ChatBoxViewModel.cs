using Genm.Data;
using Genm.Data.Enums;
using HandyControl.Controls;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TMS.Core.Data;
using TMS.Core.Data.Entity;
using TMS.Core.Event.WebSocket;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.UserControls.Common.ViewModels
{
    public class ChatBoxViewModel : BindableBase, INavigationAware
    {
        //private readonly string _id = Guid.NewGuid().ToString();
        private readonly IEventAggregator eventAggregator;

        private ObservableCollection<ChatInfoModel> chatInfos;
        public ObservableCollection<ChatInfoModel> ChatInfos
        {
            get => chatInfos;
            set
            {
                chatInfos = value;
                RaisePropertyChanged();
            }
        }

        #region Property
        public DelegateCommand<RoutedEventArgs> ReadMessageCmd { get; private set; }
        public DelegateCommand<RoutedEventArgs> SendStringCmd { get; private set; }
        public DelegateCommand SendCmd { get; private set; }

        private ChatBoxContext _context;
        public ChatBoxContext Context
        {
            get => _context;
            set
            {
                _context = value;
                RaisePropertyChanged();
            }
        }

        private string _chatString;

        public string ChatString
        {
            get { return _chatString; }
            set { _chatString = value; RaisePropertyChanged(); }
        }

        #endregion

        public ChatBoxViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.SendStringCmd = new DelegateCommand<RoutedEventArgs>(SendMessage);
            this.ReadMessageCmd = new DelegateCommand<RoutedEventArgs>(ReadMessage);

            //this.SendCmd = new DelegateCommand(Send);
            //eventAggregator.GetEvent<NotificationEvent>().Subscribe(ReceiveMessage);
        }

        //// 数据消费者
        //private void ReceiveMessage(object data)
        //{
        //    ChatInfoModel info = (ChatInfoModel)data;
        //    ChatInfos.Add(info);
        //}

        // 数据生成者
        private void SendMessage(RoutedEventArgs e)
        {
            if (e is KeyEventArgs keyE && keyE.Key == Key.Enter)
            {
                if (string.IsNullOrEmpty(_chatString)) return;

                long timestamp = TimeHelper.GetNowTimeStamp();

                // 更新视图数据
                var chatInfo = new ChatInfoModel()
                {
                    Message = _chatString,
                    SenderId = (long)SessionService.User.UserId,
                    Role = ChatRoleType.Me,
                    Timestamp = timestamp,
                    Avatar = new Uri(SessionService.User.Avatar)
                };

                ChatInfos.Add(chatInfo);

                // 发送新数据
                var notificationData = new NotificationData()
                {
                    Sender = SessionService.User,
                    Receiver = Context.User,
                    Data = _chatString,
                    Timestamp = timestamp
                };

                eventAggregator.GetEvent<WebSocketSendEvent>().Publish(notificationData);
                ChatString = "";
            }
        }

        // 阅读消息事件
        private void ReadMessage(RoutedEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement element && element.Tag is ChatInfoModel info)
            {
                if (info.Type == ChatMessageType.Image)
                {
                    new ImageBrowser(new Uri(info.Enclosure.ToString()))
                    {
                        //Owner = WindowHelper.GetActiveWindow()
                    }.Show();
                }
            }
        }

        #region Navigation
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var chatBoxData = navigationContext.Parameters.GetValue<ChatBoxContext>("ChatBoxContext");
            Context = chatBoxData;
            ChatInfos = chatBoxData.ChatInfoList;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        #endregion
    }
}
