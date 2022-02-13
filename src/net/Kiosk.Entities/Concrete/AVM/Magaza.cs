namespace Kiosk.Entities.Concrete;

public class Magaza
    : AVMElement
{
    public string Name { get; set; }

    public Magaza(Koordinat koordinat, string name, KatPlani bulunduguKat, string rengi)
        : base(koordinat, bulunduguKat, rengi)
        => this.Name = name;

    public Magaza(Koordinat koordinat, string name, string rengi)
        : base(koordinat, rengi)
        => this.Name = name;
}
