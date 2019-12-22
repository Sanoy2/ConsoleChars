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
            var factory = new CharacterFactory(checker);

            var C = factory.Create('C');
            var H = factory.Create('H');

            ISentence text = new Sentence("CH");

            Console.WriteLine(text.MediumString);

            //Console.WriteLine(C.ToString());
            //Console.WriteLine(H.ToString());
        }
    }
}
