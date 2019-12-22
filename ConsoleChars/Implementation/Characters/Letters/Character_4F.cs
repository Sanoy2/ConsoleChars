﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleChars.Implementation.Characters.Letters
{
    public class Character_4F : Character
    {
        // O
        protected override IList<string> ToMediumString()
        {
            List<string> lines = new List<string>();

            lines.Add(" #### ");
            lines.Add("#    #");
            lines.Add("#    #");
            lines.Add("#    #");
            lines.Add(" #### ");
            lines.Add("      ");

            return lines;
        }
    }
}