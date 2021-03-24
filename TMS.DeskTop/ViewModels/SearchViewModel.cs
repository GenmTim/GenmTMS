using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Event;

namespace TMS.DeskTop.ViewModels
{
    public class SearchViewModel
    {
        private readonly IEventAggregator eventAggregator;

        public SearchViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.GoAuthCmd = new DelegateCommand(GoAuth);
        }

        public DelegateCommand GoAuthCmd { get; set; }
        private void GoAuth()
        {
            eventAggregator.GetEvent<SashEvent>().Publish("测试");
        }

    }
}
