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
using TMS.DeskTop.Views.WorkPlace.GloryData.Manager;
using TMS.DeskTop.Views.WorkPlace.GloryData.Entering;

namespace TMS.DeskTop.ViewModels.WorkPlace.GloryData.Manager
{
	public class ManageDataViewModel : BindableBase
	{
		private ObservableCollection<Glory> dataList = new ObservableCollection<Glory>() {
			new Glory{ Name="金泽权", Jobtitle="专员", DeptName="技术部", GloryType="司外荣誉",Time="2021-02-07 09:29:21",
				Deeds="在来公司途中，遇到有人被车撞，帮助送到医院",Remark="无"},
			new Glory{ Name="夏晓瑜", Jobtitle="设计顾问", DeptName="产品部", GloryType="决策荣誉",Time="2021-02-26 09:29:21",
				Deeds="在公司面临项目决策困难时，找到更利公司的方式",Remark="无"}
		};
		public ObservableCollection<Glory> DataList
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
				RegionHelper.RequestNavigate(regionManager, RegionToken.GloryDataEnteringContent, typeof(EnteringStepView));
			}
			else if (obj.Equals("ManageDataView"))
			{
				RegionHelper.RequestNavigate(regionManager, RegionToken.GloryDataEnteringContent, typeof(ManageDataView));
			}
		}
	}
}
