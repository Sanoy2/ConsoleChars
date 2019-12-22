using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChars.Interfaces
{
    public interface ISupportedCharactersChecker
    {
        bool IsSupported(char character);
        bool AreAllSupported(string text, out IEnumerable<char> NotSupportedCharacters);
    }
}
