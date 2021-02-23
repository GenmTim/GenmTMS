using Prism.Commands;
using Prism.Events;
using TMS.Core.Service;

namespace TMS.DeskTop.ViewModels.WorkPlace.Evaluation
{
    class NewEvaluationRuleViewModel
    {
        private readonly IDialogHostService dialogHost;
        private readonly IEventAggregator aggregator;

        public NewEvaluationRuleViewModel(IDialogHostService dialogHost, IEventAggregator aggregator)
        {
            this.dialogHost = dialogHost;
            this.aggregator = aggregator;
            this.ExecuteCommand = new DelegateCommand<string>(Execute);
        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }

        private void Execute(string obj)
        {
            switch (obj)
            {
                case "Save": NavigationPage("CheckItemDialog"); break;
            }
        }


        void NavigationPage(string pageName)
        {
            dialogHost.ShowDialog(pageName);
        }

    }
}
