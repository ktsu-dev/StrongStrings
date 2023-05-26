namespace ktsu.io.StrongStrings.Test
{
	[TestClass]
	public class StaticsMembers
	{
		private const string Yeet = nameof(Yeet);
		private static StrongStringDerivedClass StrongYeet => (StrongStringDerivedClass)Yeet;

		[TestMethod]
		public void TestToCharArray()
		{
			Assert.IsTrue(AnyStrongString.ToCharArray(StrongYeet).SequenceEqual(Yeet.ToCharArray()));
			Assert.IsTrue(StrongYeet.ToCharArray().SequenceEqual(Yeet.ToCharArray()));
			Assert.IsTrue(AnyStrongString.ToCharArray(null!).Length == 0);
		}

		[TestMethod]
		public void TestFromCharArray()
		{
			_ = Assert.ThrowsException<ArgumentNullException>(() => AnyStrongString.FromCharArray<StrongStringDerivedClass>(null!));
			Assert.AreEqual(Yeet, AnyStrongString.FromCharArray<StrongStringDerivedClass>(Yeet.ToCharArray()).WeakString);
		}

		[TestMethod]
		public void TestToString()
		{
			Assert.AreEqual(Yeet, AnyStrongString.ToString(StrongYeet));
			Assert.IsTrue(AnyStrongString.ToString(null!).Length == 0);
		}

		[TestMethod]
		public void TestFromString()
		{
			_ = Assert.ThrowsException<ArgumentNullException>(() => AnyStrongString.FromString<StrongStringDerivedClass>(null!));
			Assert.AreEqual(Yeet, AnyStrongString.FromString<StrongStringDerivedClass>(Yeet).WeakString);
		}
	}
}
