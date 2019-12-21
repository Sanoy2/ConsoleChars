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
        public bool IsSupported(char character)
        {
            return CheckUsingReflection(character);
        }

        private bool CheckUsingReflection(char character)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            IEnumerable<Type> classes = assembly.GetTypes()
                .Where(n => n.IsClass)
                .Where(n => !n.IsAbstract)
                .Where(n => n.IsSubclassOf(typeof(Character)));

            IEnumerable<string> names = classes.Select(n => n.Name.Replace("Character_", string.Empty));

            IEnumerable<char> characters = names.Select(n => char.Parse(n));

            return characters.Contains(character);
        }
    }
}
