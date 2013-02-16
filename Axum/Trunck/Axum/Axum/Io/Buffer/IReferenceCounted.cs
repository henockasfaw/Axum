namespace Axum.Io.Buffer
{
    public interface IReferenceCounted
    {
        int RefCnt();
        IReferenceCounted Retain();
        IReferenceCounted Retain(int increment);
        bool Release(); 
        bool Release(int decrement); 
    }
}