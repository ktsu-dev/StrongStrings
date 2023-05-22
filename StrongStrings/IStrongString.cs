namespace ktsu.io.StrongStrings
{
	public interface IStrongString : IString
	{
		// IString implementation
		new string ToString() => WeakString;

		// IStrongString implementation
		bool IsValid();
		TDest SanitizeInput<TDest>() where TDest : IStrongString;
		public static bool IsValid(IStrongString strongString) => strongString?.WeakString is not null;
		public static char[] ToCharArray(IStrongString strongString) => strongString?.WeakString.ToCharArray() ?? Array.Empty<char>();
		public static string ToString(IStrongString strongString) => strongString?.WeakString ?? string.Empty;
		public static TDest FromCharArray<TDest>(char[]? value) where TDest : IStrongString => FromString<TDest>(new string(value));
		public static TDest FromString<TDest>(string? value) where TDest : IStrongString
		{
			if (value is null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			var newInstance = (TDest)Activator.CreateInstance(typeof(TDest), value)!;
			return newInstance.IsValid() ? newInstance.SanitizeInput<TDest>() : throw new FormatException($"Cannot convert \"{value}\" to {typeof(TDest).Name}");
		}
	}
}
