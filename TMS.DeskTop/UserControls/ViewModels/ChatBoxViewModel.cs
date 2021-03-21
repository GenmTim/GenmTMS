using HandyControl.Controls;
using HandyControl.Tools;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TMS.Core.Data.Enums;
using TMS.Core.Event;

namespace TMS.DeskTop.UserControls.ViewModels
{
    public class ChatBoxViewModel : BindableBase
    {
        private readonly string _id = Guid.NewGuid().ToString();
        private readonly IEventAggregator eventAggregator;

        public ObservableCollection<ChatInfoModel> ChatInfos { get; set; } = new ObservableCollection<ChatInfoModel>();

        public DelegateCommand<RoutedEventArgs> ReadMessageCmd { get; private set; }
        public DelegateCommand<RoutedEventArgs> SendStringCmd { get; private set; }
        public DelegateCommand SendCmd { get; private set; }


        public ChatBoxViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<NotificationEvent>().Subscribe(ReceiveMessage);

            this.SendStringCmd = new DelegateCommand<RoutedEventArgs>(SendString);
            this.SendCmd = new DelegateCommand(Send);
            this.ReadMessageCmd = new DelegateCommand<RoutedEventArgs>(ReadMessage);
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
                SendString();
            }
        }

        private void SendString()
        {
            if (string.IsNullOrEmpty(ChatString)) return;
            var info = new ChatInfoModel
            {
                Message = ChatString,
                SenderId = _id,
                Type = ChatMessageType.String,
                Role = ChatRoleType.Other
            };
            ChatString = string.Empty;
            eventAggregator.GetEvent<NotificationEvent>().Publish(info);
        }


        private void ReadMessage(RoutedEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement element && element.Tag is ChatInfoModel info)
            {
                if (info.Type == ChatMessageType.Image)
                {
                    new ImageBrowser(new Uri(info.Enclosure.ToString()))
                    {
                        Owner = WindowHelper.GetActiveWindow()
                    }.Show();
                }
            }
        }


        /// <summary>
        /// 下方为测试用
        /// </summary>
        private string _chatString;

        public string ChatString
        {
            get { return _chatString; }
            set { _chatString = value; RaisePropertyChanged(); }
        }


        private void Send()
        {
            if (string.IsNullOrEmpty(ChatString)) return;
            var info = new ChatInfoModel
            {
                Message = ChatString,
                SenderId = _id,
                Type = ChatMessageType.String,
                Role = ChatRoleType.Me
            };
            ChatString = string.Empty;
            eventAggregator.GetEvent<NotificationEvent>().Publish(info);
        }



    }
}
