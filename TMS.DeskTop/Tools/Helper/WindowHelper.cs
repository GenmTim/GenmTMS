using Genm.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TMS.DeskTop.Tools.Helper
{
    public static class WindowHelper
    {
        public static readonly DependencyProperty IsMaxWindow = DependencyProperty.RegisterAttached(
    "IsMaxTrigger", typeof(bool), typeof(WindowHelper), new PropertyMetadata(ValueBoxes.FalseBox, OnIsMaxTriggerChanged));

        public static void SetIsMaxTrigger(DependencyObject element, bool value)
            => element.SetValue(IsMaxWindow, ValueBoxes.BooleanBox(value));

        public static bool GetIsMaxTrigger(DependencyObject element)
            => (bool)element.GetValue(IsMaxWindow);

        private static void OnIsMaxTriggerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Button ctl)
            {
                if ((bool)e.NewValue)
                {
                    ctl.Click += GoMaximization;
                }
                else
                {
                    ctl.Click -= GoMaximization;
                }
            }
        }

        private static void GoMaximization(object sender, RoutedEventArgs e)
        {
            if (sender is DependencyObject obj)
            {
                System.Windows.Window window = System.Windows.Window.GetWindow(obj);
                if (System.Windows.Window.GetWindow(obj)?.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                }
                else
                {
                    window.WindowState = WindowState.Maximized;
                }
            }
        }

        public static readonly DependencyProperty IsTopBarMouseDown = DependencyProperty.RegisterAttached(
"IsTopBarMouseDown", typeof(bool), typeof(WindowHelper), new PropertyMetadata(ValueBoxes.FalseBox, OnIsTopBarMouseDownChanged));

        public static void SetIsTopBarMouseDown(DependencyObject element, bool value)
            => element.SetValue(IsTopBarMouseDown, ValueBoxes.BooleanBox(value));

        public static bool GetIsTopBarMouseDown(DependencyObject element)
            => (bool)element.GetValue(IsTopBarMouseDown);

        private static void OnIsTopBarMouseDownChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement ctl)
            {
                if ((bool)e.NewValue)
                {
                    ctl.MouseDown += TopBarMouseDown;
                }
                else
                {
                    ctl.MouseDown -= TopBarMouseDown;
                }
            }
        }

        private static int i = 0;

        private static void TopBarMouseDown(object sender, MouseButtonEventArgs e)
        {
            i += 1;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timer.Tick += (s, e1) => { timer.IsEnabled = false; i = 0; };
            timer.IsEnabled = true;

            if (i % 2 == 0)
            {
                timer.IsEnabled = false;
                i = 0;

                System.Windows.Window window = System.Windows.Window.GetWindow(sender as DependencyObject);
                window.WindowState = window.WindowState == WindowState.Maximized ?
                              WindowState.Normal : WindowState.Maximized;
            }
        }


        public static readonly DependencyProperty IsMinWindow = DependencyProperty.RegisterAttached(
"IsMinWindow", typeof(bool), typeof(WindowHelper), new PropertyMetadata(ValueBoxes.FalseBox, OnIsMinWindowChanged));

        public static void SetIsMinWindow(DependencyObject element, bool value)
            => element.SetValue(IsMinWindow, ValueBoxes.BooleanBox(value));

        public static bool GetIsMinWindow(DependencyObject element)
            => (bool)element.GetValue(IsMinWindow);

        private static void OnIsMinWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Button ctl)
            {
                if ((bool)e.NewValue)
                {
                    ctl.Click += GoMinimization;
                }
                else
                {
                    ctl.Click -= GoMinimization;
                }
            }
        }


        private static void GoMinimization(object sender, RoutedEventArgs e)
        {
            if (sender is DependencyObject obj)
            {
                System.Windows.Window window = System.Windows.Window.GetWindow(obj);
                window.WindowState = WindowState.Minimized;
            }
        }

        public static readonly DependencyProperty IsClose = DependencyProperty.RegisterAttached(
"IsClose", typeof(bool), typeof(WindowHelper), new PropertyMetadata(ValueBoxes.FalseBox, OnIsCloseChanged));

        public static void SetIsClose(DependencyObject element, bool value)
            => element.SetValue(IsMinWindow, ValueBoxes.BooleanBox(value));

        public static bool GetIsClose(DependencyObject element)
            => (bool)element.GetValue(IsMinWindow);

        private static void OnIsCloseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Button ctl)
            {
                if ((bool)e.NewValue)
                {
                    ctl.Click += GoClose;
                }
                else
                {
                    ctl.Click -= GoClose;
                }
            }
        }

        private static void GoClose(object sender, RoutedEventArgs e)
        {
            if (sender is DependencyObject obj)
            {
                System.Windows.Window window = System.Windows.Window.GetWindow(obj);
                window.Close();
            }
        }
    }
}
