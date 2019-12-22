using ConsoleChars.Interfaces;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleChars.Implementation
{
    public class SupportedCharactersChecker : ISupportedCharactersChecker
    {
        private readonly ICharToHexConverter converter;

        public SupportedCharactersChecker(ICharToHexConverter converter)
        {
            this.converter = converter;
        }

        public SupportedCharactersChecker()
        {
            this.converter = new CharToHexConverter();
        }

        public bool IsSupported(char character)
        {
            string hex = this.converter.ConvertToHex(character);
            return IsSupportedUsingReflection(hex);
        }

        public bool AreAllSupported(string text, out IEnumerable<char> NotSupportedCharacters)
        {
            IList<char> notSupportedChars = new List<char>();
            foreach (var character in text)
            {
                if (this.IsSupported(character) == false)
                {
                    notSupportedChars.Add(character);
                }
            }

            NotSupportedCharacters = notSupportedChars.AsEnumerable<char>();
            return !NotSupportedCharacters.Any();
        }

        private bool IsSupportedUsingReflection(string hex)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            IEnumerable<Type> classes = assembly.GetTypes()
                .Where(n => n.IsClass)
                .Where(n => !n.IsAbstract)
                .Where(n => n.IsSubclassOf(typeof(Character)));

            IEnumerable<string> names = classes.Select(n => n.Name.Replace("Character_", string.Empty));

            return names.Contains(hex);
        }
    }
}
