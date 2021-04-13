using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TMS.Core.Api;
using TMS.Core.Data.Dto;
using TMS.Core.Data.VO;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views;

namespace TMS.DeskTop.ViewModels
{

    public class UpdateMyCompanyItemList : PubSubEvent
    {

    }


    public class MainWindowViewModel : BaseDialogViewModel
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<MyCompanyItemVO> myCompanyList;
        public ObservableCollection<MyCompanyItemVO> MyCompanyList
        {
            get => myCompanyList;
            set
            {
                myCompanyList = value;
                RaisePropertyChanged();
            }
        }

        private MyCompanyItemVO nowCompanyEnv;
        public MyCompanyItemVO NowCompanyEnv
        {
            get => nowCompanyEnv;
            set
            {
                nowCompanyEnv = value;
                if (nowCompanyEnv != null)
                {
                    SessionService.Instance.NowCompanyInfo = nowCompanyEnv;
                }
                RaisePropertyChanged();
            }
        }

        private double windowWidth = 1224;
        public double WindowWidth { get => windowWidth; set { SetProperty(ref windowWidth, value); } }

        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IModuleCatalog moduleCatalog) : base(eventAggregator)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
            NavigationCmd = new DelegateCommand<string>(NavigationPage);

            eventAggregator.GetEvent<UpdateMyCompanyItemList>().Subscribe(async () =>
            {
                var result = await HttpService.GetConn().GetMyCompanyList();
                if (result.StatusCode == 200)
                {
                    List<CompanyDto> companyList = (List<CompanyDto>)result.Data;
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MyCompanyList ??= new ObservableCollection<MyCompanyItemVO>();
                        MyCompanyList.Clear();
                        companyList.ForEach((company) =>
                        {
                            MyCompanyList.Add(new MyCompanyItemVO
                            {
                                Id = (long)company.CompanyId,
                                Name = company.Name,
                            });
                        });
                    });
                }
            });
        }

        public DelegateCommand<string> NavigationCmd { get; private set; }

        private void NavigationPage(string viewName)
        {
            RouteHelper.Route(regionManager, typeof(MainWindow), Router.Instance.ConverterViewNameToType(viewName));
        }
    }
}
