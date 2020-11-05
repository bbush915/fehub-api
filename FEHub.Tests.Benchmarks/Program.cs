//-----------------------------------------------------------------------------
// <copyright file="Program.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using BenchmarkDotNet.Running;

namespace FEHub.Tests.Benchmarks
{
    internal sealed class Program
    {
        public static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}
