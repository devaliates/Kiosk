namespace Kiosk.Entities.Concrete;

public class AVM
{
    public IEnumerable<KatPlani> Katlar { get; set; }

    public AVM(IEnumerable<KatPlani> katlar)
    {
        Katlar = katlar;
    }
}