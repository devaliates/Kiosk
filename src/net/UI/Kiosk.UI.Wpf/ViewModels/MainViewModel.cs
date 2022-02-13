namespace Kiosk.UI.Wpf.ViewModels;

public class MainViewModel
    : BaseViewModel
{
    private KioskViewModel view;
    private List<BaseViewModel> kioskViews;

    public KioskViewModel View
    {
        get => view;
        private set => SetProperty(ref view, value);
    }

    public List<BaseViewModel> KioskViews 
    { 
        get => kioskViews;
        init => SetProperty(ref kioskViews, value);
    }
    
    public ICommand KioskOpenCommand { get; private set; }

    public MainViewModel(IKioskService kioskService,
                         IAVMService aVMService)
    {
        KioskOpenCommand = new Command(KioskOpen);
        KioskViews = new List<BaseViewModel>();

        KioskInit(kioskService.GetAllKiosks().Result, aVMService, kioskService);
    }

    private void KioskInit(IEnumerable<KioskElement> kiosks, IAVMService aVMService, IKioskService kioskService)
        => kiosks.ToList().ForEach(kiosk =>
            {
                this.KioskViews.Add(new KioskViewModel(kiosk, aVMService, kioskService));
            });

    private void KioskOpen(object obj)
        => this.View = (KioskViewModel)obj;
}
