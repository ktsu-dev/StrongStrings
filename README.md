# ⚠️ DEPRECATED

**This project is no longer maintained.** Its functionality has been moved to [ktsu.Semantics](https://github.com/ktsu-dev/Semantics).

Please migrate to the new library for continued support and updates.

---

# ktsu.StrongStrings

> A transparent wrapper around strings that provides strong typing, compile-time feedback, and runtime validation.

[![License](https://img.shields.io/github/license/ktsu-dev/StrongStrings)](https://github.com/ktsu-dev/StrongStrings/blob/main/LICENSE.md)
[![NuGet](https://img.shields.io/nuget/v/ktsu.StrongStrings.svg)](https://www.nuget.org/packages/ktsu.StrongStrings/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/ktsu.StrongStrings.svg)](https://www.nuget.org/packages/ktsu.StrongStrings/)
[![Build Status](https://github.com/ktsu-dev/StrongStrings/workflows/build/badge.svg)](https://github.com/ktsu-dev/StrongStrings/actions)
[![GitHub Stars](https://img.shields.io/github/stars/ktsu-dev/StrongStrings?style=social)](https://github.com/ktsu-dev/StrongStrings/stargazers)

## Introduction

`ktsu.StrongStrings` is a .NET library that provides a way to create strongly-typed wrappers around standard strings. It gives you the benefits of strong typing, compile-time feedback, and runtime validation while maintaining full compatibility with string operations. The intention is to provide usage context and validation to naked strings in a similar way that Enums do for integers.

## Features

- **Strong Typing**: Create distinct types for different string usages (e.g., EmailAddress, UserId, Url)
- **Compile-Time Safety**: Prevent mixing of semantically different strings
- **Runtime Validation**: Apply custom validation rules that throw exceptions for invalid data
- **Transparent Usage**: Works with existing string APIs through implicit conversion
- **String Operation Support**: Full access to standard string methods and properties
- **Immutability**: Implemented as records for value semantics and immutability

## Installation

### Package Manager Console

```powershell
Install-Package ktsu.StrongStrings
```

### .NET CLI

```bash
dotnet add package ktsu.StrongStrings
```

### Package Reference

```xml
<PackageReference Include="ktsu.StrongStrings" Version="x.y.z" />
```

## Usage Examples

### Basic Example

```csharp
using ktsu.StrongStrings;

// Create a strong type by deriving a record class from StrongStringAbstract<TDerived>:
public record class MyStrongString : StrongStringAbstract<MyStrongString> { }

public class MyDemoClass
{
    public MyStrongString Stronk { get; set; } = new();

    public static void Demo(MyStrongString inStrongString, string inSystemString, out MyStrongString outStrongString, out string outSystemString)
    {
        // You can implicitly cast down to a System.String
        outSystemString = inStrongString;

        // You must explicitly cast up to a StrongString
        outStrongString = (MyStrongString)inSystemString;

        //You can provide a StrongString to a method that expects a System.String
        Path.Combine(inStrongString, inSystemString);

        // You can use the .WeakString property or the .ToString() method to get the value of the underlying System.String
        outSystemString = inStrongString.WeakString;
        outSystemString = inStrongString.ToString();

        // You can not implicitly cast up to a StrongString
        // outStrongString = inSystemString; // This will not compile

        // You can not cast from one StrongString to another
        // OtherStrongString other = inStrongString; // This will not compile
        // OtherStrongString other = (OtherStrongString)inStrongString; // This will not compile either
    }
}
```

### Validation Example

```csharp
public abstract class StartsWithHttp : IValidator
{
    public static bool IsValid(AnyStrongString? strongString)
    {
        ArgumentNullException.ThrowIfNull(strongString);

        return strongString.StartsWith("http", StringComparison.InvariantCultureIgnoreCase);
    }
}

public abstract class EndsWithDotCom : IValidator
{
    public static bool IsValid(AnyStrongString? strongString)
    {
        ArgumentNullException.ThrowIfNull(strongString);

        return strongString.EndsWith(".com", StringComparison.InvariantCultureIgnoreCase);
    }
}

public record class MyValidatedString : StrongStringAbstract<MyValidatedString, StartsWithHttp, EndsWithDotCom> { }

// This will work:
MyValidatedString valid = (MyValidatedString)"http://example.com";

// This will throw a FormatException:
MyValidatedString invalid = (MyValidatedString)"ftp://example.net";
```

## Advanced Usage

### Creating Domain-Specific String Types

```csharp
using ktsu.StrongStrings;

// Define validators
public abstract class ValidEmail : IValidator
{
    private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    
    public static bool IsValid(AnyStrongString? strongString)
    {
        ArgumentNullException.ThrowIfNull(strongString);
        return EmailRegex.IsMatch(strongString.ToString());
    }
}

// Create domain-specific types
public record class EmailAddress : StrongStringAbstract<EmailAddress, ValidEmail> { }
public record class Username : StrongStringAbstract<Username> { }
public record class UserId : StrongStringAbstract<UserId> { }

// Use in a service
public class UserService
{
    public User GetUser(UserId id) { /* ... */ }
    
    public void SendEmail(EmailAddress to, string subject) { /* ... */ }
    
    // Type safety ensures you can't pass a Username where UserId is expected
}
```

### Modifying Strong Strings

```csharp
// Strong strings are immutable, but you can create new ones with modifications
public record class Path : StrongStringAbstract<Path> { }

Path basePath = (Path)"/home/user";

// Add prefixes or suffixes
Path documentsPath = basePath.WithSuffix("/documents");  // "/home/user/documents"
Path etcPath = (Path)"/etc".WithSuffix("/config");       // "/etc/config"

// Combine with standard string methods
Path combined = (Path)(basePath + "/downloads");         // "/home/user/downloads"
```

## API Reference

### StrongStringAbstract<TDerived>

The base class for creating strongly-typed strings.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `WeakString` | `string` | The underlying string value |
| `Length` | `int` | Length of the string |

#### Methods

| Name | Return Type | Description |
|------|-------------|-------------|
| `IsEmpty()` | `bool` | Checks if the string is empty |
| `IsValid()` | `bool` | Validates the string against defined validators |
| `WithPrefix(string)` | `TDerived` | Creates a new instance with the specified prefix |
| `WithSuffix(string)` | `TDerived` | Creates a new instance with the specified suffix |
| `*` | `*` | All standard string methods are available |

### IValidator Interface

Interface for implementing custom validation rules.

#### Methods

| Name | Return Type | Description |
|------|-------------|-------------|
| `IsValid(AnyStrongString?)` | `bool` | Static method that validates a string |

## Contributing

Contributions are welcome! Here's how you can help:

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

Please make sure to update tests as appropriate.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
