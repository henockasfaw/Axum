using System;
using Axum.Io.Buffer;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AbstractMessageBufTests
    {
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
    }
}
    