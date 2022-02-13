namespace Kiosk.ServiceLayer.Abstract;

public interface IAVMService
    : IService
{
    public Task<AVM> Get();
    public Task<IEnumerable<Magaza>> GetAllMagaza();
}
