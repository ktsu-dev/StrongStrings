// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

#pragma warning disable CS1591

namespace ktsu.StrongStrings;

public interface IValidator
{
	public static abstract bool IsValid(AnyStrongString? strongString);
}

public abstract record NoValidator : IValidator
{
	public static bool IsValid(AnyStrongString? strongString) => true;
}
