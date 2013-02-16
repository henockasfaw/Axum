using System.Collections.Concurrent;

namespace Axum.Util
{
    public abstract class CustomQueue<T> : ICustomQueue<T>
    {
        private readonly ConcurrentQueue<T> _concurrentQueue;

        protected CustomQueue()
        {
            _concurrentQueue = new ConcurrentQueue<T>();
        }

        public bool Add(T e)
        {
            _concurrentQueue.Enqueue(e);
            return true;
        }

        public bool Offer(T e)
        {
            throw new System.NotImplementedException();
        }

        public T Remove()
        {
            throw new System.NotImplementedException();
        }

        public T Poll()
        {
            throw new System.NotImplementedException();
        }

        public T Element()
        {
            throw new System.NotImplementedException();
        }

        public T Peek()
        {
            throw new System.NotImplementedException();
        }

        public bool IsEmpty()
        {
          return  _concurrentQueue.Count==0;
        }

        public int Count()
        {
            return _concurrentQueue.Count;
        }
    }
}