using ConsoleChars.Exceptions;
using ConsoleChars.Implementation.Characters;
using ConsoleChars.Interfaces;
using ConsoleChars.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleChars.Implementation
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly ISupportedCharactersChecker supportedCharactersChecker;
        private readonly string baseNamespaceName;

        public CharacterFactory(ISupportedCharactersChecker supportedCharactersChecker)
        {
            this.supportedCharactersChecker = supportedCharactersChecker;
            this.baseNamespaceName = "ConsoleChars.Implementation.Characters.";
        }

        public Character Create(char character)
        {
            this.ValidateWithException(character);
            Type type = this.TakeProperType(character);
            return this.CreateInstance(type);
        }

        private Type TakeProperType(char character)
        {
            return this.TakeProperLetterType(character) ?? this.TakeProperDigitType(character);
        }

        private Type TakeProperLetterType(char character)
        {
            string namespaceName = this.baseNamespaceName + "Letters.";
            return this.TakeCharacterUsingReflection(character, namespaceName);
        }

        private Type TakeProperDigitType(char character)
        {
            string namespaceName = this.baseNamespaceName + "Digits.";
            return this.TakeCharacterUsingReflection(character, namespaceName);
        }

        private Type TakeCharacterUsingReflection(char character, string namespaceName)
        {
            string className = "Character_" + character;

            string expectedType = namespaceName + className;

            Type type = Type.GetType(expectedType);
            return type;
        }

        private Character CreateInstance(Type type)
        {
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
