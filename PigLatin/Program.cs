using System;
using System.Linq;

namespace PigLatin
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInput = GetInput("Please input a word or sentence to translate to pig Latin");

            PhraseConversion translation = new PhraseConversion(userInput);
            //If the user enters a phrase, break it up and run each unique word through the PhraseConversion class.
            string[] userInputPhrase = userInput.Split(' ', ',', '.');
            
            if (userInputPhrase.Length > 1)
            {
                for(int i = 0; i <= userInputPhrase.Length-1; i++)
                {
                    translation = new PhraseConversion(userInputPhrase[i]);
                    Console.WriteLine(translation.ToPigLatin());
                }
            } 
            else
            {
                Console.WriteLine(translation.ToPigLatin());
            }
        }
        public static string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().ToLower().Trim();
            return input;
        }

    }
}
