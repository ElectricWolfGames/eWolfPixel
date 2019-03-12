namespace eWolfPixelStandard.Interfaces
{
    public interface ISaveable
    {
        string GetFileName { get; }

        void Save(string projectPath);
    }
}
