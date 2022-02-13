namespace Kiosk.RepositoryLayer.Concrete;

public class AVMRepository
    : IAVMRepository
{
    private AVM avm;
    public AVM AVM
        => avm ??= Task.FromResult(this.GetAVM()).Result;

    public async Task<AVM> Get()
        => await Task.FromResult(AVM);

    private AVM GetAVM()
        => new AVM(GetKatlar());

    private IEnumerable<KatPlani> GetKatlar()
    {
        List<KatPlani> katlar = new List<KatPlani>()
        {
            new KatPlani(GetKat1Elements()),
            new KatPlani(GetKat2Elements()),
        };

        katlar[0].AVMElements.ToList().ForEach(e =>
        {
            e.SetBulunduguKat(katlar[0]);
        });

        katlar[1].AVMElements.ToList().ForEach(e =>
        {
            e.SetBulunduguKat(katlar[1]);
        });

        return katlar;
    }

    private IEnumerable<AVMElement> GetKat1Elements()
        => new List<AVMElement>
        {
            new KioskElement(new Koordinat(Koordinat.XStrings.F, 1), "Kiosk 1", "ff0000"),
            new KioskElement(new Koordinat(Koordinat.XStrings.K, 5), "Kiosk 2", "ff0000"),
            new KioskElement(new Koordinat(Koordinat.XStrings.F, 11), "Kiosk 3", "ff0000"),
            new Asansor(new Koordinat(Koordinat.XStrings.E,5), "0037ff"),
            new Merdiven(new Koordinat(Koordinat.XStrings.A, 5), "00ff21"),
            new Magaza(new Koordinat(Koordinat.XStrings.D, 3), "STB", "3e8210"),
            new Magaza(new Koordinat(Koordinat.XStrings.B, 7), "LCW", "00c9fc"),
            new Magaza(new Koordinat(Koordinat.XStrings.H, 7), "KTN", "515151"),
        };

    private IEnumerable<AVMElement> GetKat2Elements()
        => new List<AVMElement>
        {
            new Merdiven(new Koordinat(Koordinat.XStrings.A, 5), "00ff21"),
            new Asansor(new Koordinat(Koordinat.XStrings.E, 5), "0037ff"),
            new Magaza(new Koordinat(Koordinat.XStrings.C, 6), "BRG", "fc5a5a"),
        };

    public async Task<IEnumerable<KioskElement>> GetAllKiosks()
    {
        List<KioskElement> kiosklar = new List<KioskElement>();
        AVM.Katlar.ToList().ForEach(kat =>
        {
            kat.AVMElements.ToList().ForEach(element =>
            {
                if (element is KioskElement kioskElement && kioskElement is not null)
                    kiosklar.Add((KioskElement)element);
            });
        });

        return await Task.FromResult(kiosklar);
    }

    public async Task<IEnumerable<Magaza>> GetAllMagaza()
    {
        List<Magaza> magazalar = new List<Magaza>();

        AVM.Katlar.ToList().ForEach(kat =>
        {
            kat.AVMElements.ToList().ForEach(element =>
            {
                if (element is Magaza magaza)
                    magazalar.Add(magaza);
            });
        });

        return await Task.FromResult(magazalar);
    }

    public async Task<bool> AyniKatda(AVMElement aVMElement1, AVMElement aVMElement2)
    {
        return aVMElement1.BulunduguKat?.Id == aVMElement2.BulunduguKat?.Id
             ? await Task.FromResult(true)
             : await Task.FromResult(false);
    }

    public async Task<Merdiven> GetMerdiven(KatPlani katPlani)
        => await Task.FromResult(this.AVM.Katlar.First(kat => kat.Id == katPlani.Id).AVMElements.First(x => x is Merdiven) as Merdiven);
    public async Task<Asansor> GetAsansor(KatPlani katPlani)
       => await Task.FromResult(this.AVM.Katlar.First(kat => kat.Id == katPlani.Id).AVMElements.First(x => x is Asansor) as Asansor);
}
