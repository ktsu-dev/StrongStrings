using System.Diagnostics.CodeAnalysis;

namespace ktsu.io.StrongStrings.Test
{
	[TestClass]
	[SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "Disabled for test")]
	[SuppressMessage("Globalization", "CA1304:Specify CultureInfo", Justification = "Disabled for test")]
	[SuppressMessage("Globalization", "CA1311:Specify a culture or use an invariant version", Justification = "Disabled for test")]
	[SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "Disabled for test")]
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
			Assert.AreEqual(strongString0.GetHashCode(), strongString1.GetHashCode());
			Assert.AreNotEqual(strongString0.GetHashCode(), strongString2.GetHashCode());
		}

		[TestMethod]
		public void TestToString()
		{
			var strongString = StrongYeet;
			Assert.AreEqual(Yeet, strongString.ToString());
			Assert.AreNotEqual(Yote, strongString.ToString());
		}

		[TestMethod]
		public void TestValidate()
		{
			Assert.IsTrue(((NonEmptyStrongString)Yeet).IsValid());
			_ = Assert.ThrowsException<FormatException>(() => (NonEmptyStrongString)string.Empty);

			Assert.IsFalse(NonEmptyValidator.IsValid(null!));

			Assert.IsFalse(new InvalidStrongString1()
			{
				WeakString = null!,
			}.IsValid());

			Assert.IsTrue(new ValidStrongString1().IsValid());
			Assert.IsFalse(new InvalidStrongString1().IsValid());
			Assert.IsTrue(new ValidStrongString2().IsValid());
			Assert.IsFalse(new InvalidStrongString2().IsValid());
			Assert.IsTrue(new ValidStrongString3().IsValid());
			Assert.IsFalse(new InvalidStrongString3().IsValid());
			Assert.IsTrue(new ValidStrongString4().IsValid());
			Assert.IsFalse(new InvalidStrongString4().IsValid());
			Assert.IsTrue(new ValidStrongString5().IsValid());
			Assert.IsFalse(new InvalidStrongString5().IsValid());
		}

		[TestMethod]
		public void TestEquals()
		{
			var strongString0 = StrongYeet;
			var strongString1 = StrongYeet;
			var strongString2 = StrongYote;
			Assert.IsTrue(strongString0.Equals(strongString1));
			Assert.IsFalse(strongString0.Equals(strongString2));
		}

		[TestMethod]
		public void TestValidateWithNull()
		{
			_ = Assert.ThrowsException<ArgumentNullException>(() =>
			{
				_ = ((NonEmptyStrongString)(string?)null).IsValid();
			});
		}

		[TestMethod]
		public void TestWeakString()
		{
			var strongString = StrongYeet;
			Assert.AreEqual(Yeet, strongString.WeakString);
			Assert.AreNotEqual(Yote, strongString.WeakString);
		}

		[TestMethod]
		public void TestLength()
		{
			var strongString = StrongYeet;
			Assert.AreEqual(Yeet.Length, strongString.Length);
			Assert.AreNotEqual(0, strongString.Length);
		}

		[TestMethod]
		public void TestIsEmpty()
		{
			var strongStringEmpty = (StrongStringDerivedClass)string.Empty;
			var strongStringYeet = StrongYeet;
			Assert.IsTrue(strongStringEmpty.IsEmpty());
			Assert.IsFalse(strongStringYeet.IsEmpty());
		}

		[TestMethod]
		public void TestToUpper()
		{
			var strongString = StrongYeet;
			Assert.AreEqual(Yeet.ToUpper(), strongString.ToUpper());
		}

		[TestMethod]
		public void TestToLower()
		{
			var strongString = StrongYeet;
			Assert.AreEqual(Yeet.ToLower(), strongString.ToLower());
		}

		[TestMethod]
		public void TestIndexer()
		{
			Assert.AreEqual('t', StrongYeet[^1]);
		}

		[TestMethod]
		public void TestRemoveSuffix()
		{
			const string dotJson = ".json";
			const string dotExe = ".exe";
			const string dotJif = ".jif";
			const string dotJifDotJson = ".jif.json";

			var yeetDotJson = (StrongStringDerivedClass)$"{Yeet}{dotJson}";
			var yeetDotJif = (StrongStringDerivedClass)$"{Yeet}{dotJif}";
			var yeetDotJifDotJson = (StrongStringDerivedClass)$"{Yeet}{dotJifDotJson}";

			var strongDotJson = (StrongStringDerivedClass)dotJson;
			var strongDotJif = (StrongStringDerivedClass)dotJif;
			var strongDotExe = (StrongStringDerivedClass)dotExe;
			var strongDotJifDotJson = (StrongStringDerivedClass)dotJifDotJson;

			Assert.AreEqual(Yeet, yeetDotJson.RemoveSuffix(dotJson));
			Assert.AreEqual(Yeet, yeetDotJifDotJson.RemoveSuffix(dotJifDotJson));
			Assert.AreEqual(yeetDotJson, yeetDotJson.RemoveSuffix(dotJif));
			Assert.AreEqual(yeetDotJif, yeetDotJifDotJson.RemoveSuffix(dotJson));
			Assert.AreEqual(yeetDotJif, yeetDotJifDotJson.RemoveSuffix(dotJson, dotJif));
			Assert.AreEqual(yeetDotJif, yeetDotJifDotJson.RemoveSuffix(dotJif, dotJson));
			Assert.AreEqual(yeetDotJif, yeetDotJifDotJson.RemoveSuffix(dotExe, dotJson, dotJif));
			Assert.AreEqual(yeetDotJif, yeetDotJifDotJson.RemoveSuffix(new List<string>() { dotExe, dotJson, dotJif }));
			Assert.AreEqual(yeetDotJifDotJson, yeetDotJifDotJson.RemoveSuffix(new List<string>() { dotExe }));

			Assert.AreEqual(Yeet, yeetDotJson.RemoveSuffix(strongDotJson));
			Assert.AreEqual(Yeet, yeetDotJifDotJson.RemoveSuffix(strongDotJifDotJson));
			Assert.AreEqual(yeetDotJson, yeetDotJson.RemoveSuffix(strongDotJif));
			Assert.AreEqual(yeetDotJif, yeetDotJifDotJson.RemoveSuffix(strongDotJson));
			Assert.AreEqual(yeetDotJif, yeetDotJifDotJson.RemoveSuffix(strongDotJson, strongDotJif));
			Assert.AreEqual(yeetDotJif, yeetDotJifDotJson.RemoveSuffix(strongDotJif, strongDotJson));
			Assert.AreEqual(yeetDotJif, yeetDotJifDotJson.RemoveSuffix(strongDotExe, strongDotJson, strongDotJif));
			Assert.AreEqual(yeetDotJif, yeetDotJifDotJson.RemoveSuffix(new List<StrongStringDerivedClass>() { strongDotExe, strongDotJson, strongDotJif }));
			Assert.AreEqual(yeetDotJifDotJson, yeetDotJifDotJson.RemoveSuffix(new List<string>() { strongDotExe }));

			Assert.AreEqual(yeetDotJson, yeetDotJson.RemoveSuffix((string)null!));
			Assert.AreEqual(yeetDotJson, yeetDotJson.RemoveSuffix((string[])null!));
			Assert.AreEqual(yeetDotJson, yeetDotJson.RemoveSuffix((List<StrongStringDerivedClass>)null!));
			Assert.AreEqual(yeetDotJson, yeetDotJson.RemoveSuffix((IEnumerable<string>)null!));
		}

		[TestMethod]
		public void TestContains()
		{
			Assert.IsTrue(StrongYeet.Contains(Yeet));
			Assert.IsTrue(StrongYeet.Contains(Yeet[0]));
			Assert.IsTrue(StrongYeet.Contains(Yeet[1..3]));
			Assert.IsTrue(StrongYeet.Contains(Yeet[1..3], StringComparison.Ordinal));
			Assert.IsTrue(StrongYeet.Contains(Yeet[1..3], StringComparison.OrdinalIgnoreCase));
			Assert.IsTrue(StrongYeet.Contains(Yeet[1..3], StringComparison.CurrentCulture));
			Assert.IsTrue(StrongYeet.Contains(Yeet[1..3], StringComparison.CurrentCultureIgnoreCase));
			Assert.IsTrue(StrongYeet.Contains(Yeet[1..3], StringComparison.InvariantCulture));
			Assert.IsTrue(StrongYeet.Contains(Yeet[1..3], StringComparison.InvariantCultureIgnoreCase));

			Assert.IsFalse(StrongYeet.Contains(Yote));
			Assert.IsFalse(StrongYeet.Contains(Yote[1]));
			Assert.IsFalse(StrongYeet.Contains(Yote[1..3]));
			Assert.IsFalse(StrongYeet.Contains(Yote[1..3], StringComparison.Ordinal));
			Assert.IsFalse(StrongYeet.Contains(Yote[1..3], StringComparison.OrdinalIgnoreCase));
			Assert.IsFalse(StrongYeet.Contains(Yote[1..3], StringComparison.CurrentCulture));
			Assert.IsFalse(StrongYeet.Contains(Yote[1..3], StringComparison.CurrentCultureIgnoreCase));
			Assert.IsFalse(StrongYeet.Contains(Yote[1..3], StringComparison.InvariantCulture));
			Assert.IsFalse(StrongYeet.Contains(Yote[1..3], StringComparison.InvariantCultureIgnoreCase));

			_ = Assert.ThrowsException<ArgumentNullException>(() => StrongYeet.Contains(null!));
			_ = Assert.ThrowsException<ArgumentNullException>(() => StrongYeet.Contains(null!, StringComparison.Ordinal));
			_ = Assert.ThrowsException<ArgumentNullException>(() => StrongYeet.Contains(null!, StringComparison.OrdinalIgnoreCase));
			_ = Assert.ThrowsException<ArgumentNullException>(() => StrongYeet.Contains(null!, StringComparison.CurrentCulture));
			_ = Assert.ThrowsException<ArgumentNullException>(() => StrongYeet.Contains(null!, StringComparison.CurrentCultureIgnoreCase));
			_ = Assert.ThrowsException<ArgumentNullException>(() => StrongYeet.Contains(null!, StringComparison.InvariantCulture));
			_ = Assert.ThrowsException<ArgumentNullException>(() => StrongYeet.Contains(null!, StringComparison.InvariantCultureIgnoreCase));
		}

		[TestMethod]
		public void TestCompareTo()
		{
			Assert.IsTrue(StrongYeet.CompareTo(StrongYote) < 0);
			Assert.IsTrue(StrongYote.CompareTo(StrongYeet) > 0);
			Assert.IsTrue(StrongYeet.CompareTo(StrongYeet) == 0);
		}
	}
}
