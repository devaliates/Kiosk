namespace Kiosk.ServiceLayer.Concrete;

public class KioskService
    : IKioskService
{
    private readonly IAVMRepository aVMRepository;

    public KioskService(IAVMRepository aVMRepository)
        => this.aVMRepository = aVMRepository;

    public async Task<IEnumerable<KioskElement>> GetAllKiosks()
        => await this.aVMRepository.GetAllKiosks();

    public async Task<string> GetPath(params AVMElement[] elements)
    {
        var path = string.Empty;

        foreach (var (item, index) in elements.ToList().Select((v, i) => (v, i)))
        {
            if (elements.Length == index + 1)
                break;

            List<Koordinat> gidilecekYol;

            if(await aVMRepository.AyniKatda(elements[index], elements[index + 1]))
            {
                KoordinatTools.GetKoordinatPoints(item.Koordinat, elements[index + 1].Koordinat)
                                             .ToList()
                                             .ForEach(yol => path += (yol.ToString() + ", "));
            }
            else
            {
                List<Koordinat> merdivenli = new List<Koordinat>();
                List<Koordinat> asansorlu = new List<Koordinat>();


                merdivenli.AddRange( KoordinatTools
                    .GetKoordinatPoints(item.Koordinat, (await aVMRepository.GetMerdiven(item.BulunduguKat)).Koordinat));
                merdivenli.Add(null);
                merdivenli.AddRange(KoordinatTools
                    .GetKoordinatPoints((await aVMRepository.GetMerdiven(elements[index + 1].BulunduguKat)).Koordinat, elements[index + 1].Koordinat));

                asansorlu.AddRange(KoordinatTools
                    .GetKoordinatPoints(item.Koordinat, (await aVMRepository.GetAsansor(item.BulunduguKat)).Koordinat));
                asansorlu.Add(null);
                asansorlu.AddRange(KoordinatTools
                    .GetKoordinatPoints((await aVMRepository.GetAsansor(elements[index + 1].BulunduguKat)).Koordinat, elements[index + 1].Koordinat));

                if(merdivenli.Count <= asansorlu.Count) // merdiven
                {
                    merdivenli.ForEach(yol =>
                    {
                        if (yol == null)
                            path += "Merdiveni Kullanınız, ";
                        else
                            path += yol.ToString() + ", ";
                    });
                }
                else // asansor
                {
                    asansorlu.ForEach(yol =>
                    {
                        if (yol == null)
                            path += "Asansörü Kullanınız, ";
                        else
                            path += yol.ToString() + ", ";
                    });
                }
            }
        }
        path = path.TrimEnd().TrimEnd(',');
        return await Task.FromResult(path);
    }
}