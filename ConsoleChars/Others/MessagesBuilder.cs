using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChars.Others
{
    public static class MessagesBuilder
    {
        public static string NotSupportedCharacter(char character)
        {
            return Messages.NotSupportedCharacter.Replace("{0}", character.ToString());
        }

        public static string NotSupportedCharacters(IEnumerable<char> characters)
        {
            string charactersAsString = "";
            foreach (var character in characters)
            {
                charactersAsString += character;
            }

            return NotSupportedCharacters(charactersAsString);
        }

        public static string NotSupportedCharacters(string characters)
        {
            if (characters.Length == 1)
            {
                return NotSupportedCharacter(characters.ToCharArray()[0]);
            }

            string message = Messages.NotSupportedCharacters;
            string notSupportedCharacters = "";
            foreach (var character in characters.ToCharArray())
            {
                notSupportedCharacters += character.ToString() + "  ";
            }

            notSupportedCharacters = notSupportedCharacters.Trim();
            return message.Replace("{0}", notSupportedCharacters);
        }
    }
}
