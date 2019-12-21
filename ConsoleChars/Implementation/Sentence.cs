using ConsoleChars.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChars.Implementation
{
    public class Sentence
    {
        public string MediumString => throw new NotImplementedException();

        public string Value { get; }

        public Sentence(string text)
        {
            this.Value = text;
        }

        public override string ToString()
        {
            return this.Value;
        }

        private string ToMediumString()
        {
            return string.Empty;
        }

        
    }
}
