using System.Diagnostics.CodeAnalysis;

namespace ktsu.io.StrongStrings.Test
{
	[TestClass]
	[SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "Disabled for test")]
	[SuppressMessage("Globalization", "CA1304:Specify CultureInfo", Justification = "Disabled for test")]
	[SuppressMessage("Globalization", "CA1311:Specify a culture or use an invariant version", Justification = "Disabled for test")]
	[SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "Disabled for test")]
	public class StrongStringTests
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

		private static StrongStringDerivedClass StrongYote
		{
			get
			{
				return (StrongStringDerivedClass)Yote;
			}
		}

		[TestMethod]
		public void TestCreateEmpty()
		{
			StrongStringDerivedClass strongString = new();
			Assert.AreEqual(string.Empty, strongString.WeakString);
		}

		[TestMethod]
		public void TestCreateWithValue()
		{
			StrongStringDerivedClass strongString = new()
			{
				WeakString = Yeet,
			};
			Assert.IsInstanceOfType<AnyStrongString>(strongString);
			Assert.AreEqual(Yeet, strongString.WeakString);
		}

		[TestMethod]
		public void TestCreateWithNull()
		{
			_ = Assert.ThrowsException<ArgumentNullException>(() =>
			{
				var strongString = (StrongStringDerivedClass)(string?)null;
			});
		}

		[TestMethod]
		public void TestOpExplicitString()
		{
			Assert.AreEqual(Yeet, (string)StrongYeet);
		}

		[TestMethod]
		public void TestOpExplicitCharArray()
		{
			Assert.IsTrue(((char[])StrongYeet).SequenceEqual(Yeet.ToCharArray()));
		}

		[TestMethod]
		public void TestOpImplicitString()
		{
			string stringYeet = StrongYeet;
			Assert.AreEqual(Yeet, stringYeet);
		}

		[TestMethod]
		public void TestOpImplicitCharArray()
		{
			char[] charsYeet = StrongYeet;
			Assert.IsTrue(charsYeet.SequenceEqual(Yeet.ToCharArray()));

			StrongStringDerivedClass confidentlyNull = null!;
			char[] charsNull = confidentlyNull;
			Assert.IsTrue(charsNull.Length == 0);
		}

		[TestMethod]
		public void TestToDerivedClassFromCharArray()
		{
			Assert.AreEqual(StrongYeet, StrongString.ToStrongString<StrongStringDerivedClass>(Yeet.ToCharArray()));
		}

		[TestMethod]
		public void TestToDerivedClassFromString()
		{
			Assert.AreEqual(StrongYeet, StrongString.ToStrongString<StrongStringDerivedClass>(Yeet));
		}

		[TestMethod]
		public void TestOpExplicitToDerivedClassFromCharArray()
		{
			Assert.AreEqual(StrongYeet, (StrongString<StrongStringDerivedClass>)Yeet.ToCharArray());
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
		public void TestToCharArray()
		{
			Assert.IsTrue(AnyStrongString.ToCharArray(StrongYeet).SequenceEqual(Yeet.ToCharArray()));
			Assert.IsTrue(StrongYeet.ToCharArray().SequenceEqual(Yeet.ToCharArray()));
			Assert.IsTrue(AnyStrongString.ToCharArray(null!).Length == 0);
		}

		[TestMethod]
		public void TestFromCharArray()
		{
			_ = Assert.ThrowsException<ArgumentNullException>(() => StrongString.FromCharArray<StrongStringDerivedClass>(null!));
			Assert.AreEqual(Yeet, StrongString.FromCharArray<StrongStringDerivedClass>(Yeet.ToCharArray()).WeakString);
		}

		[TestMethod]
		public void TestCompareTo()
		{
			Assert.IsTrue(StrongYeet.CompareTo(StrongYote) < 0);
			Assert.IsTrue(StrongYote.CompareTo(StrongYeet) > 0);
			Assert.IsTrue(StrongYeet.CompareTo(StrongYeet) == 0);
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

			Assert.ThrowsException<ArgumentNullException>(() => StrongYeet.Contains(null!));
			Assert.ThrowsException<ArgumentNullException>(() => StrongYeet.Contains(null!, StringComparison.Ordinal));
			Assert.ThrowsException<ArgumentNullException>(() => StrongYeet.Contains(null!, StringComparison.OrdinalIgnoreCase));
			Assert.ThrowsException<ArgumentNullException>(() => StrongYeet.Contains(null!, StringComparison.CurrentCulture));
			Assert.ThrowsException<ArgumentNullException>(() => StrongYeet.Contains(null!, StringComparison.CurrentCultureIgnoreCase));
			Assert.ThrowsException<ArgumentNullException>(() => StrongYeet.Contains(null!, StringComparison.InvariantCulture));
			Assert.ThrowsException<ArgumentNullException>(() => StrongYeet.Contains(null!, StringComparison.InvariantCultureIgnoreCase));
		}
	}
}
