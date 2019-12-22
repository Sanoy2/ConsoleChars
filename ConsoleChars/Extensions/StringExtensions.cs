using ConsoleChars.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChars.Extensions
{
    public static class StringExtensions
    {
        public static Sentence ToSentence(this string text)
        {
            return new Sentence(text);
        }
    }
}
