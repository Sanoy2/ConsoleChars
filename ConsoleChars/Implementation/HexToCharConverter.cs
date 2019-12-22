using ConsoleChars.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleChars.Implementation
{
    public class HexToCharConverter : IHexToCharConverter
    {
        public char ConvertToChar(string hex)
        {
            string prefixedHex = "0x" + hex;
            int intValue = Convert.ToInt32(prefixedHex, 16);
            byte[] bytes = BitConverter.GetBytes(intValue);

            Encoding encoding = Encoding.GetEncoding("UTF-8");
            var decodedItem = encoding.GetString(bytes);

            return decodedItem.ToCharArray().First();
        }
    }
}
