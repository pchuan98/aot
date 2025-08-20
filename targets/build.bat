@echo off
cd /d "%~dp0"
dotnet pack AotCrossCompile.csproj -o "%~dp0..\build" -p:PackageVersion=1.0.0