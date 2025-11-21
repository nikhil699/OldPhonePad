using System;
using OldPhonePad.Core;

namespace OldPhonePad.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OldPhonePad Demo");
            Console.WriteLine("Type a keypad input ending with '#':");

            Console.Write("> ");
            string input = Console.ReadLine() ?? string.Empty;

            string output = OldPhonePadConverter.OldPhonePad(input);

            Console.WriteLine($"Output: {output}");
        }
    }
}
