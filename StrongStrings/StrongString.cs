using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace ktsu.io.StrongStrings
{
	namespace Internal
	{
		[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
		[SuppressMessage("Globalization", "CA1310:Specify StringComparison for correctness", Justification = "Preserving the System.String interface")]
		[SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "Preserving the System.String interface")]
		[SuppressMessage("Globalization", "CA1309:Use ordinal string comparison", Justification = "Preserving the System.String interface")]
		[SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "Preserving the System.String interface")]
		[SuppressMessage("Globalization", "CA1304:Specify CultureInfo", Justification = "Preserving the System.String interface")]
		[SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "Preserving the System.String interface")]
		[SuppressMessage("Globalization", "CA1311:Specify a culture or use an invariant version", Justification = "<Pending>")]
		public abstract record class StrongString : IStrongString
		{
			// StrongString implementation
			protected string GetDebuggerDisplay() => $"({GetType().Name})\"{ToString()}\"";
			public static string ToString(IStrongString strongString) => IStrongString.ToString(strongString);
			public static char[] ToCharArray(IStrongString strongString) => IStrongString.ToCharArray(strongString);
			public char[] ToCharArray() => ToCharArray(this);
			public IStrongString AsIStrongString => this;

			// IStrongString implementation
			public virtual TDest SanitizeInput<TDest>() where TDest : IStrongString => IStrongString.FromStringInternal<TDest>(WeakString); // using the internal method to avoid the validation check which would cause an unbounded recursion

			public virtual bool IsValid() => IsValid(this);
			public static bool IsValid(IStrongString strongString) => IStrongString.IsValid(strongString);
			public static TDest FromCharArray<TDest>(char[]? value) where TDest : IStrongString => IStrongString.FromCharArray<TDest>(value);
			public static TDest FromString<TDest>(string? value) where TDest : IStrongString => IStrongString.FromString<TDest>(value);

			// IComparable implementation
			public static bool operator <(StrongString left, StrongString right) => left is null ? right is not null : left.CompareTo((string)right) < 0;
			public static bool operator <=(StrongString left, StrongString right) => left is null || left.CompareTo((string)right) <= 0;
			public static bool operator >(StrongString left, StrongString right) => left is not null && left.CompareTo((string)right) > 0;
			public static bool operator >=(StrongString left, StrongString right) => left is null ? right is null : left.CompareTo((string)right) >= 0;

			// IString implementation
			public string WeakString { get; init; } = string.Empty;
			public int Length => WeakString.Length;
			public char this[int index] => WeakString[index];
			public static implicit operator string(StrongString value) => value?.ToString() ?? string.Empty;
			public static implicit operator char[](StrongString value) => value?.ToCharArray() ?? Array.Empty<char>();
			public static explicit operator StrongString(string? value) => FromString<StrongString>(value);
			public static explicit operator StrongString(char[]? value) => FromString<StrongString>(new string(value));
			public bool IsEmpty() => WeakString.Length == 0;
			public int CompareTo(object? value) => WeakString.CompareTo(value);
			public int CompareTo(string strB) => WeakString.CompareTo(strB);
			public bool Contains(string value) => WeakString.Contains(value);
			public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count) => WeakString.CopyTo(sourceIndex, destination, destinationIndex, count);
			public bool EndsWith(string value) => WeakString.EndsWith(value);
			public bool EndsWith(string value, bool ignoreCase, CultureInfo culture) => WeakString.EndsWith(value, ignoreCase, culture);
			public bool EndsWith(string value, StringComparison comparisonType) => WeakString.EndsWith(value, comparisonType);
			public bool Equals(string value) => WeakString.Equals(value);
			public bool Equals(string value, StringComparison comparisonType) => WeakString.Equals(value, comparisonType);
			public CharEnumerator GetEnumerator() => WeakString.GetEnumerator();
			public TypeCode GetTypeCode() => WeakString.GetTypeCode();
			public int IndexOf(char value) => WeakString.IndexOf(value);
			public int IndexOf(char value, int startIndex) => WeakString.IndexOf(value, startIndex);
			public int IndexOf(char value, int startIndex, int count) => WeakString.IndexOf(value, startIndex, count);
			public int IndexOf(string value) => WeakString.IndexOf(value);
			public int IndexOf(string value, int startIndex) => WeakString.IndexOf(value, startIndex);
			public int IndexOf(string value, int startIndex, int count) => WeakString.IndexOf(value, startIndex, count);
			public int IndexOf(string value, int startIndex, int count, StringComparison comparisonType) => WeakString.IndexOf(value, startIndex, count, comparisonType);
			public int IndexOf(string value, int startIndex, StringComparison comparisonType) => WeakString.IndexOf(value, startIndex, comparisonType);
			public int IndexOf(string value, StringComparison comparisonType) => WeakString.IndexOf(value, comparisonType);
			public int IndexOfAny(char[] anyOf) => WeakString.IndexOfAny(anyOf);
			public int IndexOfAny(char[] anyOf, int startIndex) => WeakString.IndexOfAny(anyOf, startIndex);
			public int IndexOfAny(char[] anyOf, int startIndex, int count) => WeakString.IndexOfAny(anyOf, startIndex, count);
			public string Insert(int startIndex, string value) => WeakString.Insert(startIndex, value);
			public bool IsNormalized() => WeakString.IsNormalized();
			public bool IsNormalized(NormalizationForm normalizationForm) => WeakString.IsNormalized(normalizationForm);
			public int LastIndexOf(char value) => WeakString.LastIndexOf(value);
			public int LastIndexOf(char value, int startIndex) => WeakString.LastIndexOf(value, startIndex);
			public int LastIndexOf(char value, int startIndex, int count) => WeakString.LastIndexOf(value, startIndex, count);
			public int LastIndexOf(string value) => WeakString.LastIndexOf(value);
			public int LastIndexOf(string value, int startIndex) => WeakString.LastIndexOf(value, startIndex);
			public int LastIndexOf(string value, int startIndex, int count) => WeakString.LastIndexOf(value, startIndex, count);
			public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType) => WeakString.LastIndexOf(value, startIndex, count, comparisonType);
			public int LastIndexOf(string value, int startIndex, StringComparison comparisonType) => WeakString.LastIndexOf(value, startIndex, comparisonType);
			public int LastIndexOf(string value, StringComparison comparisonType) => WeakString.LastIndexOf(value, comparisonType);
			public int LastIndexOfAny(char[] anyOf) => WeakString.LastIndexOfAny(anyOf);
			public int LastIndexOfAny(char[] anyOf, int startIndex) => WeakString.LastIndexOfAny(anyOf, startIndex);
			public int LastIndexOfAny(char[] anyOf, int startIndex, int count) => WeakString.LastIndexOfAny(anyOf, startIndex, count);
			public string Normalize() => WeakString.Normalize();
			public string Normalize(NormalizationForm normalizationForm) => WeakString.Normalize(normalizationForm);
			public string PadLeft(int totalWidth) => WeakString.PadLeft(totalWidth);
			public string PadLeft(int totalWidth, char paddingChar) => WeakString.PadLeft(totalWidth, paddingChar);
			public string PadRight(int totalWidth) => WeakString.PadRight(totalWidth);
			public string PadRight(int totalWidth, char paddingChar) => WeakString.PadRight(totalWidth, paddingChar);
			public string Remove(int startIndex) => WeakString.Remove(startIndex);
			public string Remove(int startIndex, int count) => WeakString.Remove(startIndex, count);
			public string Replace(char oldChar, char newChar) => WeakString.Replace(oldChar, newChar);
			public string Replace(string oldValue, string newValue) => WeakString.Replace(oldValue, newValue);
			public string[] Split(char[] separator, int count) => WeakString.Split(separator, count);
			public string[] Split(char[] separator, int count, StringSplitOptions options) => WeakString.Split(separator, count, options);
			public string[] Split(char[] separator, StringSplitOptions options) => WeakString.Split(separator, options);
			public string[] Split(params char[] separator) => WeakString.Split(separator);
			public string[] Split(string[] separator, int count, StringSplitOptions options) => WeakString.Split(separator, count, options);
			public string[] Split(string[] separator, StringSplitOptions options) => WeakString.Split(separator, options);
			public bool StartsWith(string value) => WeakString.StartsWith(value);
			public bool StartsWith(string value, bool ignoreCase, CultureInfo culture) => WeakString.StartsWith(value, ignoreCase, culture);
			public bool StartsWith(string value, StringComparison comparisonType) => WeakString.StartsWith(value, comparisonType);
			public string Substring(int startIndex) => WeakString[startIndex..];
			public string Substring(int startIndex, int length) => WeakString.Substring(startIndex, length);
			public char[] ToCharArray(int startIndex, int length) => WeakString.ToCharArray(startIndex, length);
			public string ToLower() => WeakString.ToLower();
			public string ToLower(CultureInfo culture) => WeakString.ToLower(culture);
			public string ToLowerInvariant() => WeakString.ToLowerInvariant();
			public string ToString(IFormatProvider provider) => WeakString.ToString(provider);
			public string ToUpper() => WeakString.ToUpper();
			public string ToUpper(CultureInfo culture) => WeakString.ToUpper(culture);
			public string ToUpperInvariant() => WeakString.ToUpperInvariant();
			public string Trim() => WeakString.Trim();
			public string Trim(params char[] trimChars) => WeakString.Trim(trimChars);
			public string TrimEnd(params char[] trimChars) => WeakString.TrimEnd(trimChars);
			public string TrimStart(params char[] trimChars) => WeakString.TrimStart(trimChars);
			public int CompareTo(IString? other) => WeakString.CompareTo(other);
			IEnumerator<char> IEnumerable<char>.GetEnumerator() => ((IEnumerable<char>)WeakString).GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)WeakString).GetEnumerator();
		}
	}

	public abstract record class StrongString<TDerived> : Internal.StrongString where TDerived : StrongString<TDerived>
	{
		[SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "StrongString already does, are you drunk compiler?")]
		// Without the suppression the compiler complains about "Error CA2225  Provide a method named 'ToCharArray' or 'FromStrongString' as an alternate for operator op_Implicit"
		// Logged: https://github.com/dotnet/roslyn-analyzers/issues/6640
		public static implicit operator char[](StrongString<TDerived> value) => value?.ToCharArray() ?? Array.Empty<char>();
		public static explicit operator StrongString<TDerived>(char[]? value) => FromString<TDerived>(new string(value));
		public static TDerived ToStrongString(char[]? value) => (TDerived)value;

		public static implicit operator string(StrongString<TDerived> value) => ToString(value);
		public static explicit operator StrongString<TDerived>(string? value) => FromString<TDerived>(value);
		public static TDerived ToStrongString(string value) => (TDerived)value;

		/// <summary>
		/// Returns the FileName with a single suffix removed from the end, or the original FileName if the suffix was not found
		/// </summary>
		/// <param name="suffix">The suffix to remove from the end of the FileName</param>
		/// <returns>The FileName with a suffix removed from the end, or the original FileName if the suffix was not found</returns>
		public TDerived RemoveSuffix(string suffix) => (TDerived)(EndsWith(suffix, StringComparison.Ordinal) ? WeakString[..^(suffix?.Length ?? 0)] : this);

		/// <summary>
		/// Returns the FileName with the first suffix found removed from the end, or the original FileName if no suffix was not found
		/// </summary>
		/// <param name="suffixes">The suffixes to attempt to remove from the end of the FileName</param>
		/// <returns>The FileName with a suffix removed from the end, or the original FileName if the suffix was not found</returns>
		public TDerived RemoveSuffix(params string[] suffixes) => RemoveSuffix(suffixes);

		/// <summary>
		/// Returns the FileName with the first suffix found removed from the end, or the original FileName if no suffix was not found
		/// </summary>
		/// <param name="suffixes">The suffixes to attempt to remove from the end of the FileName</param>
		/// <returns>The FileName with a suffix removed from the end, or the original FileName if the suffix was not found</returns>
		public TDerived RemoveSuffix(IEnumerable<string> suffixes)
		{
			foreach (string suffix in suffixes ?? Array.Empty<string>())
			{
				var result = RemoveSuffix(suffix);
				if (result != this)
				{
					return result;
				}
			}

			return (TDerived)this;
		}
	}

	public abstract record class StrongString<TDerived, TValidator>
		: StrongString<TDerived>
		where TDerived : StrongString<TDerived, TValidator>
		where TValidator : IStringValidator
	{
		public override bool IsValid()
		{
			return IsValid(this)
				&& TValidator.IsValid(this);
		}
	}

	public abstract record class StrongString<TDerived, TValidator1, TValidator2> : StrongString<TDerived>
		where TDerived : StrongString<TDerived, TValidator1, TValidator2>
		where TValidator1 : IStringValidator
		where TValidator2 : IStringValidator
	{
		public override bool IsValid()
		{
			return IsValid(this)
				&& TValidator1.IsValid(this)
				&& TValidator2.IsValid(this);
		}
	}

	public abstract record class StrongString<TDerived, TValidator1, TValidator2, TValidator3> : StrongString<TDerived>
		where TDerived : StrongString<TDerived, TValidator1, TValidator2, TValidator3>
		where TValidator1 : IStringValidator
		where TValidator2 : IStringValidator
		where TValidator3 : IStringValidator
	{
		public override bool IsValid()
		{
			return IsValid(this)
				&& TValidator1.IsValid(this)
				&& TValidator2.IsValid(this)
				&& TValidator3.IsValid(this);
		}
	}

	public abstract record class StrongString<TDerived, TValidator1, TValidator2, TValidator3, TValidator4> : StrongString<TDerived>
		where TDerived : StrongString<TDerived, TValidator1, TValidator2, TValidator3, TValidator4>
		where TValidator1 : IStringValidator
		where TValidator2 : IStringValidator
		where TValidator3 : IStringValidator
		where TValidator4 : IStringValidator
	{
		public override bool IsValid()
		{
			return IsValid(this)
				&& TValidator1.IsValid(this)
				&& TValidator2.IsValid(this)
				&& TValidator3.IsValid(this)
				&& TValidator4.IsValid(this);
		}
	}

	public abstract record class StrongString<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5> : StrongString<TDerived>
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
	}
}
