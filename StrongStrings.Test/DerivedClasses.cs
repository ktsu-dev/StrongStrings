namespace ktsu.io.StrongStrings.Test
{
	public record class StrongStringDerivedClass : StrongString<StrongStringDerivedClass> { }
	public record class NonEmptyStrongString : StrongString<NonEmptyStrongString, NonEmptyValidator> { }
	public record class ValidStrongString1 : StrongString<ValidStrongString1, TrueValidator> { }
	public record class InvalidStrongString1 : StrongString<InvalidStrongString1, FalseValidator> { }
	public record class ValidStrongString2 : StrongString<ValidStrongString2, TrueValidator, TrueValidator> { }
	public record class InvalidStrongString2 : StrongString<InvalidStrongString2, FalseValidator, FalseValidator> { }
	public record class ValidStrongString3 : StrongString<ValidStrongString3, TrueValidator, TrueValidator, TrueValidator> { }
	public record class InvalidStrongString3 : StrongString<InvalidStrongString3, FalseValidator, FalseValidator, FalseValidator> { }
	public record class ValidStrongString4 : StrongString<ValidStrongString4, TrueValidator, TrueValidator, TrueValidator, TrueValidator> { }
	public record class InvalidStrongString4 : StrongString<InvalidStrongString4, FalseValidator, FalseValidator, FalseValidator, FalseValidator> { }
	public record class ValidStrongString5 : StrongString<ValidStrongString5, TrueValidator, TrueValidator, TrueValidator, TrueValidator, TrueValidator> { }
	public record class InvalidStrongString5 : StrongString<InvalidStrongString5, FalseValidator, FalseValidator, FalseValidator, FalseValidator, FalseValidator> { }

	public abstract class TrueValidator : IStringValidator
	{
		public static bool IsValid(IStrongString strongString)
		{
			return true;
		}
	}

	public abstract class FalseValidator : IStringValidator
	{
		public static bool IsValid(IStrongString strongString)
		{
			return false;
		}
	}

	public abstract class NonEmptyValidator : IStringValidator
	{
		public static bool IsValid(IStrongString strongString)
		{
			if (strongString is null)
			{
				return false;
			}

			return !strongString.IsEmpty();
		}
	}
}
