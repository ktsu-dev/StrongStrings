#pragma warning disable CS1591
// Generated code. Do not modify.
namespace ktsu.io.StrongStrings;

public sealed record StrongString
		: StrongStringAbstract<StrongString>;

public sealed record StrongString<TValidator>
		: StrongStringAbstract<StrongString<TValidator>, TValidator>
		where TValidator : ktsu.io.StrongStrings.IValidator;

public sealed record StrongString<TValidator1, TValidator2>
	: StrongStringAbstract<StrongString<TValidator1, TValidator2>, TValidator1, TValidator2>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator;

public sealed record StrongString<TValidator1, TValidator2, TValidator3>
	: StrongStringAbstract<StrongString<TValidator1, TValidator2, TValidator3>, TValidator1, TValidator2, TValidator3>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator
	where TValidator3 : ktsu.io.StrongStrings.IValidator;

public sealed record StrongString<TValidator1, TValidator2, TValidator3, TValidator4>
	: StrongStringAbstract<StrongString<TValidator1, TValidator2, TValidator3, TValidator4>, TValidator1, TValidator2, TValidator3, TValidator4>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator
	where TValidator3 : ktsu.io.StrongStrings.IValidator
	where TValidator4 : ktsu.io.StrongStrings.IValidator;

public sealed record StrongString<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
	: StrongStringAbstract<StrongString<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
	where TValidator1 : ktsu.io.StrongStrings.IValidator
	where TValidator2 : ktsu.io.StrongStrings.IValidator
	where TValidator3 : ktsu.io.StrongStrings.IValidator
	where TValidator4 : ktsu.io.StrongStrings.IValidator
	where TValidator5 : ktsu.io.StrongStrings.IValidator;