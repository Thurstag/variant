// Copyright 2022-2022 variant Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using OneOf;
using Union;

namespace System.Benchmarks; 

/// <summary>
/// Abstract benchmark of <see cref="Variant{T0, T1, T2}.Map{T}(Func{T0, T}, Func{T1, T}, Func{T2, T})"/>
/// </summary>
/// <typeparam name="T0">1st possible value type of the variant</typeparam>
/// <typeparam name="T1">2nd possible value type of the variant</typeparam>
/// <typeparam name="T2">3rd possible value type of the variant</typeparam>
[VeryLongRunJob]
[DisassemblyDiagnoser, MemoryDiagnoser]
public abstract class Map3Benchmark<T0, T1, T2> where T2 : notnull where T1 : notnull where T0 : notnull {

    private readonly Variant<T0, T1, T2> _variant;
    private OneOf<T0, T1, T2> _oneOf;
    private readonly Union<T0, T1, T2> _union;
    private readonly UnionClass<T0, T1, T2> _unionClass;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="t0Supplier">Supplier returning a <see cref="T0"/></param>
    /// <param name="t1Supplier">Supplier returning a <see cref="T1"/></param>
    /// <param name="t2Supplier">Supplier returning a <see cref="T2"/></param>
    protected Map3Benchmark(Func<T0> t0Supplier, Func<T1> t1Supplier, Func<T2> t2Supplier) {
        switch (RandomNumberGenerator.GetInt32(0, 3)) {
            case 0:
                var t0 = t0Supplier();
                _variant = t0;
                _oneOf = t0;
                _union = t0;
                _unionClass = t0;
                break;
            
            case 1:
                var t1 = t1Supplier();
                _variant = t1;
                _oneOf = t1;
                _union = t1;
                _unionClass = t1;
                break;
            
            case 2:
                var t2 = t2Supplier();
                _variant = t2;
                _oneOf = t2;
                _union = t2;
                _unionClass = t2;
                break;
            
            default:
                throw new InvalidOperationException("Unreachable code");
        }
    }

    [Benchmark(Baseline = true)]
    public int Variant() => _variant.Map(t => t.GetHashCode(), t => t.GetHashCode(), t => t.GetHashCode());
    
    [Benchmark]
    public int OneOf() => _oneOf.Match(t => t.GetHashCode(), t => t.GetHashCode(), t => t.GetHashCode());
    
    [Benchmark]
    public int Union() => _union.Switch(t => t.GetHashCode(), t => t.GetHashCode(), t => t.GetHashCode());
    
    [Benchmark]
    public int UnionClass() => _unionClass.Switch(t => t.GetHashCode(), t => t.GetHashCode(), t => t.GetHashCode());
}