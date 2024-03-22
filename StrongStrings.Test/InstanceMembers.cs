#pragma warning disable CS1591

namespace ktsu.io.StrongStrings.Test;

using System.Diagnostics.CodeAnalysis;

[TestClass]
[SuppressMessage(category: "Globalization", checkId: "CA1305:Specify IFormatProvider", Justification = "Disabled for test")]
[SuppressMessage(category: "Globalization", checkId: "CA1304:Specify CultureInfo", Justification = "Disabled for test")]
[SuppressMessage(category: "Globalization", checkId: "CA1311:Specify a culture or use an invariant version", Justification = "Disabled for test")]
[SuppressMessage(category: "Globalization", checkId: "CA1307:Specify StringComparison for clarity", Justification = "Disabled for test")]
public class InstanceMembers
{
	private const string Yeet = nameof(Yeet);
	private const string Yote = nameof(Yote);
	private static StrongStringDerivedClass StrongYeet => (StrongStringDerivedClass)Yeet;
	private static StrongStringDerivedClass StrongYote => (StrongStringDerivedClass)Yote;

	[TestMethod]
	public void TestGetHashCode()
	{
		var strongString0 = StrongYeet;
		var strongString1 = StrongYeet;
		var strongString2 = StrongYote;
		Assert.AreEqual(expected: strongString0.GetHashCode(), actual: strongString1.GetHashCode());
		Assert.AreNotEqual(notExpected: strongString0.GetHashCode(), actual: strongString2.GetHashCode());
	}

	[TestMethod]
	public void TestToString()
	{
		var strongString = StrongYeet;
		Assert.AreEqual(expected: Yeet, actual: strongString.ToString());
		Assert.AreNotEqual(notExpected: Yote, actual: strongString.ToString());
	}

	[TestMethod]
	public void TestValidate()
	{
		Assert.IsTrue(condition: ((NonEmptyStrongString)Yeet).IsValid());
		_ = Assert.ThrowsException<FormatException>(action: () => (NonEmptyStrongString)string.Empty);

		Assert.IsFalse(condition: NonEmptyValidator.IsValid(strongString: null!));

		Assert.IsFalse
		(
			condition: new InvalidStrongString1
			{
				WeakString = null!,
			}.IsValid()
		);

		Assert.IsTrue(condition: new ValidStrongString1().IsValid());
		Assert.IsFalse(condition: new InvalidStrongString1().IsValid());
		Assert.IsTrue(condition: new ValidStrongString2().IsValid());
		Assert.IsFalse(condition: new InvalidStrongString2().IsValid());
		Assert.IsTrue(condition: new ValidStrongString3().IsValid());
		Assert.IsFalse(condition: new InvalidStrongString3().IsValid());
		Assert.IsTrue(condition: new ValidStrongString4().IsValid());
		Assert.IsFalse(condition: new InvalidStrongString4().IsValid());
		Assert.IsTrue(condition: new ValidStrongString5().IsValid());
		Assert.IsFalse(condition: new InvalidStrongString5().IsValid());
	}

	[TestMethod]
	public void TestEquals()
	{
		var strongString0 = StrongYeet;
		var strongString1 = StrongYeet;
		var strongString2 = StrongYote;
		Assert.IsTrue(condition: strongString0.Equals(other: strongString1));
		Assert.IsFalse(condition: strongString0.Equals(other: strongString2));
	}

	[TestMethod]
	public void TestValidateWithNull() => _ = Assert.ThrowsException<ArgumentNullException>(action: () => { _ = ((NonEmptyStrongString)(string?)null).IsValid(); });

	[TestMethod]
	public void TestWeakString()
	{
		var strongString = StrongYeet;
		Assert.AreEqual(expected: Yeet, actual: strongString.WeakString);
		Assert.AreNotEqual(notExpected: Yote, actual: strongString.WeakString);
	}

	[TestMethod]
	public void TestLength()
	{
		var strongString = StrongYeet;
		Assert.AreEqual(expected: Yeet.Length, actual: strongString.Length);
		Assert.AreNotEqual(notExpected: 0, actual: strongString.Length);
	}

	[TestMethod]
	public void TestIsEmpty()
	{
		var strongStringEmpty = (StrongStringDerivedClass)string.Empty;
		var strongStringYeet = StrongYeet;
		Assert.IsTrue(condition: strongStringEmpty.IsEmpty());
		Assert.IsFalse(condition: strongStringYeet.IsEmpty());
	}

