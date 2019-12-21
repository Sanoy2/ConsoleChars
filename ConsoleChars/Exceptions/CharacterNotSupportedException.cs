using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChars.Exceptions
{
    public class CharacterNotSupportedException : Exception
    {
        public CharacterNotSupportedException() : base()
        {

        }

        public CharacterNotSupportedException(string message) : base(message)
        {

        }
    }
}
