using Genm.Controls;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TMS.DeskTop.ViewModels.WorkPlace.Report
{
	public class ReportMainViewModel : BindableBase
	{

		private List<CheckTreeView> treeViewData;
		public List<CheckTreeView> TreeViewData
		{
			get => treeViewData;
			set
			{
				treeViewData = value;
				RaisePropertyChanged();
			}
		}

		private ObservableCollection<string> dataList = new ObservableCollection<string>();
		public ObservableCollection<string> DataList { get => dataList; set => dataList = value; }

		public ReportMainViewModel()
		{
			SimulationData();
		}


		private void SimulationData()
		{
			var treeRoot = new List<CheckTreeView>();

			CheckTreeView item = new CheckTreeView()
			{
				Id = 1,
				StateChange = UpdateState,
				Content = new TextBlock { Text = "测试" }
			};

			CheckTreeView subItem1 = new CheckTreeView()
			{
				Id = 2,
				StateChange = UpdateState,
				Content = new TextBlock { Text = "测试" }

			};
			CheckTreeView subItem2 = new CheckTreeView()
			{
				Id = 3,
				StateChange = UpdateState,
				Content = new TextBlock { Text = "测试" }
			};
			CheckTreeView item2 = new CheckTreeView()
			{
				Id = 4,
				StateChange = UpdateState,
				Content = new TextBlock { Text = "测试" }
			};
			item.Add(subItem1);
			item.Add(subItem2);
			treeRoot.Add(item);
			treeRoot.Add(item2);

			TreeViewData = treeRoot;
		}

		private void UpdateState(CheckTreeView data)
		{
			if (data.IsChecked != null && (bool)data.IsChecked)
            {
				if (data.Children == null)
                {
					DataList.Add(data.Id.ToString());
				}
			}
			else
            {
				DataList.Remove(data.Id.ToString());
            }
        }


	}
}
