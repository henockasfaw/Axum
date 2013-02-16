using System;
using System.Collections.Generic;

namespace Axum.Io.Buffer
{
    public abstract class AbstractMessageBuf<T> : Queue<T>, IMessageBuf<T>
    {
        private readonly int _maxCapacity;
        private int refCnt = 1;

        protected AbstractMessageBuf(int maxCapacity)
        {
            if (maxCapacity < 0)
            {
                throw new ArgumentException("maxCapacity: " + maxCapacity + " (expected: >= 0)");
            }

            _maxCapacity = maxCapacity;
        }

        public  BufType Type()
        {
           return  BufType.Message;
        }


        public int MaxCapacity()
        {
            return _maxCapacity;
        }

    
        public abstract bool IsReadable();
        public abstract bool IsReadable(int size);
        public abstract bool IsWritable();
        public abstract bool IsWritable(int size);
        public abstract IMessageBuf<T> Retain();
        public abstract IMessageBuf<T> Retain(int increment);
        public abstract bool UnfoldAndAdd(object o);
        public abstract int DrainTo(IEnumerable<T> c);
        public abstract int DrainTo(IEnumerable<T> c, int maxElements);

        IBuf IBuf.Retain()
        {
            return Retain();
        }

        IBuf IBuf.Retain(int increment)
        {
            return Retain(increment);
        }

        IReferenceCounted IReferenceCounted.Retain()
        {
            return Retain();
        }

        IReferenceCounted IReferenceCounted.Retain(int increment)
        {
            return Retain(increment);
        }

        public abstract bool Release();
        public abstract bool Release(int decrement);
    }
}