namespace _01.StringExtensions
{
    using System;

    public class StringExtensionsMain
    {
        public static void Main(string[] args)
        {
            string letter = "hi my name is";

            var output = letter.ToByteArray();

            Console.WriteLine(output);
        } 
    }
}