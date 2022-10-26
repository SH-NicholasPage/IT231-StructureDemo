/*
 * !!!RUN IN RELEASE CONFIGURATION!!!
 */
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace StructureDemoBenchmark
{
    public class Program
    {
        static void Main()
        {
            //Run a benchmark using the MyBenchmark class.
            //All methods with a benchmark annotation will be ran.
            BenchmarkRunner.Run<MyBenchmark>();
        }
    }

    //We care about memory, so we use the MemoryDiagnoser annotation.
    [MemoryDiagnoser]
    public class MyBenchmark
    {
        private static String DateAsText { get; } = "10 26 2022";

        [Benchmark]
        public (int month, int day, int year) DateWithSubstring()//Can not be static
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
        public (int month, int day, int year) DateWithSpan()//Can not be static
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