	[TestMethod]
	public void TestToUpper()
	{
		var strongString = StrongYeet;
		Assert.AreEqual(expected: Yeet.ToUpper(), actual: strongString.ToUpper());
	}

	[TestMethod]
	public void TestToLower()
	{
		var strongString = StrongYeet;
		Assert.AreEqual(expected: Yeet.ToLower(), actual: strongString.ToLower());
	}

	[TestMethod]
	public void TestIndexer() => Assert.AreEqual(expected: 't', actual: StrongYeet[^1]);

	[TestMethod]
	public void TestContains()
	{
		Assert.IsTrue(condition: StrongYeet.Contains(value: Yeet));
		Assert.IsTrue(condition: StrongYeet.Contains(value: Yeet[index: 0]));
		Assert.IsTrue(condition: StrongYeet.Contains(value: Yeet[1..3]));
		Assert.IsTrue(condition: StrongYeet.Contains(value: Yeet[1..3], comparisonType: StringComparison.Ordinal));
		Assert.IsTrue(condition: StrongYeet.Contains(value: Yeet[1..3], comparisonType: StringComparison.OrdinalIgnoreCase));
		Assert.IsTrue(condition: StrongYeet.Contains(value: Yeet[1..3], comparisonType: StringComparison.CurrentCulture));
		Assert.IsTrue(condition: StrongYeet.Contains(value: Yeet[1..3], comparisonType: StringComparison.CurrentCultureIgnoreCase));
		Assert.IsTrue(condition: StrongYeet.Contains(value: Yeet[1..3], comparisonType: StringComparison.InvariantCulture));
		Assert.IsTrue(condition: StrongYeet.Contains(value: Yeet[1..3], comparisonType: StringComparison.InvariantCultureIgnoreCase));

		Assert.IsFalse(condition: StrongYeet.Contains(value: Yote));
		Assert.IsFalse(condition: StrongYeet.Contains(value: Yote[index: 1]));
		Assert.IsFalse(condition: StrongYeet.Contains(value: Yote[1..3]));
		Assert.IsFalse(condition: StrongYeet.Contains(value: Yote[1..3], comparisonType: StringComparison.Ordinal));
		Assert.IsFalse(condition: StrongYeet.Contains(value: Yote[1..3], comparisonType: StringComparison.OrdinalIgnoreCase));
		Assert.IsFalse(condition: StrongYeet.Contains(value: Yote[1..3], comparisonType: StringComparison.CurrentCulture));
		Assert.IsFalse(condition: StrongYeet.Contains(value: Yote[1..3], comparisonType: StringComparison.CurrentCultureIgnoreCase));
		Assert.IsFalse(condition: StrongYeet.Contains(value: Yote[1..3], comparisonType: StringComparison.InvariantCulture));
		Assert.IsFalse(condition: StrongYeet.Contains(value: Yote[1..3], comparisonType: StringComparison.InvariantCultureIgnoreCase));

		_ = Assert.ThrowsException<ArgumentNullException>(action: () => StrongYeet.Contains(value: null!));
		_ = Assert.ThrowsException<ArgumentNullException>(action: () => StrongYeet.Contains(value: null!, comparisonType: StringComparison.Ordinal));
		_ = Assert.ThrowsException<ArgumentNullException>(action: () => StrongYeet.Contains(value: null!, comparisonType: StringComparison.OrdinalIgnoreCase));
		_ = Assert.ThrowsException<ArgumentNullException>(action: () => StrongYeet.Contains(value: null!, comparisonType: StringComparison.CurrentCulture));
		_ = Assert.ThrowsException<ArgumentNullException>(action: () => StrongYeet.Contains(value: null!, comparisonType: StringComparison.CurrentCultureIgnoreCase));
		_ = Assert.ThrowsException<ArgumentNullException>(action: () => StrongYeet.Contains(value: null!, comparisonType: StringComparison.InvariantCulture));
		_ = Assert.ThrowsException<ArgumentNullException>(action: () => StrongYeet.Contains(value: null!, comparisonType: StringComparison.InvariantCultureIgnoreCase));
	}

	[TestMethod]
	public void TestCompareTo()
	{
		Assert.IsTrue(condition: StrongYeet.CompareTo(other: StrongYote) < 0);
		Assert.IsTrue(condition: StrongYote.CompareTo(other: StrongYeet) > 0);
		Assert.IsTrue(condition: StrongYeet.CompareTo(other: StrongYeet) == 0);
	}
}
