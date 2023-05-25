using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace ktsu.io.StrongStrings
{
	[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
	[SuppressMessage("Globalization", "CA1310:Specify StringComparison for correctness", Justification = "Preserving the System.String interface")]
	[SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "Preserving the System.String interface")]
	[SuppressMessage("Globalization", "CA1309:Use ordinal string comparison", Justification = "Preserving the System.String interface")]
	[SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "Preserving the System.String interface")]
	[SuppressMessage("Globalization", "CA1304:Specify CultureInfo", Justification = "Preserving the System.String interface")]
	[SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "Preserving the System.String interface")]
	[SuppressMessage("Globalization", "CA1311:Specify a culture or use an invariant version", Justification = "Preserving the System.String interface")]
	public abstract record class AnyStrongString : IString
	{
		// StrongString implementation
		[ExcludeFromCodeCoverage(Justification = "DebuggerDisplay")]
		protected string GetDebuggerDisplay()
		{
			return $"({GetType().Name})\"{ToString()}\"";
		}

		public static string ToString(AnyStrongString strongString)
		{
			return strongString?.WeakString ?? string.Empty;
		}

		public static char[] ToCharArray(AnyStrongString strongString)
		{
			return strongString?.WeakString.ToCharArray() ?? Array.Empty<char>();
		}

		public char[] ToCharArray()
		{
			return ToCharArray(this);
		}

		public bool IsEmpty()
		{
			return IsEmpty(this);
		}

		public static bool IsEmpty(AnyStrongString strongString)
		{
			return strongString?.Length == 0;
		}

		public virtual bool IsValid()
		{
			return IsValid(this);
		}

		public static bool IsValid(AnyStrongString strongString)
		{
			return strongString?.WeakString is not null;
		}

		// IComparable implementation
		public static bool operator <(AnyStrongString left, AnyStrongString right)
		{
			return left is null
				? right is not null
				: left.CompareTo((string)right) < 0;
		}

		public static bool operator <=(AnyStrongString left, AnyStrongString right)
		{
			return left is null
				|| left.CompareTo((string)right) <= 0;
		}

		public static bool operator >(AnyStrongString left, AnyStrongString right)
		{
			return left is not null
				&& left.CompareTo((string)right) > 0;
		}

		public static bool operator >=(AnyStrongString left, AnyStrongString right)
		{
			return left is null
				? right is null :
				left.CompareTo((string)right) >= 0;
		}

		// IString implementation
		public string WeakString { get; init; } = string.Empty;

		public int Length
		{
			get
			{
				return WeakString.Length;
			}
		}

		public char this[int index]
		{
			get
			{
				return WeakString[index];
			}
		}

		public static implicit operator string(AnyStrongString value)
		{
			return value?.ToString()
				?? string.Empty;
		}

		public int CompareTo(object? value)
		{
			return WeakString.CompareTo(value);
		}

		public bool Contains(string value)
		{
			return WeakString.Contains(value);
		}

		public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
		{
			WeakString.CopyTo(sourceIndex, destination, destinationIndex, count);
		}

		public bool EndsWith(string value)
		{
			return WeakString.EndsWith(value);
		}

		public bool EndsWith(string value, bool ignoreCase, CultureInfo culture)
		{
			return WeakString.EndsWith(value, ignoreCase, culture);
		}

		public bool EndsWith(string value, StringComparison comparisonType)
		{
			return WeakString.EndsWith(value, comparisonType);
		}

		public bool Equals(string value)
		{
			return WeakString.Equals(value);
		}

		public bool Equals(string value, StringComparison comparisonType)
		{
			return WeakString.Equals(value, comparisonType);
		}

		public CharEnumerator GetEnumerator()
		{
			return WeakString.GetEnumerator();
		}

		public TypeCode GetTypeCode()
		{
			return WeakString.GetTypeCode();
		}

		public int IndexOf(char value)
		{
			return WeakString.IndexOf(value);
		}

		public int IndexOf(char value, int startIndex)
		{
			return WeakString.IndexOf(value, startIndex);
		}

		public int IndexOf(char value, int startIndex, int count)
		{
			return WeakString.IndexOf(value, startIndex, count);
		}

		public int IndexOf(string value)
		{
			return WeakString.IndexOf(value);
		}

		public int IndexOf(string value, int startIndex)
		{
			return WeakString.IndexOf(value, startIndex);
		}

		public int IndexOf(string value, int startIndex, int count)
		{
			return WeakString.IndexOf(value, startIndex, count);
		}

		public int IndexOf(string value, int startIndex, int count, StringComparison comparisonType)
		{
			return WeakString.IndexOf(value, startIndex, count, comparisonType);
		}

		public int IndexOf(string value, int startIndex, StringComparison comparisonType)
		{
			return WeakString.IndexOf(value, startIndex, comparisonType);
		}

		public int IndexOf(string value, StringComparison comparisonType)
		{
			return WeakString.IndexOf(value, comparisonType);
		}

		public int IndexOfAny(char[] anyOf)
		{
			return WeakString.IndexOfAny(anyOf);
		}

		public int IndexOfAny(char[] anyOf, int startIndex)
		{
			return WeakString.IndexOfAny(anyOf, startIndex);
		}

		public int IndexOfAny(char[] anyOf, int startIndex, int count)
		{
			return WeakString.IndexOfAny(anyOf, startIndex, count);
		}

		public string Insert(int startIndex, string value)
		{
			return WeakString.Insert(startIndex, value);
		}

		public bool IsNormalized()
		{
			return WeakString.IsNormalized();
		}

		public bool IsNormalized(NormalizationForm normalizationForm)
		{
			return WeakString.IsNormalized(normalizationForm);
		}

		public int LastIndexOf(char value)
		{
			return WeakString.LastIndexOf(value);
		}

		public int LastIndexOf(char value, int startIndex)
		{
			return WeakString.LastIndexOf(value, startIndex);
		}

		public int LastIndexOf(char value, int startIndex, int count)
		{
			return WeakString.LastIndexOf(value, startIndex, count);
		}

		public int LastIndexOf(string value)
		{
			return WeakString.LastIndexOf(value);
		}

		public int LastIndexOf(string value, int startIndex)
		{
			return WeakString.LastIndexOf(value, startIndex);
		}

		public int LastIndexOf(string value, int startIndex, int count)
		{
			return WeakString.LastIndexOf(value, startIndex, count);
		}

		public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType)
		{
			return WeakString.LastIndexOf(value, startIndex, count, comparisonType);
		}

		public int LastIndexOf(string value, int startIndex, StringComparison comparisonType)
		{
			return WeakString.LastIndexOf(value, startIndex, comparisonType);
		}

		public int LastIndexOf(string value, StringComparison comparisonType)
		{
			return WeakString.LastIndexOf(value, comparisonType);
		}

		public int LastIndexOfAny(char[] anyOf)
		{
			return WeakString.LastIndexOfAny(anyOf);
		}

		public int LastIndexOfAny(char[] anyOf, int startIndex)
		{
			return WeakString.LastIndexOfAny(anyOf, startIndex);
		}

		public int LastIndexOfAny(char[] anyOf, int startIndex, int count)
		{
			return WeakString.LastIndexOfAny(anyOf, startIndex, count);
		}

		public string Normalize()
		{
			return WeakString.Normalize();
		}

		public string Normalize(NormalizationForm normalizationForm)
		{
			return WeakString.Normalize(normalizationForm);
		}

		public string PadLeft(int totalWidth)
		{
			return WeakString.PadLeft(totalWidth);
		}

		public string PadLeft(int totalWidth, char paddingChar)
		{
			return WeakString.PadLeft(totalWidth, paddingChar);
		}

		public string PadRight(int totalWidth)
		{
			return WeakString.PadRight(totalWidth);
		}

		public string PadRight(int totalWidth, char paddingChar)
		{
			return WeakString.PadRight(totalWidth, paddingChar);
		}

		public string Remove(int startIndex)
		{
			return WeakString.Remove(startIndex);
		}

		public string Remove(int startIndex, int count)
		{
			return WeakString.Remove(startIndex, count);
		}

		public string Replace(char oldChar, char newChar)
		{
			return WeakString.Replace(oldChar, newChar);
		}

		public string Replace(string oldValue, string newValue)
		{
			return WeakString.Replace(oldValue, newValue);
		}

		public string[] Split(char[] separator, int count)
		{
			return WeakString.Split(separator, count);
		}

		public string[] Split(char[] separator, int count, StringSplitOptions options)
		{
			return WeakString.Split(separator, count, options);
		}

		public string[] Split(char[] separator, StringSplitOptions options)
		{
			return WeakString.Split(separator, options);
		}

		public string[] Split(params char[] separator)
		{
			return WeakString.Split(separator);
		}

		public string[] Split(string[] separator, int count, StringSplitOptions options)
		{
			return WeakString.Split(separator, count, options);
		}

		public string[] Split(string[] separator, StringSplitOptions options)
		{
			return WeakString.Split(separator, options);
		}

		public bool StartsWith(string value)
		{
			return WeakString.StartsWith(value);
		}

		public bool StartsWith(string value, bool ignoreCase, CultureInfo culture)
		{
			return WeakString.StartsWith(value, ignoreCase, culture);
		}

		public bool StartsWith(string value, StringComparison comparisonType)
		{
			return WeakString.StartsWith(value, comparisonType);
		}

		public string Substring(int startIndex)
		{
			return WeakString[startIndex..];
		}

		public string Substring(int startIndex, int length)
		{
			return WeakString.Substring(startIndex, length);
		}

		public char[] ToCharArray(int startIndex, int length)
		{
			return WeakString.ToCharArray(startIndex, length);
		}

		public string ToLower()
		{
			return WeakString.ToLower();
		}

		public string ToLower(CultureInfo culture)
		{
			return WeakString.ToLower(culture);
		}

		public string ToLowerInvariant()
		{
			return WeakString.ToLowerInvariant();
		}

		public sealed override string ToString()
		{
			return WeakString;
		}

		public string ToString(IFormatProvider provider)
		{
			return WeakString.ToString(provider);
		}

		public string ToUpper()
		{
			return WeakString.ToUpper();
		}

		public string ToUpper(CultureInfo culture)
		{
			return WeakString.ToUpper(culture);
		}

		public string ToUpperInvariant()
		{
			return WeakString.ToUpperInvariant();
		}

		public string Trim()
		{
			return WeakString.Trim();
		}

		public string Trim(params char[] trimChars)
		{
			return WeakString.Trim(trimChars);
		}

		public string TrimEnd(params char[] trimChars)
		{
			return WeakString.TrimEnd(trimChars);
		}

		public string TrimStart(params char[] trimChars)
		{
			return WeakString.TrimStart(trimChars);
		}

		public int CompareTo(IString? other)
		{
			return WeakString.CompareTo(other?.WeakString);
		}

		IEnumerator<char> IEnumerable<char>.GetEnumerator()
		{
			return ((IEnumerable<char>)WeakString).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)WeakString).GetEnumerator();
		}

		public bool Contains(string value, StringComparison comparisonType)
		{
			return WeakString.Contains(value, comparisonType);
		}

		[SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "The named alternative is present on the base class")]
		// Without the suppression the compiler complains about "Error CA2225  Provide a method named 'ToCharArray' or 'FromStrongString' as an alternate for operator op_Implicit"
		// Logged: https://github.com/dotnet/roslyn-analyzers/issues/6640
		public static implicit operator char[](AnyStrongString value)
		{
			return value?.ToCharArray()
				?? Array.Empty<char>();
		}

		public static TDest FromCharArray<TDest>(char[]? value) where TDest : AnyStrongString
		{
			if (value is null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			return FromString<TDest>(new string(value));
		}

		public static TDest FromString<TDest>(string? value) where TDest : AnyStrongString
		{
			var newInstance = FromStringInternal<TDest>(value);
			return PerformValidation(newInstance);
		}

		internal static TDest FromStringInternal<TDest>(string? value) where TDest : AnyStrongString
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

		private static TDest PerformValidation<TDest>(TDest value) where TDest : AnyStrongString
		{
			if (!value.IsValid())
			{
				throw new FormatException($"Cannot convert \"{value}\" to {typeof(TDest).Name}");
			}

			return value;
		}
	}

	public record class StrongString
		: StrongString<StrongString>
	{
		public static new TDest FromCharArray<TDest>(char[]? value) where TDest : AnyStrongString
		{
			return AnyStrongString.FromCharArray<TDest>(value);
		}

		public static new TDest FromString<TDest>(string? value) where TDest : AnyStrongString
		{
			return AnyStrongString.FromString<TDest>(value);
		}

		public static TDest ToStrongString<TDest>(char[]? value) where TDest : AnyStrongString
		{
			return AnyStrongString.FromCharArray<TDest>(value);
		}

		public static TDest ToStrongString<TDest>(string value) where TDest : AnyStrongString
		{
			return AnyStrongString.FromString<TDest>(value);
		}
	}

	public abstract record class StrongString<TDerived>
		: StrongString<TDerived, NoValidator>
		where TDerived : StrongString<TDerived>
	{ }

	public abstract record class StrongString<TDerived, TValidator>
		: StrongString<TDerived, TValidator, NoValidator>
		where TDerived : StrongString<TDerived, TValidator>
		where TValidator : IStringValidator
	{ }

	public abstract record class StrongString<TDerived, TValidator1, TValidator2>
		: StrongString<TDerived, TValidator1, TValidator2, NoValidator>
		where TDerived : StrongString<TDerived, TValidator1, TValidator2>
		where TValidator1 : IStringValidator
		where TValidator2 : IStringValidator
	{ }

	public abstract record class StrongString<TDerived, TValidator1, TValidator2, TValidator3>
		: StrongString<TDerived, TValidator1, TValidator2, TValidator3, NoValidator>
		where TDerived : StrongString<TDerived, TValidator1, TValidator2, TValidator3>
		where TValidator1 : IStringValidator
		where TValidator2 : IStringValidator
		where TValidator3 : IStringValidator
	{ }

	public abstract record class StrongString<TDerived, TValidator1, TValidator2, TValidator3, TValidator4>
		: StrongString<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, NoValidator>
		where TDerived : StrongString<TDerived, TValidator1, TValidator2, TValidator3, TValidator4>
		where TValidator1 : IStringValidator
		where TValidator2 : IStringValidator
		where TValidator3 : IStringValidator
		where TValidator4 : IStringValidator
	{ }

	public abstract record class StrongString<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
		: AnyStrongString
		where TDerived : StrongString<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
		where TValidator1 : IStringValidator
		where TValidator2 : IStringValidator
		where TValidator3 : IStringValidator
		where TValidator4 : IStringValidator
		where TValidator5 : IStringValidator
	{
		public override bool IsValid()
		{
			return IsValid(this)
				&& TValidator1.IsValid(this)
				&& TValidator2.IsValid(this)
				&& TValidator3.IsValid(this)
				&& TValidator4.IsValid(this)
				&& TValidator5.IsValid(this);
		}

		public static explicit operator StrongString<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>(char[]? value)
		{
			return StrongString.FromString<TDerived>(new string(value));
		}

		public static explicit operator StrongString<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>(string? value)
		{
			return StrongString.FromString<TDerived>(value);
		}

		public static TDerived ToStrongString(char[]? value)
		{
			return (TDerived)value;
		}

		public static TDerived ToStrongString(string value)
		{
			return (TDerived)value;
		}

		/// <summary>
		/// Returns the FileName with a single suffix removed from the end, or the original FileName if the suffix was not found
		/// </summary>
		/// <param name="suffix">The suffix to remove from the end of the FileName</param>
		/// <returns>The FileName with a suffix removed from the end, or the original FileName if the suffix was not found</returns>
		public TDerived RemoveSuffix(string suffix)
		{
			if (suffix is not null)
			{
				return (TDerived)
				(
					EndsWith(suffix, StringComparison.Ordinal)
					? WeakString[..^suffix.Length]
					: this
				);
			}
			return (TDerived)this;
		}

		/// <summary>
		/// Returns the FileName with the first suffix found removed from the end, or the original FileName if no suffix was not found
		/// </summary>
		/// <param name="suffixes">The suffixes to attempt to remove from the end of the FileName</param>
		/// <returns>The FileName with a suffix removed from the end, or the original FileName if the suffix was not found</returns>
		public TDerived RemoveSuffix(params string[] suffixes)
		{
			if (suffixes is not null)
			{
				return RemoveSuffix(suffixes.ToList());
			}


			return (TDerived)this;
		}

		/// <summary>
		/// Returns the FileName with the first suffix found removed from the end, or the original FileName if no suffix was not found
		/// </summary>
		/// <param name="suffixes">The suffixes to attempt to remove from the end of the FileName</param>
		/// <returns>The FileName with a suffix removed from the end, or the original FileName if the suffix was not found</returns>
		public TDerived RemoveSuffix(IEnumerable<string> suffixes)
		{
			if (suffixes is not null)
			{
				foreach (string suffix in suffixes)
				{
					var result = RemoveSuffix(suffix);
					if (result != this)
					{
						return result;
					}
				}
			}

			return (TDerived)this;
		}

		/// <summary>
		/// Returns the FileName with the first suffix found removed from the end, or the original FileName if no suffix was not found
		/// </summary>
		/// <param name="suffixes">The suffixes to attempt to remove from the end of the FileName</param>
		/// <returns>The FileName with a suffix removed from the end, or the original FileName if the suffix was not found</returns>
		public TDerived RemoveSuffix(IEnumerable<AnyStrongString> suffixes)
		{
			if (suffixes is not null)
			{
				return RemoveSuffix(suffixes.Select(s => s.WeakString));
			}

			return (TDerived)this;
		}
	}
}
