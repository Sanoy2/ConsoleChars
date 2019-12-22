using ConsoleChars.Exceptions;
using ConsoleChars.Implementation.Characters;
using ConsoleChars.Interfaces;
using ConsoleChars.Others;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChars.Implementation
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly ISupportedCharactersChecker supportedCharactersChecker;

        public CharacterFactory(ISupportedCharactersChecker supportedCharactersChecker)
        {
            this.supportedCharactersChecker = supportedCharactersChecker;
        }

        public Character Create(char character)
        {
            this.ValidateWithException(character);

            return this.TakeProperCharacter(character);
        }

        private Character TakeProperCharacter(char character)
        {
            string namespaceName = "ConsoleChars.Implementation.Characters.";
            string className = "Character_" + character;

            string expectedType = namespaceName + className;

            Type type = Type.GetType(expectedType);
            return Activator.CreateInstance(type) as Character;
        }

        private void ValidateWithException(char character)
        {
            bool isCharacterSupported = this.supportedCharactersChecker.IsSupported(character);

            if (isCharacterSupported == false)
            {
                string errorMessage = MessagesBuilder.NotSupportedCharacter(character);
                throw new CharacterNotSupportedException(errorMessage);
            }
        }
    }
}
