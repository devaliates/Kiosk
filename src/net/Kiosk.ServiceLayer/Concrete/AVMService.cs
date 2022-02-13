namespace Kiosk.ServiceLayer.Concrete;

public class AVMService
    : IAVMService
{
    private readonly IAVMRepository aVMRepository;

    public AVMService(IAVMRepository aVMRepository)
        => this.aVMRepository = aVMRepository;

    public async Task<AVM> Get()
        => await this.aVMRepository.Get();

    public async Task<IEnumerable<Magaza>> GetAllMagaza()
        => await this.aVMRepository.GetAllMagaza();
}
