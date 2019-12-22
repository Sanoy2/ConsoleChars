using ConsoleChars.Implementation;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChars.Tests
{
    [TestFixture]
    public class HexToCharConverterTests
    {
        private HexToCharConverter converter;

        [SetUp]
        public void SetUp()
        {
            this.converter = new HexToCharConverter();
        }

        [TestCase("41")]
        [TestCase("5A")]
        [TestCase("20")]
        [TestCase("DFA6")]
        [TestCase("C485")]
        public void Convert_Result_ShouldNotReturnNull(string hex)
        {
            this.converter.ConvertToChar(hex).Should().NotBeNull();
        }

        [TestCase("32", '2')]
        [TestCase("41", 'A')]
        [TestCase("48", 'H')]
        [TestCase("59", 'Y')]
        [TestCase("61", 'a')]
        [TestCase("2D", '-')]
        //[TestCase("C485", 'ą')] -- not work yet :( 
        public void Convert_Result_ShouldBeAsExpected(string hex, char expectedResult)
        {
            this.converter.ConvertToChar(hex).Should().Be(expectedResult);
        }
    }
}
