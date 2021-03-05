using Prism.Ioc;
using Prism_Test.ViewModels;
using Prism_Test.Views;
using System.Windows;

namespace Prism_Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<A, AModel>(Router.Instance[nameof(A)]);
            containerRegistry.RegisterForNavigation<A1>(Router.Instance[nameof(A1)]);
            containerRegistry.RegisterForNavigation<A2>(Router.Instance[nameof(A2)]);
            containerRegistry.RegisterForNavigation<B>(Router.Instance[nameof(B)]);
            containerRegistry.RegisterForNavigation<B1>(Router.Instance[nameof(B1)]);
            containerRegistry.RegisterForNavigation<B2>(Router.Instance[nameof(B2)]);
        }
    }
}
