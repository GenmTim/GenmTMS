using HandyControl.Controls;
using HandyControl.Tools;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TMS.Core.Data.Enums;

namespace TMS.DeskTop.UserControls.ViewModels
{
    public class ChatBoxViewModel : BindableBase
    {
        private readonly string _id = Guid.NewGuid().ToString();

        public ChatBoxViewModel()
        {
            this.SendStringCmd = new DelegateCommand<RoutedEventArgs>(SendString);
            this.SendCmd = new DelegateCommand(Send);
            this.ReadMessageCmd = new DelegateCommand<RoutedEventArgs>(ReadMessage);
        }

        private void ReceiveMessage(ChatInfoModel info)
        {
            if (_id.Equals(info.SenderId)) return;
            info.Role = ChatRoleType.Receiver;
            ChatInfos.Add(info);
        }


        private string _chatString;

        public string ChatString
        {
            get { return _chatString; }
            set { _chatString = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<ChatInfoModel> ChatInfos { get; set; } = new ObservableCollection<ChatInfoModel>();

        public DelegateCommand<RoutedEventArgs> SendStringCmd { get; private set; }

        public DelegateCommand SendCmd { get; private set; }

        private void Send()
        {
            if (string.IsNullOrEmpty(ChatString)) return;
            var info = new ChatInfoModel
            {
                Message = ChatString,
                SenderId = _id,
                Type = ChatMessageType.String,
                Role = ChatRoleType.Sender
            };
            ChatInfos.Add(info);
            ChatString = string.Empty;
        }

        private void SendString()
        {
            if (string.IsNullOrEmpty(ChatString)) return;
            var info = new ChatInfoModel
            {
                Message = ChatString,
                SenderId = _id,
                Type = ChatMessageType.String,
                Role = ChatRoleType.Receiver
            };
            ChatInfos.Add(info);
            ChatString = string.Empty;
        }

        private void SendString(RoutedEventArgs e)
        {
            if (e is KeyEventArgs keyE && keyE.Key == Key.Enter)
            {
                SendString();
            }
        }

        public DelegateCommand<RoutedEventArgs> ReadMessageCmd { get; private set; }
        
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



    }
}
