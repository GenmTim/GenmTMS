using Genm.Data.Enums;
using HandyControl.Controls;
using HandyControl.Tools;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TMS.Core.Api;
using TMS.Core.Data;
using TMS.Core.Data.Entity;
using TMS.Core.Event;
using TMS.DeskTop.Cache;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.UserControls.Common.ViewModels
{
    public class ChatBoxViewModel : BindableBase, INavigationAware
    {
        //private readonly string _id = Guid.NewGuid().ToString();
        private readonly IEventAggregator eventAggregator;

        public ObservableCollection<ChatInfoModel> ChatInfos { get; set; } = new ObservableCollection<ChatInfoModel>();

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
            this.SendStringCmd = new DelegateCommand<RoutedEventArgs>(SendString);
            //this.SendCmd = new DelegateCommand(Send);
            this.ReadMessageCmd = new DelegateCommand<RoutedEventArgs>(ReadMessage);

            eventAggregator.GetEvent<NotificationEvent>().Subscribe(ReceiveMessage);


        }

        // 数据消费者
        private void ReceiveMessage(object data)
        {
            ChatInfoModel info = (ChatInfoModel)data;
            ChatInfos.Add(info);
        }

        // 数据生成者
        private void SendString(RoutedEventArgs e)
        {
            if (e is KeyEventArgs keyE && keyE.Key == Key.Enter)
            {
                //SendString();
            }
        }

        //private void SendString()
        //{
        //    if (string.IsNullOrEmpty(ChatString)) return;
        //    var info = new ChatInfoModel
        //    {
        //        Message = ChatString,
        //        SenderId = _id,
        //        Type = ChatMessageType.String,
        //        Role = ChatRoleType.Other
        //    };
        //    ChatString = string.Empty;
        //    eventAggregator.GetEvent<NotificationEvent>().Publish(info);

        //    var dtoData = new NotificationData
        //    {
        //        Receiver = Data.User,
        //        //Sender = Session.User,
        //        Timestamp = TimeHelper.GetNowTimeStamp(),
        //        Data = ChatString
        //    };
        //}

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

        /// <summary>
        /// 下方为测试用
        /// </summary>



        //private void Send()
        //{
        //    if (string.IsNullOrEmpty(ChatString)) return;
        //    var info = new ChatInfoModel
        //    {
        //        Message = ChatString,
        //        SenderId = _id,
        //        Type = ChatMessageType.String,
        //        Role = ChatRoleType.Me
        //    };
        //    ChatString = string.Empty;
        //    eventAggregator.GetEvent<NotificationEvent>().Publish(info);
        //}

        #region Navigation
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var chatBoxData = navigationContext.Parameters.GetValue<ChatBoxContext>("ChatBoxContext");
            Context = chatBoxData;
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
