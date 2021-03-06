﻿using System;
using Axum.Io.Buffer;
using NUnit.Framework;
using Tests.Fake;

namespace Tests.Io.Buffer.AbstractMessageBufTests
{
    [TestFixture]
    public class WhenRetainBufferTests
    {
        private AbstractMessageBuf<object> _abstractMessageBuf;
        [SetUp]
        public void TestInitialize()
        {
            _abstractMessageBuf = new FakeAbstractMessageBuf();
        }


        [Test]
        public void RetainShoulIncrementRefByOne()
        {
            _abstractMessageBuf.Retain().Retain();
            Assert.AreEqual(3, _abstractMessageBuf.RefCnt());

            _abstractMessageBuf.Retain(500);

            Assert.AreEqual(503, _abstractMessageBuf.RefCnt());
        }

        
        [Test]
        [ExpectedException]
        public void RetainShouldThrowExceptionIfSetWithValueLessThanZero()
        {
            _abstractMessageBuf.Retain(-1);
        }

        
        [Test]
        [ExpectedException]
        public void RetainShouldGuardOutRangeBufferValues()
        {
            int MIN_INITIAL_CAPACITY = 8;
            Console.WriteLine("0x{0:x}", MIN_INITIAL_CAPACITY);
            Console.WriteLine("0x{0:x}", MIN_INITIAL_CAPACITY << 1);

            _abstractMessageBuf.Retain(100).Retain(int.MaxValue);
        } 
    }
}