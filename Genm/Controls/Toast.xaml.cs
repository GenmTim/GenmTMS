﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Genm.Controls
{
    public partial class Toast : ContentControl
    {
        //User-Changeable Values
        public string Message { get; set; }
        public TimeSpan Duration { get; set; } = TimeSpan.FromSeconds(2);
        public TimeSpan DurationAnimation { set; get; } = TimeSpan.FromMilliseconds(300);
        public ToastDuration DurationToast
        {
            set
            {
                Duration = ToastDurationToTimeSpan(value);
                _internalDurationToast = value;
            }
            get
            {
                return _internalDurationToast;
            }
        }

        public new object Content
        {
            set
            {
                Message = value as string;
            }
            get
            {
                return Message;
            }
        }

        public enum ToastDuration { Short, Medium, Long }

        private ToastDuration _internalDurationToast;
        private Thread _waitThread;

        public Toast()
        {
            InitializeComponent();
            this.Opacity = 0;
        }


        public void Show(string message, TimeSpan duration)
        {
            ToastContent.Text = message;

            try
            {
#pragma warning disable SYSLIB0006 // 类型或成员已过时
                _waitThread?.Abort();
#pragma warning restore SYSLIB0006 // 类型或成员已过时
            }
            catch (Exception) { }


            DoubleAnimation anim = new DoubleAnimation(0d, 1d, this.DurationAnimation);

            anim.Completed += delegate {
                DelayedClose();
            };


            if (this.Opacity > 0)
            {
                DoubleAnimation fadeOut = new DoubleAnimation(this.Opacity, 0d, TimeSpan.FromMilliseconds(150));

                fadeOut.Completed += delegate {
                    this.BeginAnimation(UserControl.OpacityProperty, anim);
                };

                this.BeginAnimation(UserControl.OpacityProperty, fadeOut);
            }
            else
            {
                this.BeginAnimation(UserControl.OpacityProperty, anim);
            }
        }

        public void Show()
        {
            Show(this.Message, this.Duration);
        }

        public void Show(string message)
        {
            Show(message, this.Duration);
        }

        public void Show(TimeSpan duration)
        {
            Show(this.Message, duration);
        }

        public void Show(ToastDuration duration)
        {
            Show(this.Message, ToastDurationToTimeSpan(duration));
        }

        public void Hide()
        {
            DoubleAnimation anim = new DoubleAnimation(this.Opacity, 0d, this.DurationAnimation);
            this.BeginAnimation(UserControl.OpacityProperty, anim);
        }

        private void DelayedClose()
        {
            _waitThread = new Thread(() => {
                try
                {
                    Thread.Sleep(this.Duration);

                    Application.Current.Dispatcher.Invoke(() => {
                        Hide();
                    });
                }
                catch (Exception) { }
            });
            _waitThread.Start();
        }

        private TimeSpan ToastDurationToTimeSpan(ToastDuration tduration)
        {
            TimeSpan ret = Duration;

            switch (tduration)
            {
                case ToastDuration.Short:
                    ret = TimeSpan.FromSeconds(2);
                    break;
                case ToastDuration.Medium:
                    ret = TimeSpan.FromSeconds(3);
                    break;
                case ToastDuration.Long:
                    ret = TimeSpan.FromSeconds(4);
                    break;
            }

            return ret;
        }
    }
}
