using System;

namespace Axum.Io.Buffer
{
    public sealed class DefaultMessageBuf<T> : AbstractMessageBuf<T> where T:new()
    {
        private const int MinInitialCapacity = 8;
        private static readonly T[] Placeholder = new T[2];
        private T[] _elements;
        private int _head;
        private int _tail;

        public DefaultMessageBuf()
            : base(MinInitialCapacity)
        {
            _elements =  Placeholder;
        }
        public DefaultMessageBuf(int maxCapacity)
            : base(maxCapacity)
        {
        }
      
        protected override void Deallocate()
        {
            throw new System.NotImplementedException();
        }
    }
}