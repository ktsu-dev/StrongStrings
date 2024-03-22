#pragma warning disable CS1591

namespace ktsu.io.StrongStrings.Test;

[TestClass]
public class Creation
{
	private const string Yeet = nameof(Yeet);
	private static StrongStringDerivedClass StrongYeet => (StrongStringDerivedClass)Yeet;

	[TestMethod]
	public void CanCreateEmpty()
	{
		StrongStringDerivedClass strongString = new();
		Assert.AreEqual(expected: string.Empty, actual: strongString.WeakString);
	}

	[TestMethod]
	public void CanCreateWithInit()
	{
		StrongStringDerivedClass strongString = new()
		{
			WeakString = Yeet,
		};
		Assert.IsInstanceOfType<AnyStrongString>(value: strongString);
		Assert.AreEqual(expected: Yeet, actual: strongString.WeakString);
	}

	[TestMethod]
	public void CanNotCreateFromNull()
	{
		_ = Assert.ThrowsException<ArgumentNullException>
		(
			action: () =>
			{
				var strongString = (StrongStringDerivedClass)(string?)null;
			}
		);
	}

	[TestMethod]
	public void CanExplicitCastToString() => Assert.AreEqual(expected: Yeet, actual: (string)StrongYeet);

	[TestMethod]
	public void CanExplicitCastToCharArray() => Assert.IsTrue(condition: ((char[])StrongYeet).SequenceEqual(second: Yeet.ToCharArray()));

	[TestMethod]
	public void CanImplicitCastToString()
	{
		string stringYeet = StrongYeet;
		Assert.AreEqual(expected: Yeet, actual: stringYeet);
	}

	[TestMethod]
	public void CanImplicitCastToCharArray()
	{
		char[] charsYeet = StrongYeet;
		Assert.IsTrue(condition: charsYeet.SequenceEqual(second: Yeet.ToCharArray()));

		StrongStringDerivedClass confidentlyNull = null!;
		char[] charsNull = confidentlyNull;
		Assert.IsTrue(condition: charsNull.Length == 0);
	}

	[TestMethod]
	public void CanExplicitCastFromCharArray() => Assert.AreEqual(expected: StrongYeet, actual: (StrongStringDerivedClass)Yeet.ToCharArray());

	[TestMethod]
	public void CanExplicitCastFromString() => Assert.AreEqual(expected: StrongYeet, actual: (StrongStringDerivedClass)Yeet);
}
