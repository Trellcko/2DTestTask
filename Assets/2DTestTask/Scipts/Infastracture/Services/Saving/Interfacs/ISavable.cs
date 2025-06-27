namespace Trell.TwoDTestTask.Infrastructure.Saving
{
    public interface ISavable : IReadable
    {
        public void Save(SaveData saveData);
    }
}