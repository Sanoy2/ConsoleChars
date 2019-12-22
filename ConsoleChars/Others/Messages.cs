using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChars.Others
{
    public static class Messages
    {
        public static string NotSupportedCharacter { get; } = "This character ( {0} ) is not supported";
        public static string NotSupportedCharacters { get; } = "These characters ( {0} ) are not supported";
        public static string NotSupportedAtLeastOneCharacter { get; } = "At leas one character in the sentence is not supported";
    }
}
