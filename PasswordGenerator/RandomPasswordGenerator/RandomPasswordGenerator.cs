using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordGenerator.RandomPasswordGenerator
{
    internal class RandomPasswordGenerator
    {
        private readonly Random _random = new();

        private static readonly char[] _uppercaseCharacterSet = GetCharacterSet('A', 'Z');

        private static readonly char[] _lowercaseCharacterSet = GetCharacterSet('a', 'z');

        private static readonly char[] _numbersCharacterSet = GetCharacterSet('0', '9');

        private static readonly char[] _symbolsCharacterSet = @"!#$%&()*+@\[]^_{}".ToCharArray();

        public int Length { get; set; }

        public bool Uppercase { get; set; }

        public bool Lowercase { get; set; }

        public bool Numbers { get; set; }

        public bool Symbols { get; set; }

        public RandomPasswordGenerator()
        {
            _random = new();
        }

        public RandomPasswordGenerator(Random random,
                                 int length,
                                 bool uppercase,
                                 bool lowercase,
                                 bool numbers,
                                 bool symbols)
        {
            _random = random;
            Length = length;
            Uppercase = uppercase;
            Lowercase = lowercase;
            Numbers = numbers;
            Symbols = symbols;
        }

        public RandomPasswordGenerator(int length,
                                 bool uppercase,
                                 bool lowercase,
                                 bool numbers,
                                 bool symbols)
        {
            Length = length;
            Uppercase = uppercase;
            Lowercase = lowercase;
            Numbers = numbers;
            Symbols = symbols;
        }

        private static char[] GetCharacterSet(char from, char to)
        {
            var maxIndex = to - from;
            var characters = new char[maxIndex + 1];

            for (var i = from; i <= to; i++) {
                characters[maxIndex - (to - i)] = i;
            }

            return characters;
        }

        public string Next()
        {
            if (!Uppercase
                && !Lowercase
                && !Numbers
                && !Symbols) {
                return string.Empty;
            }

            var sets = new List<char[]>(4);

            if (Uppercase) {
                sets.Add(_uppercaseCharacterSet);
            }

            if (Lowercase) {
                sets.Add(_lowercaseCharacterSet);
            }

            if (Numbers) {
                sets.Add(_numbersCharacterSet);
            }

            if (Symbols) {
                sets.Add(_symbolsCharacterSet);
            }

            var password = new StringBuilder();
            var maxIndex = sets.Sum(set => set.Length);

            for (var i = 0; i < Length; i++) {
                var randomIndex = _random.Next(maxIndex);

                foreach (var set in sets) {
                    if (randomIndex - set.Length < 0) {
                        password.Append(set[randomIndex]);
                        break;
                    }

                    randomIndex -= set.Length;
                }
            }

            return password.ToString();
        }
    }
}
