namespace ktsu.io.StrongStrings.Test
{
	[TestClass]
	public class Creation
	{
		private const string Yeet = nameof(Yeet);
		private static StrongStringDerivedClass StrongYeet => (StrongStringDerivedClass)Yeet;

		[TestMethod]
		public void CanCreateEmpty()
		{
			StrongStringDerivedClass strongString = new();
			Assert.AreEqual(string.Empty, strongString.WeakString);
		}

		[TestMethod]
		public void CanCreateWithInit()
		{
			StrongStringDerivedClass strongString = new()
			{
				WeakString = Yeet,
			};
			Assert.IsInstanceOfType<AnyStrongString>(strongString);
			Assert.AreEqual(Yeet, strongString.WeakString);
		}

		[TestMethod]
		public void CanNotCreateFromNull()
		{
			_ = Assert.ThrowsException<ArgumentNullException>(() =>
			{
				var strongString = (StrongStringDerivedClass)(string?)null;
			});
		}

		[TestMethod]
		public void CanExplicitCastToString()
		{
			Assert.AreEqual(Yeet, (string)StrongYeet);
		}

		[TestMethod]
		public void CanExplicitCastToCharArray()
		{
			Assert.IsTrue(((char[])StrongYeet).SequenceEqual(Yeet.ToCharArray()));
		}

		[TestMethod]
		public void CanImplicitCastToString()
		{
			string stringYeet = StrongYeet;
			Assert.AreEqual(Yeet, stringYeet);
		}

		[TestMethod]
		public void CanImplicitCastToCharArray()
		{
			char[] charsYeet = StrongYeet;
			Assert.IsTrue(charsYeet.SequenceEqual(Yeet.ToCharArray()));

			StrongStringDerivedClass confidentlyNull = null!;
			char[] charsNull = confidentlyNull;
			Assert.IsTrue(charsNull.Length == 0);
		}

		[TestMethod]
		public void CanExplicitCastFromCharArray()
		{
			Assert.AreEqual(StrongYeet, (StrongStringDerivedClass)Yeet.ToCharArray());
		}

		[TestMethod]
		public void CanExplicitCastFromString()
		{
			Assert.AreEqual(StrongYeet, (StrongStringDerivedClass)Yeet);
		}
	}
}
