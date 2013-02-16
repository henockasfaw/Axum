using System;
using NUnit.Framework;
using Tests.Fake;

namespace Tests
{
    [TestFixture]
    public class WhenIsReadableBufferTests
    {
        private FakeAbstractMessageBuf _abstractMessageBuf;

        [SetUp]
        public void TestInitialize()
        {
            _abstractMessageBuf = new FakeAbstractMessageBuf(5);
        }

        [Test]
        public void IsEmpty()
        {
            Assert.That(_abstractMessageBuf.IsReadable(), Is.False);
        }

        [Test]
        public void SecifiedAmountIsMoreThanOrEqualsToQueueLength()
        {
            Assert.That(_abstractMessageBuf.IsReadable(5), Is.True);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgBelowZeroShouldThrowAnExcception()
        {
            _abstractMessageBuf.IsReadable(-1);
        }
    }
}