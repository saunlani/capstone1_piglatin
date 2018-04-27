using System;
using System.Text.RegularExpressions;

namespace capstone1_piglatin
{
    /* pig latin translator rogram. program takes the first leter at the 
     * beginning of each word  in a sentencereceived, 
     * moves it to the end of the wordd for each word in the sentence,
     * adds an "ay".  ex: "hello world" would be translated to 
     * "ellohay orldway". */

    class MainClass
    {
        public static void Main(string[] args)
        {
            Welcomer();
            do
            {
                Translator();
            } while (AskToTranslateAgain() == true);

        }

        // welcomes the user.
        static void Welcomer()
        {
            Console.WriteLine("Welcome to the Pig Latin Translator!");
        }


        // takes input & translates.
        static void Translator()
        {
            Console.Write("Enter a line to be translated:  ");
            string userinput = Console.ReadLine();
            userinput.ToLower();

            //grabbing the first two letters
            string firstletterofword = userinput.Substring(0, 1);

            //grabbing the rest of the word
            string restofword = userinput.Substring(1, userinput.Length - 1);

            //declaring vowels
            string vowels = "aeio";

            // index of first vowel appearance

            int firstvowel = 0;

            //checks input for a vowel in firstletterofword and ensures is only 
            //letters
            if (vowels.Contains(firstletterofword) && IsOnlyLetters(userinput))
            {
                Console.WriteLine("Translation: " +userinput + "way");
            }
            // if input is not only letters, returns false and prints the input
            // as is.
            else if (IsOnlyLetters(userinput) == false)
            {
                Console.WriteLine(userinput);
            }

            // checks that vowel is NOT first letter of word (starts with
            // consonant.  
            //
            // moves first letter of word to end of input and adds "ay".

            // TODO: if word starts with a consonant,move all of the consonants that
            // appear before the first vowel (ex: shrewd = ewd shr ay)
            else if (vowels.Contains(firstletterofword) == false)
            {
                firstvowel = userinput.IndexOfAny(vowels.ToCharArray());

                string beforevowel = userinput.Substring(0, firstvowel);
                string aftervowel = userinput.Substring(firstvowel);

                Console.WriteLine("Translation: " + aftervowel + beforevowel + "ay");
                // Console.WriteLine("Starts with consonant, the index of the first vowel is " + firstvowel);
                // Console.WriteLine(restofword + firstletterofword + "ay");
            }
            else
            { }



        }

        // Asks the user if they would like to translate another input
        static bool AskToTranslateAgain()
        {
            do
            {
                Console.Write("Translate another line? (y/n):  ");
                string userresponse = Console.ReadLine();
                userresponse.ToLower();


                if (userresponse == "y")
                {
                    return true;
                }
                else if (userresponse == "n")
                {
                    return false;
                }
                else if (userresponse != "y" && userresponse != "n")
                {
                    Console.WriteLine("You did not enter a valid response.");
                    continue;
                }
                else
                {
                    return false;
                }
            } while (true);
        }

        static bool IsOnlyLetters(string dainput)
        {
            var regexItem = new Regex("^[a-zA-Z]+$");
            if (regexItem.IsMatch(dainput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
