using Axum.Io.Buffer;
using NUnit.Framework;

namespace Tests.Io.Buffer.DefaultMessageBufTests
{
   // constructer test 

    [TestFixture]
    public class ConstructerTest
    {
        private DefaultMessageBuf<int> _defaultMessageBuf;

        [SetUp]
        public void TestInitialize()
        {
            _defaultMessageBuf = new DefaultMessageBuf<int>();
        }

        [Test]
        public void DefaultConstructerTest()
        {
            Assert.AreEqual(8, _defaultMessageBuf.MaxCapacity());

        }
    }
}