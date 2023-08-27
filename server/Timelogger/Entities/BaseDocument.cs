namespace Timelogger.Entities
{
    internal abstract class BaseDocument<T>
    {
        internal virtual T AsDTO()
        {
            return default(T);
        }
    }
}