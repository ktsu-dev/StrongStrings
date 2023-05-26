namespace ktsu.io.StrongStrings;



public abstract record StrongStringAbstract<TDerived> : AnyStrongString<TDerived>
	where TDerived : StrongStringAbstract<TDerived>;

public abstract record StrongStringAbstract<TDerived, TValidator> : AnyStrongString<TDerived>
	where TDerived : StrongStringAbstract<TDerived, TValidator>
	where TValidator : IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator, NoValidator, NoValidator, NoValidator, NoValidator>(value: this); }
}

public abstract record StrongStringAbstract<TDerived, TValidator1, TValidator2> : AnyStrongString<TDerived>
	where TDerived : StrongStringAbstract<TDerived, TValidator1, TValidator2>
	where TValidator1 : IValidator
	where TValidator2 : IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, NoValidator, NoValidator, NoValidator>(value: this); }
}

public abstract record StrongStringAbstract<TDerived, TValidator1, TValidator2, TValidator3> : AnyStrongString<TDerived>
	where TDerived : StrongStringAbstract<TDerived, TValidator1, TValidator2, TValidator3>
	where TValidator1 : IValidator
	where TValidator2 : IValidator
	where TValidator3 : IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, TValidator3, NoValidator, NoValidator>(value: this); }
}

public abstract record StrongStringAbstract<TDerived, TValidator1, TValidator2, TValidator3, TValidator4> : AnyStrongString<TDerived>
	where TDerived : StrongStringAbstract<TDerived, TValidator1, TValidator2, TValidator3, TValidator4>
	where TValidator1 : IValidator
	where TValidator2 : IValidator
	where TValidator3 : IValidator
	where TValidator4 : IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, TValidator3, TValidator4, NoValidator>(value: this); }
}

public abstract record StrongStringAbstract<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5> : AnyStrongString<TDerived>
	where TDerived : StrongStringAbstract<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
	where TValidator1 : IValidator
	where TValidator2 : IValidator
	where TValidator3 : IValidator
	where TValidator4 : IValidator
	where TValidator5 : IValidator
{
	public override bool IsValid() { return base.IsValid() && Validate<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>(value: this); }
}
