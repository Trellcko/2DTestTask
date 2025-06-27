namespace Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.Saving
{
    public interface ISaveService
    {
        SaveData Load();
        void Save();
    }
}