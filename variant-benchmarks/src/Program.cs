// Copyright 2022-2023 variant Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using System.Reflection;

using BenchmarkDotNet.Running;

// Disable formatting errors because dotnet format raises two contradictory errors concerning the end of the file
#pragma warning disable format
// Run all benchmarks in the assembly
BenchmarkRunner.Run(Assembly.GetCallingAssembly());