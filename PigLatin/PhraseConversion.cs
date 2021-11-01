using System;
using System.Collections.Generic;
using System.Text;

namespace PigLatin
{
    class PhraseConversion
    {
        public string PhraseToConvert { get; set; }
        public PhraseConversion(string Phrase)
        {
            PhraseToConvert = Phrase.ToLower();
        }

        public bool IsVowel(char c)
        {
            //Corrected logic error that prevented this method from properly evaluating the char object.
            char[] vowels = { 'a', 'e', 'i', 'o', 'u',};
            //I needed to add in a loop. Previously this was comparing the character to an array, so it NEVER returned true.
            //Adding a loop below to allow it to iterate throw the array and compare to each member of the array.

            foreach(char letter in vowels)
            {
                if(c == letter)
                {
                    return true;
                }
            }
            return false;
        }

        public string ToPigLatin()
        {
            char[] specialChars = { '@', '.', '-', '$', '^', '&' };
            string word = PhraseToConvert;
            foreach (char c in specialChars)
            {
                foreach (char w in word)
                {
                    if (w == c)
                    {
                        Console.WriteLine("That word has special characters, we will return it as is");
                        return word;
                    }
                }
            }

            bool noVowels = true;
            foreach (char letter in word)
            {
                if (IsVowel(letter))
                {
                    noVowels = false;
                }
            }
            
            if (noVowels)
            {
                return word;
            }

            char firstLetter = word[0];
            string output = "placeholder";
            if (IsVowel(firstLetter) == true)
            {
                output = word + "way";
            }
            else
            {
                int vowelIndex = -1;
                //Handle going through all the consonants
                for (int i = 0; i <= word.Length; i++)
                {
                    if (IsVowel(word[i]) == true)
                    {
                        vowelIndex = i;
                        break;
                    }
                }

                string sub = word.Substring(vowelIndex); 
                //Logic error: this was removing the wrong letter from the supplied word.
                //.Substring(), when supplied with 1 parameter uses that parameter as the starting point
                //Previously this was returning what was after the first vowel that was found.

                string postFix = word.Substring(0, vowelIndex); 
                //Logic error: when supplied with 2 parameters .Substring() will use the first int as an index, and the second as the length.
                //Previously, this was starting just before the vowel index. We only need to get the character before the vowel

                output = sub + postFix + "ay";
            }

            return output;
        }
    }
}
