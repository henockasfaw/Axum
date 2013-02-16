using System;
using Axum.Io.Buffer;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AbstractMessageBufTests
    {
        private AbstractMessageBuf<object> _abstractMessageBuf;

        [SetUp]
        public void TestInitialize()
        {
            _abstractMessageBuf = Rhino.Mocks.MockRepository.GeneratePartialMock<AbstractMessageBuf<object>>(25);
        }


        [Test]
        public void SettingMaxVCapcityAboveOrEqualToZero()
        {
            AbstractMessageBuf<object> mock = Rhino.Mocks.MockRepository.GeneratePartialMock<AbstractMessageBuf<object>>(25);

            Assert.AreEqual(25, mock.MaxCapacity());
        }


        [ExpectedException]
        [Test]
        public void SettingMaxCapcityBelowZero()
        {
            AbstractMessageBuf<object> mock = Rhino.Mocks.MockRepository.GeneratePartialMock<AbstractMessageBuf<object>>(-1);
        }

        [Test]
        public void BufferTypeShouldBeMessage()
        {
            Assert.AreEqual(BufType.Message, _abstractMessageBuf.Type());
        }

        [Test]
        public void ReferenceCountShouldStartFromOne()
        {
            Assert.AreEqual(1, _abstractMessageBuf.RefCnt());
        }

        [Test]
        public void RetainShoulIncrementRefByOne()
        {
            _abstractMessageBuf.Retain().Retain();
            Assert.AreEqual(3, _abstractMessageBuf.RefCnt());

            _abstractMessageBuf.Retain(500);

            Assert.AreEqual(503, _abstractMessageBuf.RefCnt());
        }

        [ExpectedException]
        [Test]
        public void RetainShouldThrowExceptionIfSetWithValueLessThanZero()
        {
            _abstractMessageBuf.Retain(-1);
        }

        [ExpectedException]
        [Test]
        public void RetainShouldGuardOutRangeBufferValues()
        {
            _abstractMessageBuf.Retain(100).Retain(int.MaxValue);
        }

    }

}
