namespace Kiosk.ServiceLayer.Tools;

public static class KoordinatTools
{
    /// <summary>
    /// İki konum arasındaki en kısa yolun koordinatlarını verir.
    /// </summary>
    /// <param name="startPoint">Başlangıç konumu</param>
    /// <param name="endPoint">Varılacak konumu</param>
    /// <returns></returns>
    public static IEnumerable<Koordinat> GetKoordinatPoints(Koordinat startPoint, Koordinat endPoint)
    {
        // bulunduğu konumu
        Koordinat guncelKonum = new Koordinat(startPoint.X, startPoint.Y);
        // varılacak konum.
        Koordinat sonKonum = new Koordinat(endPoint.X, endPoint.Y);

        yield return new Koordinat(guncelKonum.X, guncelKonum.Y);

        int margeY = guncelKonum.Y - sonKonum.Y;

        if (margeY < 0) // sol
            do
            {
                yield return new Koordinat(guncelKonum.X, ++guncelKonum.Y);
            } while (guncelKonum.Y != sonKonum.Y);
        else if (margeY > 0) // sağ
            do
            {
                yield return new Koordinat(guncelKonum.X, --guncelKonum.Y);
            } while (guncelKonum.Y != sonKonum.Y);


        int margeX = guncelKonum.X - sonKonum.X;

        if (margeX < 0) // sol
            do
            {
                yield return new Koordinat(++guncelKonum.X, guncelKonum.Y);
            } while (guncelKonum.X != sonKonum.X);
        else if (margeX > 0) // sağ
            do
            {
                yield return new Koordinat(--guncelKonum.X, guncelKonum.Y);
            } while (guncelKonum.X != sonKonum.X);

        yield break;
    }
}