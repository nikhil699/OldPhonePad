using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePad.Core
{
    public static class OldPhonePadConverter
    {
        private static readonly Dictionary<char, string> KeyMap = new()
        {
            ['1'] = "&'(",
            ['2'] = "ABC",
            ['3'] = "DEF",
            ['4'] = "GHI",
            ['5'] = "JKL",
            ['6'] = "MNO",
            ['7'] = "PQRS",
            ['8'] = "TUV",
            ['9'] = "WXYZ",
            ['0'] = " "
        };

        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var result = new StringBuilder();
            char? currentDigit = null;
            int pressCount = 0;

            foreach (char c in input)
            {
                switch (c)
                {
                    case '#':
                        CommitCurrentSequence();
                        return result.ToString();

                    case '*':
                        if (currentDigit.HasValue)
                        {
                            currentDigit = null;
                            pressCount = 0;
                        }
                        else if (result.Length > 0)
                        {
                            result.Length--;
                        }
                        break;

                    case ' ':
                        CommitCurrentSequence();
                        break;

                    default:
                        if (!char.IsDigit(c)) break;

                        if (!currentDigit.HasValue)
                        {
                            currentDigit = c;
                            pressCount = 1;
                        }
                        else if (currentDigit.Value == c)
                        {
                            pressCount++;
                        }
                        else
                        {
                            CommitCurrentSequence();
                            currentDigit = c;
                            pressCount = 1;
                        }
                        break;
                }
            }

            CommitCurrentSequence();
            return result.ToString();

            void CommitCurrentSequence()
            {
                if (!currentDigit.HasValue) return;

                if (!KeyMap.TryGetValue(currentDigit.Value, out string letters) ||
                    string.IsNullOrEmpty(letters))
                {
                    currentDigit = null;
                    pressCount = 0;
                    return;
                }

                int index = (pressCount - 1) % letters.Length;
                result.Append(letters[index]);

                currentDigit = null;
                pressCount = 0;
            }
        }
    }
}
