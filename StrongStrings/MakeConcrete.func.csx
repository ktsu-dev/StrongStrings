public string MakeConcrete(string fileNamespace, string abstractClassName, string concreteClassName)
{
    return $$"""
#pragma warning disable CS1591
// Generated code. Do not modify.
namespace {{ fileNamespace}};

public sealed record {{ concreteClassName}}
		: {{ abstractClassName}}<{{ concreteClassName}}>;

public sealed record {{ concreteClassName}}<TValidator>
		: {{ abstractClassName}}<{{ concreteClassName}}<TValidator>, TValidator>
		where TValidator : ktsu.StrongStrings.IValidator;

public sealed record {{ concreteClassName}}<TValidator1, TValidator2>
	: {{ abstractClassName}}<{{ concreteClassName}}<TValidator1, TValidator2>, TValidator1, TValidator2>
	where TValidator1 : ktsu.StrongStrings.IValidator
	where TValidator2 : ktsu.StrongStrings.IValidator;

public sealed record {{ concreteClassName}}<TValidator1, TValidator2, TValidator3>
	: {{ abstractClassName}}<{{ concreteClassName}}<TValidator1, TValidator2, TValidator3>, TValidator1, TValidator2, TValidator3>
	where TValidator1 : ktsu.StrongStrings.IValidator
	where TValidator2 : ktsu.StrongStrings.IValidator
	where TValidator3 : ktsu.StrongStrings.IValidator;

public sealed record {{ concreteClassName}}<TValidator1, TValidator2, TValidator3, TValidator4>
	: {{ abstractClassName}}<{{ concreteClassName}}<TValidator1, TValidator2, TValidator3, TValidator4>, TValidator1, TValidator2, TValidator3, TValidator4>
	where TValidator1 : ktsu.StrongStrings.IValidator
	where TValidator2 : ktsu.StrongStrings.IValidator
	where TValidator3 : ktsu.StrongStrings.IValidator
	where TValidator4 : ktsu.StrongStrings.IValidator;

public sealed record {{ concreteClassName}}<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
	: {{ abstractClassName}}<{{ concreteClassName}}<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
	where TValidator1 : ktsu.StrongStrings.IValidator
	where TValidator2 : ktsu.StrongStrings.IValidator
	where TValidator3 : ktsu.StrongStrings.IValidator
	where TValidator4 : ktsu.StrongStrings.IValidator
	where TValidator5 : ktsu.StrongStrings.IValidator;
""";
}
