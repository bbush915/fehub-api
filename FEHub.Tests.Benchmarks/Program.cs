using BenchmarkDotNet.Running;

namespace FEHub.Tests.Benchmarks;

internal sealed class Program
{
    public static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
}
