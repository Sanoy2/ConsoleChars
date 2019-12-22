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
        private readonly ICharToHexConverter converter;

        public CharacterFactory(ISupportedCharactersChecker supportedCharactersChecker, ICharToHexConverter converter)
        {
            this.supportedCharactersChecker = supportedCharactersChecker;
            this.converter = converter;
        }

        public Character Create(char character)
        {
            this.ValidateWithException(character);
            string hex = this.converter.ConvertToHex(character);

            Type type = this.TakeCharacterUsingReflection(hex);
            return this.CreateInstance(type);
        }

        private Type TakeCharacterUsingReflection(string hex)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            string fullName = assembly.GetTypes()
                .Where(n => n.IsClass)
                .Where(n => !n.IsAbstract)
                .Where(n => n.IsSubclassOf(typeof(Character)))
                .Single(n => n.Name.Split('_').Skip(1).First() == hex)
                .FullName;

            Type type = Type.GetType(fullName);
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
