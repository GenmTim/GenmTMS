using System;
using System.Windows.Controls;
using TMS.Core.Data;

namespace TMS.DeskTop.Views.WorkPlace
{
    /// <summary>
    /// WorkPlaceMainView.xaml 的交互逻辑
    /// </summary>
    public partial class WorkPlaceMainView : UserControl, IDisposable
    {
        private TabItemInfo tagItemInfo = new TabItemInfo { IsMust = true };
        public TabItemInfo TagItemInfo { get => tagItemInfo; set => tagItemInfo = value; }

        public WorkPlaceMainView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
        }
    }
}
