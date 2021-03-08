﻿using Prism.Regions;
using System.Windows.Controls;

namespace Prism_Test.Views
{
    /// <summary>
    /// B1.xaml 的交互逻辑
    /// </summary>
    public partial class B1 : UserControl, INavigationAware
    {
        private readonly IRegionManager regionManager;

        public B1(IRegionManager regionManager)
        {
            InitializeComponent();
            this.regionManager = regionManager;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var go_url = navigationContext.Parameters.GetValue<string>("url");
            string now_url = Router.Instance[this.GetType().Name];
            int next_index = go_url.IndexOf('/', now_url.Length);
            string next_view = go_url.Substring(0, next_index + 1);

            NavigationParameters param = new NavigationParameters();
            param.Add("url", go_url);

            this.regionManager.RequestNavigate("b1_region", next_view, param);
        }
    }
}