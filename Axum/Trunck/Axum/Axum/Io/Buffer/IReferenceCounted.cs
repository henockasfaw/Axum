namespace Axum.Io.Buffer
{
    public interface IReferenceCounted
    {
        IReferenceCounted Retain();
        IReferenceCounted Retain(int increment);
        bool Release(); 
        bool Release(int decrement); 
    }
}