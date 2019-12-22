using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChars.Interfaces
{
    public interface ISentence
    {
        string Value { get; }

        bool IsSupported(string text);
        bool IsSupported(string text, out IEnumerable<char> NotSupportedCharacters);
    }
}
