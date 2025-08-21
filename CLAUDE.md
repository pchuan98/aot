# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is **AotCrossCompile** - an MSBuild targets package that enables cross-platform AOT (Ahead of Time) compilation with Native AOT support. The project allows Windows developers to cross-compile .NET applications for Linux targets (x64, ARM64, and musl variants) using the zig toolchain.

## Architecture

- **targets/**: Contains MSBuild targets and tooling
  - `PublishAotCross.targets`: Main targets file that orchestrates cross-compilation and cleanup
  - `Crosscompile.targets`: Core cross-compilation logic, sets up zig toolchain and target triples
  - `clang.cmd`: Wrapper script that translates clang commands to zig cc
  - `aot.nuspec`: NuGet package specification

- **test/**: Sample application to verify cross-compilation functionality
  - Simple console app that displays runtime information

## Common Development Commands

### Building the package:
```bash
dotnet pack targets/aot.nuspec -p:PackageVersion=1.0.0
```

### Testing cross-compilation:
```bash
cd test
dotnet publish -c Release -r linux-x64
dotnet publish -c Release -r linux-arm64
dotnet publish -c Release -r linux-musl-x64
dotnet publish -c Release -r linux-musl-arm64
```

### Building the test app:
```bash
cd test
dotnet build
dotnet run
```

## Key Requirements

- **Windows host machine** (cross-compilation only works from Windows)
- **.NET with Native AOT workload** must be installed
- **zig toolchain** must be available on PATH

## Cross-Compilation Process

1. `PublishAotCross.targets` imports `Crosscompile.targets` for Linux targets on Windows
2. `SetPathToClang` target prepends the targets directory to PATH (where clang.cmd is located)
3. `OverwriteTargetTriple` target sets up proper target triples for different architectures
4. `clang.cmd` wrapper translates .NET's clang invocations to zig cc commands
5. `CleanupPublishOutput` removes debug symbols (.dbg, .pdb) in Release builds

## Supported Runtime Identifiers

- `linux-x64`
- `linux-arm64`  
- `linux-musl-x64`
- `linux-musl-arm64`

Only Windows → Linux cross-compilation is currently supported.