using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChars.Interfaces
{
    public interface IHexToCharConverter
    {
        char ConvertToChar(string hex);
    }
}
