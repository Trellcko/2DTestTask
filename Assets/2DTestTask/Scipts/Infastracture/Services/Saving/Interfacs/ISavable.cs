namespace Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.Saving
{
    public interface ISavable : IReadable
    {
        public void Save(SaveData saveData);
    }
}