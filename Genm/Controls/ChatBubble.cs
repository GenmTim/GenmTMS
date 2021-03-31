using Genm.Data;
using Genm.Data.Enums;
using HandyControl.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Genm.Controls
{
    public class ChatBubble : ContentControl
    {
        public static readonly DependencyProperty RoleProperty =
            DependencyProperty.Register("Role", typeof(ChatRoleType), typeof(ChatBubble), new PropertyMetadata(default(ChatRoleType)));
        public static readonly DependencyProperty TypeProperty = DependencyProperty.Register(
   "Type", typeof(ChatMessageType), typeof(ChatBubble), new PropertyMetadata(default(ChatMessageType)));
        public static readonly DependencyProperty IsReadProperty = DependencyProperty.Register(
"IsRead", typeof(bool), typeof(ChatBubble), new PropertyMetadata(ValueBoxes.FalseBox));

        public ChatRoleType Role
        {
            get { return (ChatRoleType)GetValue(RoleProperty); }
            set { SetValue(RoleProperty, value); }
        }
        public ChatMessageType Type
        {
            get => (ChatMessageType)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }
        public bool IsRead
        {
            get => (bool)GetValue(IsReadProperty);
            set => SetValue(IsReadProperty, ValueBoxes.BooleanBox(value));
        }
        public Action<object> ReadAction { get; set; }

        //protected override void OnSelected(RoutedEventArgs e)
        //{
        //    base.OnSelected(e);

        //    IsRead = true;
        //    ReadAction?.Invoke(Content);
        //}
    }
}
