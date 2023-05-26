namespace ktsu.io.StrongStrings
{
	public interface IValidator
	{
		static abstract bool IsValid(AnyStrongString strongString);
	}

	public abstract record class NoValidator : IValidator
	{
		public static bool IsValid(AnyStrongString strongString)
		{
			return true;
		}
	}
}
