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
            var builder = new StringBuilder();

            foreach (var line in this.MediumStringLines)
            {
                builder.AppendLine(line);
            }

            return builder.ToString();
        }
    }
}
