﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleChars.Implementation.Characters.Digits
{
    public class Character_57 : Character
    {
        //W
        protected override IList<string> ToMediumString()
        {
            List<string> lines = new List<string>();

            lines.Add("#     #");
            lines.Add("#     #");
            lines.Add("#     #");
            lines.Add("# # # #");
            lines.Add(" # # # ");
            lines.Add("       ");

            return lines;
        }
    }
}
