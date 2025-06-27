namespace Trell.TwoDTestTask.Infrastructure.Saving
{
    public interface ISaveService
    {
        SaveData Load();
        void Save();
    }
}