using ConsoleChars.Interfaces;
using ConsoleChars.Others;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChars.Implementation
{
    public class Sentence : ISentence
    {
        private readonly ISupportedCharactersChecker supportedCharactersChecker;
        private readonly ICharacterFactory characterFactory;

        public string MediumString => ToMediumString();

        public string Value { get; }

        public Sentence(string text)
        {
            this.supportedCharactersChecker = new SupportedCharactersChecker();
            this.characterFactory = new CharacterFactory(this.supportedCharactersChecker);

            this.ValidateWithException(text);

            this.Value = text;
        }

        private void ValidateWithException(string text)
        {
            if(text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

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
            return this.Value;
        }

        private string ToMediumString()
        {
            return string.Empty;
        }

    }
}
