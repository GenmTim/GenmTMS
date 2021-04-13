using Prism.Events;
using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using TMS.Core.Data.Token;
using TMS.Core.Data.VO.CloudFile;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.UserControls.Common.Views;
using static TMS.DeskTop.ViewModels.CloudFileViewModel;

namespace TMS.DeskTop.Views
{
    public class TreeViewItemMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var left = 0.0;
            UIElement element = value as TreeViewItem;
            while (element != null && element.GetType() != typeof(TreeView))
            {
                element = (UIElement)VisualTreeHelper.GetParent(element);
                if (element is TreeViewItem)
                    left += 12.0;
            }
            return new Thickness(left, 0, 0, 0);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// CloudFileView.xaml 的交互逻辑
    /// </summary>
    public partial class CloudFileView : RegionManagerControl
    {
        private readonly IEventAggregator eventAggregator;
        public CloudFileView(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, typeof(CloudFileView))
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
            this.Loaded += CloudFileView_Loaded;
            RegisterDefaultRegionView(RegionToken.CloudFileContent, nameof(EmptyContentView));
        }

        private void CloudFileView_Loaded(object sender, RoutedEventArgs e)
        {
            this.eventAggregator.GetEvent<UpdateFolderTreeEvent>().Publish();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (sender is TreeView treeView)
            {
                if (treeView.SelectedItem is FolderTreeNodeItemVO treeNodeItem)
                {
                    eventAggregator.GetEvent<UpdateFolderViewEvent>().Publish(treeNodeItem);
                }
            }
        }
    }
}
