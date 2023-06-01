#load "MakeAbstract.func.csx"
#load "MakeConcrete.func.csx"

public void MakeClasses(string rootNamespace, string baseClassName, string derivedClassName)
{
	var abstractClassName = $"{derivedClassName}Abstract";
	var abstractClass = MakeAbstract(rootNamespace, baseClassName, abstractClassName);
	var concreteClass = MakeConcrete(rootNamespace, abstractClassName, derivedClassName);
	Directory.CreateDirectory("Generated");
	File.WriteAllText($"Generated/{abstractClassName}.Generated.cs", abstractClass);
	File.WriteAllText($"Generated/{derivedClassName}.Generated.cs", concreteClass);
}
