using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views.WorkPlace.ViolateData.Manager;
using TMS.DeskTop.Views.WorkPlace.ViolateData.Entering;

namespace TMS.DeskTop.ViewModels.WorkPlace.ViolateData.Manager
{
	public class ManageDataViewModel : BindableBase
	{
		private ObservableCollection<Violate> dataList= new ObservableCollection<Violate>() {
			new Violate{ Name="金泽权", Jobtitle="专员", DeptName="技术部", ViolateType="技术错误",Time="2021-03-07 17:29:21",
				Describe="在项目迁移过程中，中断一部分迁移，导致项目出错",Decision="重新迁移，记小错",Remark="无"},
			new Violate{ Name="蔡承龙", Jobtitle="程序", DeptName="技术部", ViolateType="技术错误",Time="2021-03-07 17:29:21",
				Describe="在接口对接时，接口对接错误，项目运行出错，导致莫名bug",Decision="重新对接，记小错",Remark="无"},
			new Violate{ Name="李冬富", Jobtitle="HR", DeptName="人事部", ViolateType="人事错误",Time="2021-03-07 17:29:21",
				Describe="在招聘过程中收取钱财，徇私舞弊",Decision="记大过，罚薪三月",Remark="无"}
		};
		public ObservableCollection<Violate> DataList
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
				RegionHelper.RequestNavigate(regionManager, RegionToken.ViolateDataEnteringContent, typeof(EnteringStepView));
			}
			else if (obj.Equals("ManageDataView"))
			{
				RegionHelper.RequestNavigate(regionManager, RegionToken.ViolateDataEnteringContent, typeof(ManageDataView));
			}
		}

	}
}
