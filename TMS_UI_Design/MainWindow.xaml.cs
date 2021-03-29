using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace TMS_UI_Design
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<String> dataList = new ObservableCollection<string>(){ "二十", "大受打击" };
        public ObservableCollection<string> DataList { get => dataList; set => dataList = value; }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            dayComponent.DataContext = new MultiValueComboBoxModel
            {
                OneValueList = new List<string> { "sadsd", "asdasd" }
            };
        }

    }
}
