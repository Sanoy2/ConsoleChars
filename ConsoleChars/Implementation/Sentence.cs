using ConsoleChars.Interfaces;
using ConsoleChars.Others;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleChars.Implementation
{
    public class Sentence : ISentence
    {
        private readonly ISupportedCharactersChecker supportedCharactersChecker;
        private readonly ICharacterFactory characterFactory;
        private readonly ICharToHexConverter charToHexConverter;

        public string Value { get; }
        public int SpaceBetweenWordsLength { get; }

        public Sentence(string text, int spaceBetweenWordsLength = 2)
        {
            this.supportedCharactersChecker = new SupportedCharactersChecker();
            this.charToHexConverter = new CharToHexConverter();
            this.characterFactory = new CharacterFactory(this.supportedCharactersChecker, this.charToHexConverter);

            this.ValidateWithException(text);

            if(spaceBetweenWordsLength < 1)
            {
                spaceBetweenWordsLength = 2;
            }

            this.SpaceBetweenWordsLength = spaceBetweenWordsLength;
            this.Value = text;
        }

        public bool IsSupported(string text)
        {
            return this.supportedCharactersChecker.AreAllSupported(text);
        }

        public bool IsSupported(string text, out IEnumerable<char> NotSupportedCharacters)
        {
            return this.supportedCharactersChecker.AreAllSupported(text, out NotSupportedCharacters);
        }

        private void ValidateWithException(string text)
        {
            if(text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            text = text.Trim();

            bool areCharactersSupported;
            IEnumerable<char> notSupportedCharacters;
            areCharactersSupported = this.supportedCharactersChecker.AreAllSupported(text, out notSupportedCharacters);

            if (areCharactersSupported == false)
            {
                string message = MessagesBuilder.NotSupportedCharacters(notSupportedCharacters);
                throw new NotSupportedException(message);
            }
        }

        public override string ToString()
        {
            return this.ToMediumString();
        }

        private string ToMediumString()
        {
            var chars = this.CreateCharactersCollection();
            var builder = new StringBuilder();

            for (int i = 0; i < Character.MediumHeight; i++)
            {
                foreach (var character in chars)
                {
                    builder.Append(character.MediumStringLines.Skip(i).First());
                    builder.Append(this.GetSpaceBetweenWords());
                }
                
                builder.AppendLine();
            }

            return builder.ToString();
        }

        private IList<Character> CreateCharactersCollection()
        {
            List<Character> chars = new List<Character>();

            foreach (var character in this.Value)
            {
                chars.Add(this.characterFactory.Create(character));
            }

            return chars;
        }

        private string GetSpaceBetweenWords()
        {
            return new string(' ', this.SpaceBetweenWordsLength);
        }
    }
}
