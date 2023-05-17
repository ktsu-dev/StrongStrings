using System.Diagnostics;

namespace kts.io.StrongStrings
{

	public interface IStrongString : IEquatable<IStrongString>
	{
		string Value { get; init; }
		IStrongString FromString(string? value);
		IStrongString SanitizeInput();
		bool IsValid();
	}

	[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
	public abstract record class StrongString<T> : IStrongString where T : StrongString<T>
	{
		public string Value { get; init; } = string.Empty;
		protected string GetDebuggerDisplay() => $"({GetType().Name})\"{ToString()}\"";
		public override int GetHashCode() => HashCode.Combine(Value);
		public bool Equals(IStrongString? other) => ReferenceEquals(this, other) || (other?.GetType() == GetType() && other.Value.Equals(Value, StringComparison.Ordinal));
		public override string ToString() => Value;
		public virtual bool IsValid() => true;
		public virtual IStrongString SanitizeInput() => this;

		public static implicit operator string(StrongString<T> value) => value?.ToString() ?? string.Empty;
		public static explicit operator StrongString<T>(string? value) => (StrongString<T>)FromStringInternal(value);
		public IStrongString FromString(string? value) => FromStringInternal(value);
		private static IStrongString FromStringInternal(string? value)
		{
			if (value is null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			var newInstance = (T)Activator.CreateInstance(typeof(T), value)!;
			return newInstance.IsValid() ? (StrongString<T>)newInstance.SanitizeInput() : throw new FormatException($"Cannot convert \"{value}\" to {typeof(T).Name}");
		}
	}
}
