namespace OptionsFramework
{
    public interface IOptionsWrapper<out T>
    {
        T GetOptions();
        void SaveOptions();
    }
}