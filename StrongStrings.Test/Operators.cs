namespace ktsu.io.StrongStrings.Test
{
	[TestClass]
	public class Operators
	{
		private const string Yeet = nameof(Yeet);
		private const string Yote = nameof(Yote);
		private static StrongStringDerivedClass StrongYeet => (StrongStringDerivedClass)Yeet;
		private static StrongStringDerivedClass StrongYote => (StrongStringDerivedClass)Yote;

		[TestMethod]
		public void TestOpEquals()
		{
			var strongString0 = StrongYeet;
			var strongString1 = StrongYeet;
			var strongString2 = StrongYote;
			Assert.IsTrue(strongString0 == strongString1);
			Assert.IsFalse(strongString0 == strongString2);
		}

		[TestMethod]
		public void TestOpNotEquals()
		{
			var strongString0 = StrongYeet;
			var strongString1 = StrongYeet;
			var strongString2 = StrongYote;
			Assert.IsFalse(strongString0 != strongString1);
			Assert.IsTrue(strongString0 != strongString2);
		}

		[TestMethod]
		public void TestOpGreaterThan()
		{
			Assert.IsFalse(StrongYeet > StrongYote);
			Assert.IsTrue(StrongYote > StrongYeet);
			Assert.IsFalse(StrongYeet > StrongYeet);

			Assert.IsFalse(null! > StrongYote);
			Assert.IsTrue(StrongYeet > null!);
		}

		[TestMethod]
		public void TestOpLessThan()
		{
			Assert.IsTrue(StrongYeet < StrongYote);
			Assert.IsFalse(StrongYote < StrongYeet);
			Assert.IsFalse(StrongYeet < StrongYeet);

			Assert.IsTrue(null! < StrongYote);
			Assert.IsFalse(StrongYeet < null!);
		}

		[TestMethod]
		public void TestOpGreaterThanOrEqual()
		{
			Assert.IsFalse(StrongYeet >= StrongYote);
			Assert.IsTrue(StrongYote >= StrongYeet);
			Assert.IsTrue(StrongYeet >= StrongYeet);

			Assert.IsFalse(null! >= StrongYote);
			Assert.IsTrue(StrongYeet >= null!);
		}

		[TestMethod]
		public void TestOpLessThanOrEqual()
		{
			Assert.IsTrue(StrongYeet <= StrongYote);
			Assert.IsFalse(StrongYote <= StrongYeet);
			Assert.IsTrue(StrongYeet <= StrongYeet);

			Assert.IsTrue(null! <= StrongYote);
			Assert.IsFalse(StrongYeet <= null!);
		}

		[TestMethod]
		public void TestOpAdd()
		{
			Assert.AreEqual(StrongYeet + StrongYote, Yeet + Yote);
		}
	}
}
