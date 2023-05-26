namespace ktsu.io.StrongStrings.Test;

[TestClass]
public class StaticsMembers
{
	private const string Yeet = nameof(Yeet);
	private static StrongStringDerivedClass StrongYeet => (StrongStringDerivedClass)Yeet;

	[TestMethod]
	public void TestToCharArray()
	{
		Assert.IsTrue(condition: AnyStrongString.ToCharArray(strongString: StrongYeet).SequenceEqual(second: Yeet.ToCharArray()));
		Assert.IsTrue(condition: StrongYeet.ToCharArray().SequenceEqual(second: Yeet.ToCharArray()));
		Assert.IsTrue(condition: AnyStrongString.ToCharArray(strongString: null!).Length == 0);
	}

	[TestMethod]
	public void TestFromCharArray()
	{
		_ = Assert.ThrowsException<ArgumentNullException>(action: () => AnyStrongString.FromCharArray<StrongStringDerivedClass>(value: null!));
		Assert.AreEqual(expected: Yeet, actual: AnyStrongString.FromCharArray<StrongStringDerivedClass>(value: Yeet.ToCharArray()).WeakString);
	}

	[TestMethod]
	public void TestToString()
	{
		Assert.AreEqual(expected: Yeet, actual: AnyStrongString.ToString(strongString: StrongYeet));
		Assert.IsTrue(condition: AnyStrongString.ToString(strongString: null!).Length == 0);
	}

	[TestMethod]
	public void TestFromString()
	{
		_ = Assert.ThrowsException<ArgumentNullException>(action: () => AnyStrongString.FromString<StrongStringDerivedClass>(value: null!));
		Assert.AreEqual(expected: Yeet, actual: AnyStrongString.FromString<StrongStringDerivedClass>(value: Yeet).WeakString);
	}
}
