using Axum.Io.Buffer;
using NUnit.Framework;
using Tests.Fake;

namespace Tests.Io.Buffer.AbstractMessageBufTests
{
    [TestFixture]
    public class WhenConstructorInitialized
    {
        [Test]
        public void SettingMaxCapcityAboveOrEqualToZeroAndInitConstructor()
        {
            AbstractMessageBuf<object> abstractMessageBuf = new FakeAbstractMessageBuf(25);

            Assert.AreEqual(25, abstractMessageBuf.MaxCapacity());
            Assert.AreEqual(1, abstractMessageBuf.RefCnt());
            Assert.AreEqual(BufType.Message, abstractMessageBuf.Type());
        }
      

        [ExpectedException]
        [Test]
        public void SettingMaxCapcityBelowZero()
        {
            AbstractMessageBuf<object> abstractMessageBuf = new FakeAbstractMessageBuf(-1);
        }
    }
}