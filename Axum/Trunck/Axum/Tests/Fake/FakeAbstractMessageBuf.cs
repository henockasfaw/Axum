using System.Collections.Generic;
using Axum.Io.Buffer;

namespace Tests.Fake
{
    public class FakeAbstractMessageBuf : AbstractMessageBuf<object>
    {
        public int  DeallocateWasCalled = 0;
        public FakeAbstractMessageBuf(int maxCapacity) : base(maxCapacity)
        {
        }
        public FakeAbstractMessageBuf()
            : base(25)
        {
        }
   

        protected override void Deallocate()
        {
            DeallocateWasCalled++;
        }
        
    }
}