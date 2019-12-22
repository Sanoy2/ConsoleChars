using ConsoleChars.Implementation;
using ConsoleChars.Interfaces;
using NUnit.Framework;
using FluentAssertions;

namespace ConsoleChars.Tests
{
    public class Tests
    {
        private ICharToHexConverter converter;

        [SetUp]
        public void Setup()
        {
            this.converter = new CharToHexConverter();
        }

        [TestCase('a')]
        [TestCase('€')]
        [TestCase('ü')]
        [TestCase('ą')]
        [TestCase('ߦ')]
        public void Convert_ResultHex_ShouldNotContainDash(char character)
        {
            string hex = this.converter.ConvertToHex(character);

            hex.Should().NotContain("-");
        }

        [Test]
        public void Convert_ResultHex_ShouldNotReturnNull()
        {
            char character = 'a';

            string hex = this.converter.ConvertToHex(character);

            hex.Should().NotBeNull();
        }

        [Test]
        public void Convert_ResultHex_ShouldNotReturnEmptyString()
        {
            char character = 'a';

            string hex = this.converter.ConvertToHex(character);

            hex.Should().NotBeEmpty();
        }


        [Test]
        public void Convert_ResultHex_ShouldNotReturnWhiteSpace()
        {
            char character = 'a';

            string hex = this.converter.ConvertToHex(character);

            hex.Should().NotBeNullOrWhiteSpace();
        }

        [TestCase('a', "61")]
        [TestCase('A', "41")]
        [TestCase('z', "7A")]
        [TestCase('Z', "5A")]
        [TestCase(';', "3B")]
        [TestCase(' ', "20")]
        [TestCase('ą', "C485")] 
        [TestCase('ߦ', "DFA6")]
        public void Convert_ResultHex_ShouldNotReturnWhiteSpace(char character, string expectedHex)
        {
            string hex = this.converter.ConvertToHex(character);

            hex.Should().Be(expectedHex);
        }
    }
}