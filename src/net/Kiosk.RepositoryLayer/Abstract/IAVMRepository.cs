namespace Kiosk.RepositoryLayer.Abstract;

public interface IAVMRepository
{
    public Task<AVM> Get();
    public Task<IEnumerable<KioskElement>> GetAllKiosks();
    public Task<IEnumerable<Magaza>> GetAllMagaza();
    public Task<bool> AyniKatda(AVMElement aVMElement1, AVMElement aVMElement2);
    public Task<Merdiven> GetMerdiven(KatPlani katPlani);
    public Task<Asansor> GetAsansor(KatPlani katPlani);
}