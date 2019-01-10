namespace CPMS.BL.Factories
{
    public interface IBaseFactory<T>
    {
        T Identify(T item);
    }
}
