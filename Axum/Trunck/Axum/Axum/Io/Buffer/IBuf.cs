using System.Collections.Generic;

namespace Axum.Io.Buffer
{
    public interface IBuf : IReferenceCounted
    {
        BufType Type();
        int MaxCapacity();
        bool IsReadable();
        bool IsReadable(int size);
        bool IsWritable();
        bool IsWritable(int size);
        new IBuf Retain();
        new IBuf Retain(int increment);
    }
}