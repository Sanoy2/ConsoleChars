using ConsoleChars.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChars.Interfaces
{
    public interface ICharacterFactory
    {
        Character Create(char character);
    }
}
