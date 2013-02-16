using System;
using System.Collections.Generic;
using Axum.Exception;
using Axum.Util;

namespace Axum.Io.Buffer
{
    public abstract class AbstractMessageBuf<T> : CustomQueue<T>, IMessageBuf<T>
    {
        private readonly int _maxCapacity;
        private int _referenceCounter;

        protected AbstractMessageBuf(int maxCapacity)
        {
            Guard.LessThanZero(maxCapacity, "maxCapacity: " + maxCapacity + " (expected: >= 0)");
            _maxCapacity = maxCapacity;
            _referenceCounter = 1;
        }

        public BufType Type()
        {
            return BufType.Message;
        }

        public int MaxCapacity()
        {
            return _maxCapacity;
        }

        protected abstract void Deallocate();

        public bool IsReadable()
        {
            return !IsEmpty();
        }

        public bool IsReadable(int size)
        {
            Guard.LessThanZero(size, "size: " + size + " (expected: >= 0)");

            return Count() <= _maxCapacity - size;
        }

        public bool IsWritable()
        {
            ;

            return Count() < _maxCapacity;
        }

        public bool IsWritable(int size)
        {
            Guard.LessThanZero(size, "size: " + size + " (expected: >= 0)");
            return Count() <= _maxCapacity - size;
        }

        public int RefCnt()
        {
            return _referenceCounter;
        }

        public int DrainTo(IEnumerable<T> c, int maxElements)
        {
            throw new NotImplementedException();
        }

        public IMessageBuf<T> Retain()
        {
            var refCnt = _referenceCounter;

            Guard.OutOfBufferRange(refCnt);

            _referenceCounter = refCnt + 1;
            return this;
        }

        public IMessageBuf<T> Retain(int increment)
        {
            Guard.LessThanZero(increment, "increment: " + increment + " (expected: > 0)");

            var refCnt = _referenceCounter;
            Guard.OutOfBufferRange(refCnt, increment);

            _referenceCounter = refCnt + increment;

            return this;
        }

        public bool Release()
        {
            var refCnt = _referenceCounter;
            Guard.OutOfBufferRange(refCnt);

            _referenceCounter = refCnt - 1;
            if (_referenceCounter == 0)
            {
                Deallocate();
                return true;
            }

            return false;
        }

        public bool Release(int decrement)
        {
            Guard.LessThanOrEqualToZero(decrement, "decrement: " + decrement + " (expected: > 0)");

            var refCnt = _referenceCounter;

            if (refCnt < decrement)
            {
                throw new IllegalBufferAccessException();
            }

            _referenceCounter = refCnt - decrement;
            if (_referenceCounter == 0)
            {
                Deallocate();
                return true;
            }

            return false;
        }

        public bool UnfoldAndAdd(object o)
        {
            throw new System.NotImplementedException();
        }

        public int DrainTo(IEnumerable<T> c)
        {
            throw new NotImplementedException();
        }


        public int DrainTo(IEnumerable<object> c)
        {
            throw new System.NotImplementedException();
        }

        public int DrainTo(IEnumerable<object> c, int maxElements)
        {
            throw new System.NotImplementedException();
        }

        protected void EnsureAccessible()
        {
            if (_referenceCounter <= 0)
            {
                throw new IllegalBufferAccessException();
            }
        }

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

        public new bool Add(T t)
        {
            return base.Add(t);
        }

    }
}