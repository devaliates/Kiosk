namespace Kiosk.UI.Wpf.ViewModels;

public class KioskViewModel
    : BaseViewModel
{
    private readonly IAVMService aVMService;
    private readonly IKioskService kioskService;
    private KioskElement kioskElement;
    private List<Magaza> magazalar;
    private string yol;

    public KioskElement KioskElement
    {
        get => kioskElement;
        init => SetProperty(ref kioskElement, value);
    }
    public List<Magaza> Magazalar
    {
        get => magazalar;
        init => SetProperty(ref magazalar, value);
    }
    public string Yol
    {
        get => yol;
        private set => SetProperty(ref yol, value);
    }

    public ICommand SelectMagazaCommand { get; init; }

    public KioskViewModel(KioskElement kioskElement, IAVMService aVMService, IKioskService kioskService)
    {
        KioskElement = kioskElement;
        this.aVMService = aVMService;
        this.kioskService = kioskService;
        this.Yol = "Gitmek istediğiniz mağazayı seçin.";

        this.SelectMagazaCommand = new Command(SelectMagaza);

        this.Magazalar = aVMService.GetAllMagaza().Result.ToList();
    }

    private void SelectMagaza(object obj)
    {
        Magaza magaza = obj as Magaza;
        //MessageBox.Show($"Magaza Adı: {magaza.Name} \nMağaza Id: {magaza.Id}");

        var path = this.kioskService.GetPath(this.kioskElement, magaza).Result;

        this.Yol = $"{kioskElement.Name} -> {magaza.Name}\n" +
            $"{path}";
    }
}
