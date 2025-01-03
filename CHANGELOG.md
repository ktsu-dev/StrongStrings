## v1.2.26 (patch)

Changes since v1.2.25:

- Add conditional build arguments for dotnet build command ([@matt-edmondson](https://github.com/matt-edmondson))
- Renamed metadata files ([@matt-edmondson](https://github.com/matt-edmondson))

## v1.2.21 (patch)

Changes since v1.2.20:

- Replace LICENSE file with LICENSE.md and update copyright information ([@matt-edmondson](https://github.com/matt-edmondson))

## v1.2.16 (patch)

Changes since v1.2.15:

- Refactor assertions and add suppress warnings ([@matt-edmondson](https://github.com/matt-edmondson))

## v1.2.13 (patch)

Changes since v1.2.12:

- Refactor MakeCanonical and As methods in AnyStrongString ([@matt-edmondson](https://github.com/matt-edmondson))

## v1.2.12 (patch)

Changes since v1.2.11:

- Refactor AnyStrongString with MakeCanonical method ([@matt-edmondson](https://github.com/matt-edmondson))
- Suppress CA1859 warning and re-indent PreBuild target ([@matt-edmondson](https://github.com/matt-edmondson))
- Update namespace from ktsu.io.StrongStrings to ktsu.StrongStrings ([@matt-edmondson](https://github.com/matt-edmondson))

## v1.2.7 (patch)

Changes since v1.2.6:

- Change build schedule to nightly and on push ([@matt-edmondson](https://github.com/matt-edmondson))

## v1.2.6 (patch)

Changes since v1.2.5:

- Fix concurrency and run every 5 mins ([@matt-edmondson](https://github.com/matt-edmondson))
- Update dotnet.yml ([@matt-edmondson](https://github.com/matt-edmondson))

## v1.2.0 (minor)

Changes since 1.1.0:

- Add an As method to convert between different types of string strings ([@matt-edmondson](https://github.com/matt-edmondson))
- Migrate ktsu.io to ktsu namespace ([@matt-edmondson](https://github.com/matt-edmondson))

## v1.0.1 (major)

Changes since 0.0.0.0:

- Add a JsonConverter for use with System.Text.Json ([@matt-edmondson](https://github.com/matt-edmondson))
- Add builtin json convertor for System.Text.Json ([@matt-edmondson](https://github.com/matt-edmondson))
- Add github package support ([@matt-edmondson](https://github.com/matt-edmondson))
- Add more unit tests ([@matt-edmondson](https://github.com/matt-edmondson))
- Assign dependabot PRs to matt ([@matt-edmondson](https://github.com/matt-edmondson))
- Avoid double upload of symbols package ([@matt-edmondson](https://github.com/matt-edmondson))
- Bump version to 1.0.0-alpha.2 ([@matt-edmondson](https://github.com/matt-edmondson))
- Code style cleanup and add symbols and source to the nuget package ([@matt-edmondson](https://github.com/matt-edmondson))
- Correct a typo in the namespace ([@matt-edmondson](https://github.com/matt-edmondson))
- Create dependabot-merge.yml ([@matt-edmondson](https://github.com/matt-edmondson))
- Dont try to push packages when building pull requests ([@matt-edmondson](https://github.com/matt-edmondson))
- Enable dependabot and sourcelink ([@matt-edmondson](https://github.com/matt-edmondson))
- Fix a bunch of interface problems and add a unit test project ([@matt-edmondson](https://github.com/matt-edmondson))
- Fix build to properly read variables from files ([@matt-edmondson](https://github.com/matt-edmondson))
- Fix some style warnings ([@matt-edmondson](https://github.com/matt-edmondson))
- Formatted with resharper and add t4 templating for the inheritance hierarchy ([@matt-edmondson](https://github.com/matt-edmondson))
- Implement the full interface of System.String and add support for validators ([@matt-edmondson](https://github.com/matt-edmondson))
- Initial commit ([@matt-edmondson](https://github.com/matt-edmondson))
- Make code generation use csx rather than t4 so that it works with Rider ([@matt-edmondson](https://github.com/matt-edmondson))
- Migrate from .project.props to Directory.Build.props ([@matt-edmondson](https://github.com/matt-edmondson))
- Read from AUTHORS file during build ([@matt-edmondson](https://github.com/matt-edmondson))
- Read from VERSION when building ([@matt-edmondson](https://github.com/matt-edmondson))
- Read PackageDescription from DESCRIPTION file ([@matt-edmondson](https://github.com/matt-edmondson))
- Rearrange the inheritance hierarchy to be better and split out tests into categories ([@matt-edmondson](https://github.com/matt-edmondson))
- Rearrange the interface/base class to make using it as a parameter, casting to derived types, and calling statics easier ([@matt-edmondson](https://github.com/matt-edmondson))
- Refactor empty array returns in AnyStrongString ([@matt-edmondson](https://github.com/matt-edmondson))
- Remove obsolete t4 junk from project file ([@matt-edmondson](https://github.com/matt-edmondson))
- Remove old resharper settings ([@matt-edmondson](https://github.com/matt-edmondson))
- Remove suffix methods with are now in ktsu.io.Extensions, and do a cleanup of old cruft ([@matt-edmondson](https://github.com/matt-edmondson))
- Test signing ([@matt-edmondson](https://github.com/matt-edmondson))
- Update build config ([@matt-edmondson](https://github.com/matt-edmondson))
- Update build scripts ([@matt-edmondson](https://github.com/matt-edmondson))
- Update Directory.Build.props ([@matt-edmondson](https://github.com/matt-edmondson))
- Update Directory.Build.targets ([@matt-edmondson](https://github.com/matt-edmondson))
- Update dotnet.yml ([@matt-edmondson](https://github.com/matt-edmondson))
- Update github workflow to support submodules ([@matt-edmondson](https://github.com/matt-edmondson))
- Update LICENSE ([@matt-edmondson](https://github.com/matt-edmondson))
- Update nuget.config ([@matt-edmondson](https://github.com/matt-edmondson))
- Update readme and description ([@matt-edmondson](https://github.com/matt-edmondson))
- Update README.md ([@matt-edmondson](https://github.com/matt-edmondson))
- Upgrade actions ([@matt-edmondson](https://github.com/matt-edmondson))
- Use environment files for reading VERSION as set-output is deprecated ([@matt-edmondson](https://github.com/matt-edmondson))
- Use fully qualified names for templated types to avoid having to provide the namespace ([@matt-edmondson](https://github.com/matt-edmondson))
- v1.0.0-alpha.6 ([@matt-edmondson](https://github.com/matt-edmondson))


