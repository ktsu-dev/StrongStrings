using ktsu.io.StrongStrings;

namespace StrongStrings.Test
{
	public record StrongString0 : StrongString<StrongString0> { }

	public abstract class TrueValidator : IStringValidator
	{
		public static bool IsValid(IStrongString strongString) => true;
	}

	public abstract class FalseValidator : IStringValidator
	{
		public static bool IsValid(IStrongString strongString) => false;
	}

	[TestClass]
	public class StrongStringTests
	{
		private const string Yeet = nameof(Yeet);
		private const string Yote = nameof(Yote);

		[TestMethod]
		public void ExplicitCast()
		{
			var strongString0 = (StrongString0)Yeet;
			Assert.AreEqual(Yeet, strongString0);
			Assert.AreNotEqual(Yote, strongString0);
		}

		[TestMethod]
		public void ImplicitCast()
		{
			var strongString0 = (StrongString0)Yeet;
			string stringYeet = strongString0;
			Assert.AreEqual(Yeet, stringYeet);
			Assert.AreNotEqual(Yote, stringYeet);
		}
	}
}
