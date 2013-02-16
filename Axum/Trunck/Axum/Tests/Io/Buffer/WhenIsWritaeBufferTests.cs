using System;
using NUnit.Framework;
using Tests.Fake;

namespace Tests
{
    [TestFixture]
    public class WhenIsWritaeBufferTests
    {
        private FakeAbstractMessageBuf _abstractMessageBuf;

        [SetUp]
        public void TestInitialize()
        {
            _abstractMessageBuf = new FakeAbstractMessageBuf(4);
        }
        //probity 

        [Test]
        public void YouCanNotToWriteIfTheQueueIsFull()
        {
            _abstractMessageBuf.Add(1);
            _abstractMessageBuf.Add(1);
            _abstractMessageBuf.Add(1);
            _abstractMessageBuf.Add(1);
            Assert.That(_abstractMessageBuf.IsWritable(), Is.False);
        }

        [Test]
        public void AllowedToWriteIfTheQueueIsNotFull()
        {
            _abstractMessageBuf.Add(2);
            Assert.That(_abstractMessageBuf.IsWritable(), Is.True);
        }

        [Test]
        public void AllowedToWriteBySpecifiedAmountIfTheQueueIsNotFull()
        {
            _abstractMessageBuf.Add(2);
            Assert.That(_abstractMessageBuf.IsWritable(1), Is.True);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgBelowZeroShouldThrowAnExcception()
        {
            Assert.That(_abstractMessageBuf.IsWritable(-1), Is.True);
        }

    }
}