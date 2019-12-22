using ConsoleChars.Implementation.Characters;
using ConsoleChars.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleChars.Implementation
{
    public abstract class Character
    {
        public static int MediumHeight { get; } = 6;

        public virtual IEnumerable<string> MediumStringLines => this.ToMediumString();

        protected virtual IList<string> ToMediumString()
        {
            return Enumerable.Empty<string>().ToList();
        }

        public override string ToString()
        {
            var thisClassName = this.GetType().Name;
            var classExtension = thisClassName.Replace("Character_", string.Empty);

            IHexToCharConverter converter = new HexToCharConverter();

            return converter.ConvertToChar(classExtension).ToString();
        }
    }
}
