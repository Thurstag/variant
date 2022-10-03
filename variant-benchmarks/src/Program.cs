using System.Reflection;
using BenchmarkDotNet.Running;

// Run all benchmarks in the assembly
BenchmarkRunner.Run(Assembly.GetCallingAssembly());