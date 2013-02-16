using System;
using Axum.Exception;
using NUnit.Framework;
using Tests.Fake;

namespace Tests.Io.Buffer.AbstractMessageBufTests
{
    [TestFixture]
    public class WhenReleasingBufferTests
    {
        private FakeAbstractMessageBuf _abstractMessageBuf;

        [SetUp]
        public void TestInitialize()
        {
            _abstractMessageBuf = new FakeAbstractMessageBuf();
        }


        [Test]
        public void ShouldDecrementByOne()
        {
            _abstractMessageBuf.Retain(2);
            var isReleaseSucceed = _abstractMessageBuf.Release();

            Assert.That(isReleaseSucceed, Is.False);
            Assert.AreEqual(2, _abstractMessageBuf.RefCnt());
        }

        [Test]
        [ExpectedException(typeof (IllegalBufferAccessException))]
        public void RefCountIsLessThanZeroItShouldThrowException()
        {
            // given the ref count is 1 
            _abstractMessageBuf.Release();
            _abstractMessageBuf.Release();
        }

        [Test]
        public void DealocateResourceWhenRefCountZero()
        {
            var isReleaseSucceed = _abstractMessageBuf.Release();

            Assert.That(isReleaseSucceed, Is.True);
            Assert.That(_abstractMessageBuf.DeallocateWasCalled, Is.EqualTo(1));
            Assert.AreEqual(0, _abstractMessageBuf.RefCnt());
        }

        [Test]
        public void ShouldDecrementRefCountBySepecifiedAmount()
        {
            _abstractMessageBuf.Retain(5);
            var isReleaseSucceed = _abstractMessageBuf.Release(2);

            Assert.That(isReleaseSucceed, Is.False);
            Assert.AreEqual(4, _abstractMessageBuf.RefCnt());
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void WhenArgPassedIsLessThanZeroItShouldThrowException()
        {
            // given the ref count is 1 
            _abstractMessageBuf.Release(-6);

        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void WhenArgPassedIsEqualsToZeroItShouldThrowException()
        {
            // given the ref count is 1 
            _abstractMessageBuf.Release(0);

        }

        [Test]
        public void DealocateeSourceIfRefCountIsEqualsTOZeroWhenDecrementBySpecifiedAmount()
        {
            var isReleaseSucceed = _abstractMessageBuf.Release(1);

            Assert.That(isReleaseSucceed, Is.True);
            Assert.That(_abstractMessageBuf.DeallocateWasCalled, Is.EqualTo(1));
            Assert.AreEqual(0, _abstractMessageBuf.RefCnt());
        }

        [Test]
        [ExpectedException(typeof(IllegalBufferAccessException))]
        public void WhenSepecifiedAmountIsGreaterThanRefCountItShouldThrowException()
        {
             _abstractMessageBuf.Release(7);
        }
    }
}
