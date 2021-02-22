using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TMS.DeskTop.UserControls
{
    /// <summary>
    /// FieldTypeCheckBox.xaml 的交互逻辑
    /// </summary>
    public partial class FieldTypeCheckBox : UserControl
    {
        public FieldTypeCheckBox()
        {
            InitializeComponent();
        }

        public List<String> typeList = new List<String> { "文本", "数字", "单选", "多选", "日期", "附件", "省市区" };
        public List<String> TypeList
        {
            get
            {
                return typeList;
            }
            set
            {
                typeList = value;
            }
        }


        public String Key
        {
            get { return (String)GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KeyProperty =
            DependencyProperty.Register("Key", typeof(String), typeof(FieldTypeCheckBox));
    }
}
