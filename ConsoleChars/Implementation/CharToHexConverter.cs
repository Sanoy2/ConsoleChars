using ConsoleChars.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChars.Implementation
{
    public class CharToHexConverter : ICharToHexConverter
    {
        public string ConvertToHex(char character)
        {
            Encoding utf8 = Encoding.UTF8;
            byte[] bytes = utf8.GetBytes(character.ToString());
            string hex = BitConverter.ToString(bytes);
            string hexWithoutDash = hex.Replace('-'.ToString(), string.Empty);
            return hexWithoutDash;
        }
    }
}
