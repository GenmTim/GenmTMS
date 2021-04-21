using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Windows.Controls;
using TMS.Core.Api;
using TMS.Core.Event;

namespace TMS.DeskTop.Views.Register.Question
{
    public class QuestionEndPageModel : BindableBase
    {
        IEventAggregator eventAggregator;

        private bool isHasAvatar;
        public bool IsHasAvatar
        {
            get => isHasAvatar;
            set
            {
                isHasAvatar = value;
                RaisePropertyChanged();
            }
        }

        private string avatar;
        public string Avatar
        {
            get => avatar;
            set
            {
                avatar = value;
                RaisePropertyChanged();
            }
        }

        public QuestionEndPageModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.NextNavigateCmd = new DelegateCommand(GoNext);
            this.BackCmd = new DelegateCommand(GoBack);
            this.OpenFileCmd = new DelegateCommand(() =>
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = "Document"; // Default file name              
                dlg.DefaultExt = ".txt"; // Default file extension              
                dlg.Filter = "(*.jpg,*.png,*.jpeg,*.bmp,*.gif)|*.jgp;*.png;*.jpeg;*.bmp;*.gif|All files(*.*)|*.*"; // Filter files by extension                
                                                            // Show open file dialog box             
                Nullable<bool> result = dlg.ShowDialog();
                // Process open file dialog box results              
                if (result == true)
                {
                    Avatar = dlg.FileName;
                    IsHasAvatar = true;
                }
            });
        }


        public DelegateCommand OpenFileCmd { get; private set; }

        public DelegateCommand NextNavigateCmd { get; private set; }

        private void GoNext()
        {
            eventAggregator.GetEvent<JumpEvent>().Publish(null);
        }

        public DelegateCommand BackCmd { get; private set; }

        private void GoBack()
        {
            eventAggregator.GetEvent<JumpEvent>().Publish(new QuestionMainPage(eventAggregator));
        }
    }

    /// <summary>
    /// Question2View.xaml 的交互逻辑
    /// </summary>
    public partial class QuestionEndPage : UserControl
    {
        public QuestionEndPage(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.DataContext = new QuestionEndPageModel(eventAggregator);
        }

    }
}
