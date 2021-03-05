using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Windows;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.ViewModels;

namespace TMS.DeskTop.Views
{
    internal class PropertyNodeItem
    {
        public string Icon { get; set; }
        public string Name { get; set; }

        public List<PropertyNodeItem> Children { get; set; }
        public PropertyNodeItem()
        {
            Children = new List<PropertyNodeItem>();
        }
    }


    /// <summary>
    /// ContactsView.xaml 的交互逻辑
    /// </summary>
    public partial class ContactsView : RegionManagerControl
    {
        ContactsViewModel vm = new ContactsViewModel();


        public ContactsView(IRegionManager regionManager) : base(regionManager, nameof(ContactsView))
        {
            InitializeComponent();
            Console.WriteLine(toggleBtn.IsChecked);
            this.DataContext = vm;
            ShowTreeView();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            mainGrid.ColumnDefinitions[0].Width = new GridLength(80);
            Console.WriteLine(vm.ToggleBtnIsChecked);
            e.Handled = true;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            mainGrid.ColumnDefinitions[0].Width = new GridLength(200);
            Console.WriteLine(vm.ToggleBtnIsChecked);
            e.Handled = true;
        }


        private void ShowTreeView()
        {
            List<PropertyNodeItem> itemList = new List<PropertyNodeItem>();
            PropertyNodeItem node1 = new PropertyNodeItem()
            {
                Name = "研发部"
            };
            PropertyNodeItem node1tag1 = new PropertyNodeItem()
            {
                Name = "研发一部"
            };
            node1.Children.Add(node1tag1);

            PropertyNodeItem node2 = new PropertyNodeItem()
            {
                Name = "财政部"
            };
            PropertyNodeItem node2tag1 = new PropertyNodeItem()
            {
                Name = "财政一部"
            };
            node2.Children.Add(node2tag1);

            PropertyNodeItem node3 = new PropertyNodeItem()
            {
                Name = "客服部"
            };
            PropertyNodeItem node3tag1 = new PropertyNodeItem()
            {
                Name = "客服一部"
            };
            PropertyNodeItem node3tag2 = new PropertyNodeItem()
            {
                Name = "客服二部"
            };
            node3.Children.Add(node3tag1);
            node3.Children.Add(node3tag2);


            itemList.Add(node1);
            itemList.Add(node2);
            itemList.Add(node3);

            this.tvProperties.ItemsSource = itemList;
        }
    }
}
