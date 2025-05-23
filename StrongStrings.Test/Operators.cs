// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

#pragma warning disable CS1591

namespace ktsu.StrongStrings.Test;

[TestClass]
public class Operators
{
	private const string Yeet = nameof(Yeet);
	private const string Yote = nameof(Yote);
	private static StrongStringDerivedClass StrongYeet => (StrongStringDerivedClass)Yeet;
	private static StrongStringDerivedClass StrongYote => (StrongStringDerivedClass)Yote;

	[TestMethod]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "MSTEST0037:Use proper 'Assert' methods", Justification = "Testing the operators")]
	public void TestOpEquals()
	{
		var strongString0 = StrongYeet;
		var strongString1 = StrongYeet;
		var strongString2 = StrongYote;
		Assert.IsTrue(condition: strongString0 == strongString1);
		Assert.IsFalse(condition: strongString0 == strongString2);
	}

	[TestMethod]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "MSTEST0037:Use proper 'Assert' methods", Justification = "Testing the operators")]
	public void TestOpNotEquals()
	{
		var strongString0 = StrongYeet;
		var strongString1 = StrongYeet;
		var strongString2 = StrongYote;
		Assert.IsFalse(condition: strongString0 != strongString1);
		Assert.IsTrue(condition: strongString0 != strongString2);
	}

	[TestMethod]
	public void TestOpGreaterThan()
	{
		Assert.IsFalse(condition: StrongYeet > StrongYote);
		Assert.IsTrue(condition: StrongYote > StrongYeet);
		Assert.IsFalse(condition: StrongYeet > StrongYeet);

		Assert.IsFalse(condition: null! > StrongYote);
		Assert.IsTrue(condition: StrongYeet > null!);
	}

	[TestMethod]
	public void TestOpLessThan()
	{
		Assert.IsTrue(condition: StrongYeet < StrongYote);
		Assert.IsFalse(condition: StrongYote < StrongYeet);
		Assert.IsFalse(condition: StrongYeet < StrongYeet);

		Assert.IsTrue(condition: null! < StrongYote);
		Assert.IsFalse(condition: StrongYeet < null!);
	}

	[TestMethod]
	public void TestOpGreaterThanOrEqual()
	{
		Assert.IsFalse(condition: StrongYeet >= StrongYote);
		Assert.IsTrue(condition: StrongYote >= StrongYeet);
		Assert.IsTrue(condition: StrongYeet >= StrongYeet);

		Assert.IsFalse(condition: null! >= StrongYote);
		Assert.IsTrue(condition: StrongYeet >= null!);
	}

	[TestMethod]
	public void TestOpLessThanOrEqual()
	{
		Assert.IsTrue(condition: StrongYeet <= StrongYote);
		Assert.IsFalse(condition: StrongYote <= StrongYeet);
		Assert.IsTrue(condition: StrongYeet <= StrongYeet);

		Assert.IsTrue(condition: null! <= StrongYote);
		Assert.IsFalse(condition: StrongYeet <= null!);
	}

	[TestMethod]
	public void TestOpAdd() => Assert.AreEqual(Yeet + Yote, StrongYeet + StrongYote);
}
