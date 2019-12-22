using System;
using ConsoleChars;
using ConsoleChars.Implementation;
using ConsoleChars.Interfaces;

namespace ConsoleCharsCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            var checker = new SupportedCharactersChecker();

            ISentence text = new Sentence("CHYBA");

            Console.WriteLine(text.MediumString);

        }
    }
}
