namespace ktsu.io.StrongStrings
{
	public interface IStringValidator
	{
		static abstract bool IsValid(AnyStrongString strongString);
	}

	public abstract record class NoValidator : IStringValidator
	{
		public static bool IsValid(AnyStrongString strongString)
		{
			return true;
		}
	}
}
