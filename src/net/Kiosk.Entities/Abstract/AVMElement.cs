namespace Kiosk.Entities.Abstract;

public abstract class AVMElement
{
    public Guid Id { get; private set; }
    public Koordinat Koordinat { get; set; }
    public KatPlani? BulunduguKat { get; private set; }

    public string Rengi { get; private set; }

    protected AVMElement(Koordinat koordinat, string rengi)
    {
        this.Id = Guid.NewGuid();
        this.Koordinat = koordinat;
        this.Rengi = rengi;
    }

    protected AVMElement(Koordinat koordinat, KatPlani bulunduguKat, string rengi)
    {
        this.Id = Guid.NewGuid();
        this.Koordinat = koordinat;
        this.BulunduguKat = bulunduguKat;
        this.Rengi = rengi;
    }

    public void SetBulunduguKat(KatPlani bulunduguKat)
        => this.BulunduguKat = bulunduguKat;

    public void SetRenk(string renkKodu)
        => this.Rengi = renkKodu;
}
