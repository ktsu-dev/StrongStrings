namespace ktsu.io.StrongStrings;

public interface IValidator
{
	static abstract bool IsValid(AnyStrongString? strongString);
}

public abstract record NoValidator : IValidator
{
	public static bool IsValid(AnyStrongString? strongString) => true;
}
