#pragma warning disable CS1591

namespace ktsu.StrongStrings.Test;

public record StrongStringDerivedClass : StrongStringAbstract<StrongStringDerivedClass>;

public record NonEmptyStrongString : StrongStringAbstract<NonEmptyStrongString, NonEmptyValidator>;

public record ValidStrongString1 : StrongStringAbstract<ValidStrongString1, TrueValidator>;

public record InvalidStrongString1 : StrongStringAbstract<InvalidStrongString1, FalseValidator>;

public record ValidStrongString2 : StrongStringAbstract<ValidStrongString2, TrueValidator, TrueValidator>;

public record InvalidStrongString2 : StrongStringAbstract<InvalidStrongString2, FalseValidator, FalseValidator>;

public record ValidStrongString3 : StrongStringAbstract<ValidStrongString3, TrueValidator, TrueValidator, TrueValidator>;

public record InvalidStrongString3 : StrongStringAbstract<InvalidStrongString3, FalseValidator, FalseValidator, FalseValidator>;

public record ValidStrongString4 : StrongStringAbstract<ValidStrongString4, TrueValidator, TrueValidator, TrueValidator, TrueValidator>;

public record InvalidStrongString4 : StrongStringAbstract<InvalidStrongString4, FalseValidator, FalseValidator, FalseValidator, FalseValidator>;

public record ValidStrongString5 : StrongStringAbstract<ValidStrongString5, TrueValidator, TrueValidator, TrueValidator, TrueValidator, TrueValidator>;

public record InvalidStrongString5 : StrongStringAbstract<InvalidStrongString5, FalseValidator, FalseValidator, FalseValidator, FalseValidator, FalseValidator>;

public abstract class TrueValidator : IValidator
{
	public static bool IsValid(AnyStrongString? strongString) => true;
}

public abstract class FalseValidator : IValidator
{
	public static bool IsValid(AnyStrongString? strongString) => false;
}

public abstract class NonEmptyValidator : IValidator
{
	public static bool IsValid(AnyStrongString? strongString) => strongString is not null && !strongString.IsEmpty();
}
