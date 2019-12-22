using System;
using System.Linq;
using System.Text;
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

            char a = 'ƒ';

            Encoding utf8 = Encoding.UTF8;
            var bytes = utf8.GetBytes(a.ToString());
            string hex = utf8.GetString(bytes);
            Console.WriteLine($"hex: {hex}");
        }
    }
}
