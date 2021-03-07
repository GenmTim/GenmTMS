using System;
using System.Windows;
using System.Windows.Input;
using TMS.Core.Api;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : Window
    {
        public string UserName { get; set; } = "";
        public string PassWord { get; set; } = "";

        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            IconHelper.RemoveIcon(this);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// 窗口最小化
        /// </summary>
        private void btn_min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized; //设置窗口最小化
        }

        /// <summary>
        /// 窗口最大化与还原
        /// </summary>
        private void btn_max_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal; //设置窗口还原
            }
            else
            {
                this.WindowState = WindowState.Maximized; //设置窗口最大化
            }
        }

        /// <summary>
        /// 窗口关闭
        /// </summary>
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = this.usernameBox.Text;
            string password = this.passwordBox.Password;


            HttpClient serviceApi = new HttpClient();

            //serviceApi.LoginUser("123456", "15858102098");



            DialogResult = true;
        }
    }
}
