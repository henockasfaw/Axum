using System;
using NUnit.Framework;
using Axum.Io.Buffer; 

namespace Tests
{
	[TestFixture()]
	public class UnpooledTests
	{
		Unpooled _unpooled; 

		[SetUp]
		public void Init ()
		{
			_unpooled = new Unpooled();
		}

		[Test()]
		public void TestCase ()
		{
		}
	}
}

