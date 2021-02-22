using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Windows.Controls;


namespace TMS.DeskTop.UserControls
{

    public class PropertyNodeItem
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
    /// ChooseItemBox.xaml 的交互逻辑
    /// </summary>
    public partial class CheckItemPopup : UserControl
    {
        private ObservableCollection<PropertyNodeItem> checkedList = new ObservableCollection<PropertyNodeItem>();
        public ObservableCollection<PropertyNodeItem> CheckedList
        {
            get
            {
                return checkedList;
            }
            set
            {
                checkedList = value;
            }
        }

        public CheckItemPopup()
        {
            InitializeComponent();
            DataContext = this;
            ShowTreeView();
            checkedList.Add(new PropertyNodeItem
            {
                Name = "蔡承龙"
            });
            checkedList.Add(new PropertyNodeItem
            {
                Name = "金泽权"
            });
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
