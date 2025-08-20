# AotCrossCompile

MSBuild targets for cross-platform AOT (Ahead of Time) compilation with Native AOT support.

## Features

- Cross-platform AOT compilation from Windows to Linux
- Automatic cleanup of debug symbols in Release builds
- Support for both x64 and ARM64 architectures
- Integration with clang for native compilation

## Usage

Add the package reference to your project:

```xml
<PackageReference Include="AotCrossCompile" Version="1.0.0" />
```

The targets will automatically be applied when publishing with AOT enabled:

```bash
dotnet publish -c Release -r linux-x64
```

## Supported Runtime Identifiers

- `linux-x64`
- `linux-arm64`
- `linux-musl-x64`
- `linux-musl-arm64`

## Requirements

- Windows host machine
- .NET with Native AOT workload installed
- clang toolchain (included in package)