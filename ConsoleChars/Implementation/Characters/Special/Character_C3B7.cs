using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleChars.Implementation.Characters.Special
{
    public class Character_C3B7 : Character
    {
        // Division mark
        protected override IList<string> ToMediumString()
        {
            List<string> lines = new List<string>();

            lines.Add("  #  ");
            lines.Add("     ");
            lines.Add("#####");
            lines.Add("     ");
            lines.Add("  #  ");
            lines.Add("    " );

            return lines;
        }
    }
}
