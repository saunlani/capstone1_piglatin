using System;
using System.Text.RegularExpressions;

namespace capstone1_piglatin
{
    /* pig latin translator program.
     * ------------------------------------------------------------------------
     * prompts user for word(s). *DONE*
     * translates word(s) to Pig Latin, displays to console.  *DONE*
     * asks the user if they want to translate again. *DONE*
     * converts each word to a lower case *DONE*
     * if word starts with a vowel, "way" is simply added to the ending.*DONE*
     * if word starts with a consonant, all consosants before the first vowel 
     * are moved to the end of the word, followed by an "ay". *DONE*
     * accepts series of words. *DONE*
     * 
     * TOFO:  CHECK THAT THE USER HAS ACTUALLY ENTERED TEXT BEFORE TRANSLATING.
     * TODO:  ALLOW PUNCTUATION.
     * TODO:  KEEP THE CASE.
     */

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
            Console.Write("\nEnter a line to be translated:  ");
            string rawinput = Console.ReadLine();
            string userinput = rawinput.ToLower();

            // checks for input of at least 1.
            if (validentrychecker(userinput) == false)
            {
                Console.Write("\nYou didn't enter anything!");
            }
            else
            {
                Console.Write("\nTranslation:  ");

                string[] individualwords = userinput.Split(' ');
                foreach (string word in individualwords)
                {
                    //grabbing the first two letters
                    string firstletterofword = word.Substring(0, 1);

                    //grabbing the rest of the word
                    string restofword = word.Substring(1, word.Length - 1);

                    //declaring vowels
                    string vowels = "aeiou";
                    // index of first vowel appearance
                    int firstvowel = 0;

                    //checks input for a vowel in firstletterofword and ensures is only 
                    //letters
                    if (vowels.Contains(firstletterofword) && IsOnlyLetters(word))
                    {
                        Console.Write(word + "way ");
                    }

                    // if input is not only letters, returns false and prints the input
                    // as is.
                    else if (IsOnlyLetters(word) == false)
                    {
                        Console.Write(word);
                    }

                    // checks that vowel is NOT first letter of word (starts with
                    // consonant.  
                    //
                    // moves first letter of word to end of input and adds "ay".

                    // TODO: if word starts with a consonant,move all of the consonants that
                    // appear before the first vowel (ex: shrewd = ewdshray)

                    else if (vowels.Contains(firstletterofword) == false & vowels.Contains(word) == false)
                    {
                        Console.Write(restofword + firstletterofword + "ay ");
                    }
                    else if (vowels.Contains(firstletterofword) == false)
                    {
                        firstvowel = word.IndexOfAny(vowels.ToCharArray());

                        string beforevowel = word.Substring(0, firstvowel);
                        string aftervowel = word.Substring(firstvowel);

                        Console.Write(aftervowel + beforevowel + "ay ");
                    }
                    else
                    { }
                }  
            }





        }

        // Asks the user if they would like to translate another input
        static bool AskToTranslateAgain()
        {
            do
            {
                Console.Write("\n\nTranslate another line? (y/n):  ");
                string userresponse = Console.ReadLine().ToLower();


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
                    Console.Write("\nYou did not enter a valid response.");
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

        static bool validentrychecker (string aninput)
        {
            if (aninput.Length <= 0)
                return false;
            else
            {
                return true;

            }
        }

    }
}
