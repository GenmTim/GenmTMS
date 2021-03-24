using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Event;

namespace TMS.DeskTop.ViewModels.PersonalFile
{
    public class PersonalFileViewModel
    {
        private readonly IEventAggregator eventAggregator;

        public PersonalFileViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.GoBackCmd = new DelegateCommand(GoBack);
        }

        public DelegateCommand GoBackCmd { get; set; }
        private void GoBack()
        {
            eventAggregator.GetEvent<CloseSashEvent>().Publish();
        }
    }
}
