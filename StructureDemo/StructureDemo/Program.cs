using System;

namespace StructureDemo
{
    public class Program
    {
        private static String DateAsText { get; } = "10 23 2022";

        public static void Main()
        {
            (int month, int day, int year) date = DateWithSubstring();
            Console.WriteLine(date);
            date = DateWithSpan();
            Console.WriteLine(date);
        }

        //Tuple type return
        public static (int month, int day, int year) DateWithSubstring()
        {
            String monthAsText = DateAsText.Substring(0, 2);
            String dayAsText = DateAsText.Substring(3, 2);
            String yearAsText = DateAsText.Substring(6);
            int month = int.Parse(monthAsText);
            int day = int.Parse(dayAsText);
            int year = int.Parse(yearAsText);
            return (month, day, year);
        }

        //Tuple type return
        public static (int month, int day, int year) DateWithSpan()
        {
            ReadOnlySpan<Char> dateAsSpan = DateAsText;
            ReadOnlySpan<Char> monthAsText = dateAsSpan.Slice(0, 2);
            ReadOnlySpan<Char> dayAsText = dateAsSpan.Slice(3, 2);
            ReadOnlySpan<Char> yearAsText = dateAsSpan.Slice(6);
            int month = int.Parse(monthAsText);
            int day = int.Parse(dayAsText);
            int year = int.Parse(yearAsText);
            return (month, day, year);
        }
    }
}