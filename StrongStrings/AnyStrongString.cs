// ReSharper disable StringCompareToIsCultureSpecific
// ReSharper disable StringIndexOfIsCultureSpecific.1
// ReSharper disable StringIndexOfIsCultureSpecific.2
// ReSharper disable StringIndexOfIsCultureSpecific.3
// ReSharper disable StringLastIndexOfIsCultureSpecific.1
// ReSharper disable StringLastIndexOfIsCultureSpecific.2
// ReSharper disable StringLastIndexOfIsCultureSpecific.3

#pragma warning disable CA1305
#pragma warning disable CA1308
#pragma warning disable CA1304
#pragma warning disable CA1311
#pragma warning disable CA1309
#pragma warning disable CA1307
#pragma warning disable CA1310

namespace ktsu.io.StrongStrings;

using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

[DebuggerDisplay(value: $"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public abstract record AnyStrongString : IString
{
	public char[] ToCharArray() { return ToCharArray(strongString: this); }

	// IString implementation
	public string WeakString { get; init; } = string.Empty;

	public int Length => WeakString.Length;

	public char this[int index] => WeakString[index: index];

	public int CompareTo(object? value) { return WeakString.CompareTo(value: value); }

	public bool Contains(string value) { return WeakString.Contains(value: value); }

	public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count) { WeakString.CopyTo(sourceIndex: sourceIndex, destination: destination, destinationIndex: destinationIndex, count: count); }

	public bool EndsWith(string value) { return WeakString.EndsWith(value: value); }

	public bool EndsWith(string value, bool ignoreCase, CultureInfo culture) { return WeakString.EndsWith(value: value, ignoreCase: ignoreCase, culture: culture); }

	public bool EndsWith(string value, StringComparison comparisonType) { return WeakString.EndsWith(value: value, comparisonType: comparisonType); }

	public bool Equals(string value) { return WeakString.Equals(value: value); }

	public bool Equals(string value, StringComparison comparisonType) { return WeakString.Equals(value: value, comparisonType: comparisonType); }

	public CharEnumerator GetEnumerator() { return WeakString.GetEnumerator(); }

	public TypeCode GetTypeCode() { return WeakString.GetTypeCode(); }

	public int IndexOf(char value) { return WeakString.IndexOf(value: value); }

	public int IndexOf(char value, int startIndex) { return WeakString.IndexOf(value: value, startIndex: startIndex); }

	public int IndexOf(char value, int startIndex, int count) { return WeakString.IndexOf(value: value, startIndex: startIndex, count: count); }

	public int IndexOf(string value) { return WeakString.IndexOf(value: value); }

	public int IndexOf(string value, int startIndex) { return WeakString.IndexOf(value: value, startIndex: startIndex); }

	public int IndexOf(string value, int startIndex, int count) { return WeakString.IndexOf(value: value, startIndex: startIndex, count: count); }

	public int IndexOf(string value, int startIndex, int count, StringComparison comparisonType) { return WeakString.IndexOf(value: value, startIndex: startIndex, count: count, comparisonType: comparisonType); }

	public int IndexOf(string value, int startIndex, StringComparison comparisonType) { return WeakString.IndexOf(value: value, startIndex: startIndex, comparisonType: comparisonType); }

	public int IndexOf(string value, StringComparison comparisonType) { return WeakString.IndexOf(value: value, comparisonType: comparisonType); }

	public int IndexOfAny(char[] anyOf) { return WeakString.IndexOfAny(anyOf: anyOf); }

	public int IndexOfAny(char[] anyOf, int startIndex) { return WeakString.IndexOfAny(anyOf: anyOf, startIndex: startIndex); }

	public int IndexOfAny(char[] anyOf, int startIndex, int count) { return WeakString.IndexOfAny(anyOf: anyOf, startIndex: startIndex, count: count); }

	public string Insert(int startIndex, string value) { return WeakString.Insert(startIndex: startIndex, value: value); }

	public bool IsNormalized() { return WeakString.IsNormalized(); }

	public bool IsNormalized(NormalizationForm normalizationForm) { return WeakString.IsNormalized(normalizationForm: normalizationForm); }

	public int LastIndexOf(char value) { return WeakString.LastIndexOf(value: value); }

	public int LastIndexOf(char value, int startIndex) { return WeakString.LastIndexOf(value: value, startIndex: startIndex); }

	public int LastIndexOf(char value, int startIndex, int count) { return WeakString.LastIndexOf(value: value, startIndex: startIndex, count: count); }

	public int LastIndexOf(string value) { return WeakString.LastIndexOf(value: value); }

	public int LastIndexOf(string value, int startIndex) { return WeakString.LastIndexOf(value: value, startIndex: startIndex); }

	public int LastIndexOf(string value, int startIndex, int count) { return WeakString.LastIndexOf(value: value, startIndex: startIndex, count: count); }

	public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType) { return WeakString.LastIndexOf(value: value, startIndex: startIndex, count: count, comparisonType: comparisonType); }

	public int LastIndexOf(string value, int startIndex, StringComparison comparisonType) { return WeakString.LastIndexOf(value: value, startIndex: startIndex, comparisonType: comparisonType); }

	public int LastIndexOf(string value, StringComparison comparisonType) { return WeakString.LastIndexOf(value: value, comparisonType: comparisonType); }

	public int LastIndexOfAny(char[] anyOf) { return WeakString.LastIndexOfAny(anyOf: anyOf); }

	public int LastIndexOfAny(char[] anyOf, int startIndex) { return WeakString.LastIndexOfAny(anyOf: anyOf, startIndex: startIndex); }

	public int LastIndexOfAny(char[] anyOf, int startIndex, int count) { return WeakString.LastIndexOfAny(anyOf: anyOf, startIndex: startIndex, count: count); }

	public string Normalize() { return WeakString.Normalize(); }

	public string Normalize(NormalizationForm normalizationForm) { return WeakString.Normalize(normalizationForm: normalizationForm); }

	public string PadLeft(int totalWidth) { return WeakString.PadLeft(totalWidth: totalWidth); }

	public string PadLeft(int totalWidth, char paddingChar) { return WeakString.PadLeft(totalWidth: totalWidth, paddingChar: paddingChar); }

	public string PadRight(int totalWidth) { return WeakString.PadRight(totalWidth: totalWidth); }

	public string PadRight(int totalWidth, char paddingChar) { return WeakString.PadRight(totalWidth: totalWidth, paddingChar: paddingChar); }

	public string Remove(int startIndex) { return WeakString.Remove(startIndex: startIndex); }

	public string Remove(int startIndex, int count) { return WeakString.Remove(startIndex: startIndex, count: count); }

	public string Replace(char oldChar, char newChar) { return WeakString.Replace(oldChar: oldChar, newChar: newChar); }

	public string Replace(string oldValue, string newValue) { return WeakString.Replace(oldValue: oldValue, newValue: newValue); }

	public string[] Split(char[] separator, int count) { return WeakString.Split(separator: separator, count: count); }

	public string[] Split(char[] separator, int count, StringSplitOptions options) { return WeakString.Split(separator: separator, count: count, options: options); }

	public string[] Split(char[] separator, StringSplitOptions options) { return WeakString.Split(separator: separator, options: options); }

	public string[] Split(params char[] separator) { return WeakString.Split(separator: separator); }

	public string[] Split(string[] separator, int count, StringSplitOptions options) { return WeakString.Split(separator: separator, count: count, options: options); }

	public string[] Split(string[] separator, StringSplitOptions options) { return WeakString.Split(separator: separator, options: options); }

	public bool StartsWith(string value) { return WeakString.StartsWith(value: value); }

	public bool StartsWith(string value, bool ignoreCase, CultureInfo culture) { return WeakString.StartsWith(value: value, ignoreCase: ignoreCase, culture: culture); }

	public bool StartsWith(string value, StringComparison comparisonType) { return WeakString.StartsWith(value: value, comparisonType: comparisonType); }

	public string Substring(int startIndex) { return WeakString[startIndex..]; }

	public string Substring(int startIndex, int length) { return WeakString.Substring(startIndex: startIndex, length: length); }

	public char[] ToCharArray(int startIndex, int length) { return WeakString.ToCharArray(startIndex: startIndex, length: length); }

	public string ToLower() { return WeakString.ToLower(); }

	public string ToLower(CultureInfo culture) { return WeakString.ToLower(culture: culture); }

	public string ToLowerInvariant() { return WeakString.ToLowerInvariant(); }

	public sealed override string ToString() { return WeakString; }

	public string ToString(IFormatProvider provider) { return WeakString.ToString(provider: provider); }

	public string ToUpper() { return WeakString.ToUpper(); }

	public string ToUpper(CultureInfo culture) { return WeakString.ToUpper(culture: culture); }

	public string ToUpperInvariant() { return WeakString.ToUpperInvariant(); }

	public string Trim() { return WeakString.Trim(); }

	public string Trim(params char[] trimChars) { return WeakString.Trim(trimChars: trimChars); }

	public string TrimEnd(params char[] trimChars) { return WeakString.TrimEnd(trimChars: trimChars); }

	public string TrimStart(params char[] trimChars) { return WeakString.TrimStart(trimChars: trimChars); }

	public int CompareTo(IString? other) { return WeakString.CompareTo(strB: other?.WeakString); }

	IEnumerator<char> IEnumerable<char>.GetEnumerator() { return ((IEnumerable<char>)WeakString).GetEnumerator(); }

	IEnumerator IEnumerable.GetEnumerator() { return ((IEnumerable)WeakString).GetEnumerator(); }

	public bool Contains(string value, StringComparison comparisonType) { return WeakString.Contains(value: value, comparisonType: comparisonType); }

	// AnyStrongString implementation
	[ExcludeFromCodeCoverage(Justification = "DebuggerDisplay")]
	protected string GetDebuggerDisplay() { return $"({GetType().Name})\"{ToString()}\""; }

	public static string ToString(AnyStrongString? strongString) { return strongString?.WeakString ?? string.Empty; }

	public static char[] ToCharArray(AnyStrongString? strongString) { return strongString?.WeakString.ToCharArray() ?? Array.Empty<char>(); }

	public bool IsEmpty() { return IsEmpty(strongString: this); }

	private static bool IsEmpty(IString? strongString) { return strongString?.Length == 0; }

	public virtual bool IsValid() { return IsValid(strongString: this); }

	private static bool IsValid(IString? strongString) { return strongString?.WeakString is not null; }

	// IComparable implementation
	public static bool operator <(AnyStrongString? left, AnyStrongString? right) { return left is null ? right is not null : left.CompareTo(value: (string)right) < 0; }

	public static bool operator <=(AnyStrongString? left, AnyStrongString? right) { return left is null || left.CompareTo(value: (string)right) <= 0; }

	public static bool operator >(AnyStrongString? left, AnyStrongString? right) { return left is not null && left.CompareTo(value: (string)right) > 0; }

	public static bool operator >=(AnyStrongString? left, AnyStrongString? right) { return left is null ? right is null : left.CompareTo(value: (string)right) >= 0; }

	public static implicit operator char[](AnyStrongString? value) { return value?.ToCharArray() ?? Array.Empty<char>(); }

	public static implicit operator string(AnyStrongString? value) { return value?.ToString() ?? string.Empty; }

	public static TDest FromCharArray<TDest>(char[]? value)
		where TDest : AnyStrongString
	{
		ArgumentNullException.ThrowIfNull(value);

		return FromString<TDest>(value: new string(value: value));
	}

	public static TDest FromString<TDest>(string? value)
		where TDest : AnyStrongString
	{
		var newInstance = FromStringInternal<TDest>(value: value);
		return PerformValidation(value: newInstance);
	}

	private static TDest FromStringInternal<TDest>(string? value)
		where TDest : AnyStrongString
	{
		ArgumentNullException.ThrowIfNull(value);

		Type typeOfTDest = typeof(TDest);
		var newInstance = (TDest)Activator.CreateInstance(type: typeOfTDest)!;
		typeOfTDest.GetProperty(name: nameof(WeakString))!.SetValue(obj: newInstance, value: value);
		return newInstance;
	}

	private static TDest PerformValidation<TDest>(TDest? value)
		where TDest : AnyStrongString
	{
		if (value != null && value.IsValid())
		{
			return value;
		}

		throw new FormatException(message: $"Cannot convert \"{value}\" to {typeof(TDest).Name}");
	}

	protected static bool Validate<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>(AnyStrongString? value)
		where TValidator1 : IValidator
		where TValidator2 : IValidator
		where TValidator3 : IValidator
		where TValidator4 : IValidator
		where TValidator5 : IValidator
	{
		return value is not null && IsValid(strongString: value) && TValidator1.IsValid(strongString: value) && TValidator2.IsValid(strongString: value) && TValidator3.IsValid(strongString: value) && TValidator4.IsValid(strongString: value) && TValidator5.IsValid(strongString: value);
	}
}

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public abstract record AnyStrongString<TDerived> : AnyStrongString
	where TDerived : AnyStrongString<TDerived>
{
	public static explicit operator AnyStrongString<TDerived>(char[]? value) { return FromCharArray<TDerived>(value: value); }

	public static explicit operator AnyStrongString<TDerived>(string? value) { return FromString<TDerived>(value: value); }

	/// <summary>
	///     Returns the FileName with a single suffix removed from the end, or the original FileName if the suffix was not
	///     found
	/// </summary>
	/// <param name="suffix">The suffix to remove from the end of the FileName</param>
	/// <returns>The FileName with a suffix removed from the end, or the original FileName if the suffix was not found</returns>
	public TDerived RemoveSuffix(string? suffix)
	{
		if (suffix is not null)
		{
			return (TDerived)(EndsWith(value: suffix, comparisonType: StringComparison.Ordinal) ? WeakString[..^suffix.Length] : this);
		}

		return (TDerived)this;
	}

	/// <summary>
	///     Returns the FileName with the first suffix found removed from the end, or the original FileName if no suffix was
	///     not found
	/// </summary>
	/// <param name="suffixes">The suffixes to attempt to remove from the end of the FileName</param>
	/// <returns>The FileName with a suffix removed from the end, or the original FileName if the suffix was not found</returns>
	public TDerived RemoveSuffix(params string[]? suffixes)
	{
		if (suffixes is not null)
		{
			return RemoveSuffix(suffixes: suffixes.ToList());
		}

		return (TDerived)this;
	}

	/// <summary>
	///     Returns the FileName with the first suffix found removed from the end, or the original FileName if no suffix was
	///     not found
	/// </summary>
	/// <param name="suffixes">The suffixes to attempt to remove from the end of the FileName</param>
	/// <returns>The FileName with a suffix removed from the end, or the original FileName if the suffix was not found</returns>
	public TDerived RemoveSuffix(IEnumerable<string>? suffixes)
	{
		if (suffixes is null)
		{
			return (TDerived)this;
		}

		foreach (string suffix in suffixes)
		{
			TDerived result = RemoveSuffix(suffix: suffix);
			if (result != this)
			{
				return result;
			}
		}

		return (TDerived)this;
	}

	/// <summary>
	///     Returns the FileName with the first suffix found removed from the end, or the original FileName if no suffix was
	///     not found
	/// </summary>
	/// <param name="suffixes">The suffixes to attempt to remove from the end of the FileName</param>
	/// <returns>The FileName with a suffix removed from the end, or the original FileName if the suffix was not found</returns>
	public TDerived RemoveSuffix(IEnumerable<AnyStrongString>? suffixes)
	{
		if (suffixes is not null)
		{
			return RemoveSuffix(suffixes: suffixes.Select(selector: s => s.WeakString));
		}

		return (TDerived)this;
	}
}
