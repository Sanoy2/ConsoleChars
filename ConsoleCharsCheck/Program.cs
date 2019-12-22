using System;
using ConsoleChars.Extensions;
using ConsoleChars.Implementation;

namespace ConsoleCharsCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "HELLO, WORLDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD!";
            Console.WriteLine(text.ToSentence());

            var sentence = new Sentence(text);
            Console.WriteLine(sentence);
        }
    }
}
