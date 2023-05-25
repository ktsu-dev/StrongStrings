namespace ktsu.io.StrongStrings.Test
{
	[TestClass]
	public class IStrongStringTests
	{
		private const string Yeet = nameof(Yeet);
		private const string Yote = nameof(Yote);
		private static StrongStringDerivedClass StrongYeet
		{
			get
			{
				return (StrongStringDerivedClass)Yeet;
			}
		}

		[TestMethod]
		public void TestAsStrongString()
		{
			Assert.IsNotNull((StrongYeet as IStrongString).AsStrongString);
		}

		[TestMethod]
		public void TestIsEmpty()
		{
			Assert.IsTrue(IStrongString.IsEmpty(new StrongStringDerivedClass()));
			Assert.IsFalse(IStrongString.IsEmpty(StrongYeet));
			Assert.IsFalse(IStrongString.IsEmpty(null!));
		}

		[TestMethod]
		public void TestIsValid()
		{
			Assert.IsTrue(IStrongString.IsValid(new StrongStringDerivedClass()));
			Assert.IsTrue(IStrongString.IsValid(StrongYeet));
			Assert.IsFalse(IStrongString.IsValid(null!));
		}

		[TestMethod]
		public void TestToCharArray()
		{
			Assert.IsTrue(IStrongString.ToCharArray(StrongYeet).SequenceEqual(Yeet.ToCharArray()));
			Assert.IsTrue(IStrongString.ToCharArray(null!).Length == 0);
		}

		[TestMethod]
		public void TestToString()
		{
			Assert.AreEqual(Yeet, IStrongString.ToString(StrongYeet));
			Assert.IsTrue(IStrongString.ToString(null!).Length == 0);
		}

		[TestMethod]
		public void TestFromString()
		{
			_ = Assert.ThrowsException<ArgumentNullException>(() => IStrongString.FromString<StrongStringDerivedClass>(null!));
			Assert.AreEqual(Yeet, IStrongString.FromString<StrongStringDerivedClass>(Yeet).WeakString);
		}

		[TestMethod]
		public void TestFromCharArray()
		{
			_ = Assert.ThrowsException<ArgumentNullException>(() => IStrongString.FromCharArray<StrongStringDerivedClass>(null!));
			Assert.AreEqual(Yeet, IStrongString.FromCharArray<StrongStringDerivedClass>(Yeet.ToCharArray()).WeakString);
		}

		[TestMethod]
		public void TestFromStringInternal()
		{
			_ = Assert.ThrowsException<ArgumentNullException>(() => IStrongString.FromStringInternal<StrongStringDerivedClass>(null!));
			Assert.AreEqual(Yeet, IStrongString.FromStringInternal<StrongStringDerivedClass>(Yeet).WeakString);
			Assert.AreNotEqual(Yote, IStrongString.FromStringInternal<StrongStringDerivedClass>(Yeet).WeakString);
		}
	}
}
