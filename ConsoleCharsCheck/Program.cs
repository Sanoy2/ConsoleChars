using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ConsoleChars;
using ConsoleChars.Implementation;
using ConsoleChars.Implementation.Characters.Digits;
using ConsoleChars.Implementation.Characters.Letters;
using ConsoleChars.Interfaces;

namespace ConsoleCharsCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            var sentence = new Sentence("Dupa");
            Console.WriteLine(sentence);
        }
    }
}
