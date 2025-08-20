using System;

Console.WriteLine("Hello from AOT Cross-Compile Test!");
Console.WriteLine($"Current OS: {Environment.OSVersion}");
Console.WriteLine($"Runtime Identifier: {System.Runtime.InteropServices.RuntimeInformation.RuntimeIdentifier}");
Console.WriteLine($"Process Architecture: {System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture}");
Console.WriteLine("Testing cross-platform AOT compilation...");
