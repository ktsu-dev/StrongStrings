namespace ktsu.io.StrongStrings.Test
{
	public record class StrongStringDerivedClass : AnyStrongString<StrongStringDerivedClass> { }
	public record class NonEmptyStrongString : AnyStrongString<NonEmptyStrongString, NonEmptyValidator> { }
	public record class ValidStrongString1 : AnyStrongString<ValidStrongString1, TrueValidator> { }
	public record class InvalidStrongString1 : AnyStrongString<InvalidStrongString1, FalseValidator> { }
	public record class ValidStrongString2 : AnyStrongString<ValidStrongString2, TrueValidator, TrueValidator> { }
	public record class InvalidStrongString2 : AnyStrongString<InvalidStrongString2, FalseValidator, FalseValidator> { }
	public record class ValidStrongString3 : AnyStrongString<ValidStrongString3, TrueValidator, TrueValidator, TrueValidator> { }
	public record class InvalidStrongString3 : AnyStrongString<InvalidStrongString3, FalseValidator, FalseValidator, FalseValidator> { }
	public record class ValidStrongString4 : AnyStrongString<ValidStrongString4, TrueValidator, TrueValidator, TrueValidator, TrueValidator> { }
	public record class InvalidStrongString4 : AnyStrongString<InvalidStrongString4, FalseValidator, FalseValidator, FalseValidator, FalseValidator> { }
	public record class ValidStrongString5 : AnyStrongString<ValidStrongString5, TrueValidator, TrueValidator, TrueValidator, TrueValidator, TrueValidator> { }
	public record class InvalidStrongString5 : AnyStrongString<InvalidStrongString5, FalseValidator, FalseValidator, FalseValidator, FalseValidator, FalseValidator> { }

	public abstract class TrueValidator : IValidator
	{
		public static bool IsValid(AnyStrongString strongString)
		{
			return true;
		}
	}

	public abstract class FalseValidator : IValidator
	{
		public static bool IsValid(AnyStrongString strongString)
		{
			return false;
		}
	}

	public abstract class NonEmptyValidator : IValidator
	{
		public static bool IsValid(AnyStrongString strongString)
		{
			if (strongString is null)
			{
				return false;
			}

			return !strongString.IsEmpty();
		}
	}
}
