using System;
using System.Collections.Generic;
          
namespace Axum.Io.Buffer
{
    public abstract class AbstractMessageBuf<T> : Queue<T>, IMessageBuf<T>
    {
        private readonly int _maxCapacity;
        private int _refCnt = 1;

        protected AbstractMessageBuf(int maxCapacity)
        {
            Guard.LessThanZero(maxCapacity, "maxCapacity: " + maxCapacity + " (expected: >= 0)");
            _maxCapacity = maxCapacity;
        }

        public  BufType Type()
        {
            return BufType.Message;
        }

        public int MaxCapacity()
        {
            return _maxCapacity;
        }


        public abstract bool IsReadable();
        public abstract bool IsReadable(int size);
        public abstract bool IsWritable();
        public abstract bool IsWritable(int size);
        public int RefCnt()
        {
            return _refCnt;
        }

        public IMessageBuf<T> Retain()
        {
            var refCnt = _refCnt;

            Guard.OutOfBufferRange(refCnt);

            _refCnt = refCnt + 1;
            return this;
        }

        public  IMessageBuf<T> Retain(int increment)
        {
            Guard.LessThanZero(increment,"increment: " + increment + " (expected: > 0)");
            var refCnt = _refCnt;
            Guard.OutOfBufferRange(refCnt,increment);
            _refCnt = refCnt + increment;

            return this;
        }

        public bool Release()
        {
            throw new NotImplementedException();
        }

        public abstract bool Release(int decrement);

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

     
    }
}