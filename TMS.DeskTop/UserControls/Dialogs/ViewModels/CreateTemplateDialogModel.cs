using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Service;

namespace TMS.DeskTop.UserControls.Dialogs.ViewModels
{
    public class TemplateVO
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Content { get; set; }
        public string IconColor { get; set; }
    }


    class CreateTemplateDialogModel : BindableBase, IDialogHostAware
    {
        private ObservableCollection<TemplateVO> templateVOList;
        public ObservableCollection<TemplateVO> TemplateVOList
        {
            get => templateVOList;
            set
            {
                templateVOList = value;
                RaisePropertyChanged();
            }
        }


        public string IdentifierName { get; set; }

        public DelegateCommand SaveCmd { get; private set; }

        public DelegateCommand CancelCmd { get; private set; }

        public DelegateCommand<string> NavigationCmd { get; private set; }

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                RaisePropertyChanged();
            }
        }

        private string positiveText;
        public string PositiveText
        {
            get => positiveText;
            set
            {
                positiveText = value;
                RaisePropertyChanged();
            }
        }

        private string negativeText;
        public string NegativeText
        {
            get => negativeText;
            set
            {
                negativeText = value;
                RaisePropertyChanged();
            }
        }


        private string question;
        public string Question
        {
            get => question;
            set
            {
                question = value;
                RaisePropertyChanged();
            }
        }


        public CreateTemplateDialogModel()
        {
            this.SaveCmd = new DelegateCommand(() =>
            {
                DialogHost.Close(IdentifierName, new DialogResult(ButtonResult.OK));
            });

            this.CancelCmd = new DelegateCommand(() =>
            {
                DialogHost.Close(IdentifierName, new DialogResult(ButtonResult.Cancel));
            });
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
            TemplateVOList ??= new ObservableCollection<TemplateVO>()
            {
                new TemplateVO { Name="调查问卷员工工作状态调查", Content="工作成就感，工作职责，工作压力", Icon="\xe792", IconColor="#1890ff" },
                new TemplateVO { Name="公司每周工作汇报", Content="安排是否合理性，工作挑战性，工作完成情况", Icon="\xe705", IconColor="#13c2c2" },
                new TemplateVO { Name="每月工作汇报", Content="能力是否得到充分发挥，工作关系融洽度，工作职责", Icon="\xe70b", IconColor="#faad14" },
                new TemplateVO { Name="入职前员工调查问卷", Content="企业竞争优势、未来前景、制度是否健全、是否愿意长期工作", Icon="\xe782", IconColor="#fa541c" },
            };
        }

        private void NavigationPage(string view)
        {
            
        }

        public Task OnDialogOpenedAsync(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("title");
            PositiveText = parameters.GetValue<string>("positive_text");
            NegativeText = parameters.GetValue<string>("negative_text");
            Question = parameters.GetValue<string>("question");

            return Task.FromResult(true);
        }
    }
}
