using Kiosk.RepositoryLayer.Abstract;
using Kiosk.RepositoryLayer.Concrete;
using Kiosk.UI.Wpf.ViewModels;
using Kiosk.UI.Wpf.Views;

using Microsoft.Extensions.DependencyInjection;

namespace Kiosk.UI.Wpf;

public partial class App
    : Application
{
    private ServiceProvider serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        ServiceCollection services = new ServiceCollection();
        ConfigureServices(services);
        this.serviceProvider = services.BuildServiceProvider();
        base.OnStartup(e);
    }

    private void ConfigureServices(IServiceCollection services) 
        => services
        .AddSingleton<MainViewModel>()
            .AddSingleton<IAVMRepository, AVMRepository>()
            .AddSingleton<IAVMService, AVMService>()
            .AddSingleton<IKioskService, KioskService>();

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        this.MainWindow = new MainView();
        this.MainWindow.DataContext = this.serviceProvider.GetService<MainViewModel>();
        this.MainWindow.Show();
    }
}
