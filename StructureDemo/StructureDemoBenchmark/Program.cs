using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace StructureDemoBenchmark
{
    public class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<MyBenchmark>();
        }
    }

    [MemoryDiagnoser]
    public class MyBenchmark
    {
        private static String DateAsText { get; } = "10 26 2022";

        [Benchmark]
        //Tuple type return
        public (int month, int day, int year) DateWithSubstring()
        {
            String monthAsText = DateAsText.Substring(0, 2);
            String dayAsText = DateAsText.Substring(3, 2);
            String yearAsText = DateAsText.Substring(6);
            int month = int.Parse(monthAsText);
            int day = int.Parse(dayAsText);
            int year = int.Parse(yearAsText);
            return (month, day, year);
        }

        [Benchmark]
        public (int month, int day, int year) DateWithSpan()
        {
            ReadOnlySpan<char> dateAsSpan = DateAsText;
            ReadOnlySpan<char> monthAsText = dateAsSpan.Slice(0, 2);
            ReadOnlySpan<char> dayAsText = dateAsSpan.Slice(3, 2);
            ReadOnlySpan<char> yearAsText = dateAsSpan.Slice(6);
            int month = int.Parse(monthAsText);
            int day = int.Parse(dayAsText);
            int year = int.Parse(yearAsText);
            return (month, day, year);
        }
    }
}