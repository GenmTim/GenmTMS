using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TMS.Core.Data;

namespace TMS.DeskTop.UserControls.Dialogs.Views.NewUserQuestions.BasicInfo
{
    /// <summary>
    /// Question1View.xaml 的交互逻辑
    /// </summary>
    public partial class Question1Page : UserControl
    {
        public Question1Page(IRegionManager regionManager)
        {
            InitializeComponent();

            this.NextNavigateCmd = new DelegateCommand(() =>
            {
                regionManager.RegisterViewWithRegion(RegionToken.QuestionContent, typeof(QuestionMainPage));
            });
        }

        public DelegateCommand NextNavigateCmd { get; set; }
    }
}
