using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views.WorkPlace.PerformanceData.Manager;
using TMS.DeskTop.Views.WorkPlace.PerformanceData.Entering;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Prism.Regions;
using Prism.Commands;

namespace TMS.DeskTop.ViewModels.WorkPlace.PerformanceData.Manager
{
	public class ManageDataViewModel : BindableBase
	{
		private ObservableCollection<Performance> dataList = new ObservableCollection<Performance>() {
			new Performance{ Name="金泽权", PerformanceLevel="A-"},
			new Performance{ Name="蔡承龙", PerformanceLevel="A"},
			new Performance{ Name="李冬富", PerformanceLevel="B-"},
			new Performance{ Name="夏晓瑜", PerformanceLevel="B+"},
			new Performance{ Name="江益川", PerformanceLevel="C-"},
			new Performance{ Name="方汉易", PerformanceLevel="D"},
			//new Performance{ Name="黎星画", PerformanceLevel="B"},
			//new Performance{ Name="沈玉华", PerformanceLevel="C+"},
			//new Performance{ Name="黄军达", PerformanceLevel="C"},
			//new Performance{ Name="萧筱默", PerformanceLevel="A+"}
		};
		public ObservableCollection<Performance> DataList
		{
			get => dataList;
			set
			{
				dataList = value;
				RaisePropertyChanged();
			}
		}

		private readonly IRegionManager regionManager;

		public ManageDataViewModel(IRegionManager regionManager)
		{
			this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
			this.regionManager = regionManager;
		}

		public DelegateCommand<string> NavigationCmd { get; private set; }

		private void NavigationPage(string obj)
		{
			if (obj == null)
			{
				return;
			}
			if (obj.Equals("EnteringStepView"))
			{
				RegionHelper.RequestNavigate(regionManager, RegionToken.PerformanceDataEnteringContent, typeof(EnteringStepView));
			}
			else if (obj.Equals("ManageDataView"))
			{
				RegionHelper.RequestNavigate(regionManager, RegionToken.PerformanceDataEnteringContent, typeof(ManageDataView));
			}
		}

	}
}
