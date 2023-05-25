using ktsu.io.StrongStrings.Internal;

namespace ktsu.io.StrongStrings
{
	public interface IStrongString : IString
	{
		// IStrongString implementation
		StrongString AsStrongString
		{
			get
			{
				return (this as StrongString)!;
			}
		}

		bool IsEmpty();
		public static bool IsEmpty(IStrongString strongString)
		{
			return strongString?.Length == 0;
		}

		bool IsValid();
		public static bool IsValid(IStrongString strongString)
		{
			return strongString?.WeakString is not null;
		}

		public static char[] ToCharArray(IStrongString strongString)
		{
			return strongString?.WeakString.ToCharArray() ?? Array.Empty<char>();
		}

		public static string ToString(IStrongString strongString)
		{
			return strongString?.WeakString ?? string.Empty;
		}

		public static TDest FromCharArray<TDest>(char[]? value) where TDest : IStrongString
		{
			if (value is null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			return FromString<TDest>(new string(value));
		}

		public static TDest FromString<TDest>(string? value) where TDest : IStrongString
		{
			var newInstance = FromStringInternal<TDest>(value);
			return PerformValidation(newInstance);
		}

		internal static TDest FromStringInternal<TDest>(string? value) where TDest : IStrongString
		{
			if (value is null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			var typeOfTDest = typeof(TDest);
			var newInstance = (TDest)Activator.CreateInstance(typeOfTDest)!;
			typeOfTDest.GetProperty(nameof(WeakString))!.SetValue(newInstance, value);
			return newInstance;
		}

		private static TDest PerformValidation<TDest>(TDest value) where TDest : IStrongString
		{
			if (!value.IsValid())
			{
				throw new FormatException($"Cannot convert \"{value}\" to {typeof(TDest).Name}");
			}

			return value;
		}
	}
}
