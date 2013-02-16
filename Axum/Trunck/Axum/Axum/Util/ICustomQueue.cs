namespace Axum.Util 
{
    public interface ICustomQueue<T>
    {
        bool Add(T e);
        bool Offer(T e);
        T Remove();
        T Poll();
        T Element();
        T Peek();
        bool IsEmpty();
        int Count();
    }
}