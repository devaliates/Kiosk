namespace Kiosk.ServiceLayer.Abstract;

public interface IKioskService
    : IService
{
    public Task<string> GetPath(params AVMElement[] elements);
    public Task<IEnumerable<KioskElement>> GetAllKiosks();
}
