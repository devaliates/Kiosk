namespace Kiosk.Entities.Concrete;

public class KatPlani
{
    public Guid Id { get; init; }

    public IEnumerable<AVMElement> AVMElements { get; set; }

    public KatPlani(IEnumerable<AVMElement> aVMElements)
    {
        this.Id = Guid.NewGuid();
        AVMElements = aVMElements;
    }
}
