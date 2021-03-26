using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TMS.Core.Data.Enums;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.ViewModels.WorkPlace.Evaluation;

namespace TMS.DeskTop.UserControls.Common.Views
{
    public class FieldData
    {
        public string Key { get; set; }
        public FieldType Type { get; set; } = FieldType.文本;
        public Boolean IsMust { get; set; }
        public DelegateCommand<FieldData> RemoveSelfCmd { get; set; }
        public DelegateCommand<FieldData> AppendNewFieldCmd { get; set; }
    }

    /// <summary>
    /// FieldTypeCheckBox.xaml 的交互逻辑
    /// </summary>
    public partial class FieldTypeCheckBox : UserControl
    {

        public FieldTypeCheckBox()
        {
            InitializeComponent();
        }
    }
}
