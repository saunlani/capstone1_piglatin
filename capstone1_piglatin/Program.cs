using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace capstone1_piglatin
{
    /* pig latin translator program.
     * ------------------------------------------------------------------------
     * prompts user for word(s). validation for input.
     * translates word(s) to Pig Latin, displays to console.
     * asks the user if they want to translate again.
     * if word starts with a vowel, "way" is simply added to the ending.
     * if word starts with a consonant, all consosants before the first vowel 
     * are moved to the end of the word, followed by an "ay".
     * accepts series of words.
     * keeps the case of the word, UPPERCASE, Title Case or lowercase.
     * 
     * TOFO:  CHECK THAT THE USER HAS ACTUALLY ENTERED TEXT BEFORE TRANSLATING.
     * TODO:  ALLOW PUNCTUATION.
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
            string userinput = rawinput;


            // checks for input of at least 1 key besides return.
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
                    //grabbing the first letter
                    string firstletterofword = word.Substring(0, 1);

                    //grabbing the rest of the word
                    string restofword = word.Substring(1, word.Length - 1);

                    //declaring vowels
                    string vowels = "aeiouAEIOU";
                    // index of first vowel appearance
                    int firstvowel = 0;


                    /* is the input ONLY letters? */

                    if (IsOnlyLetters(word) == false)
                    {
                        Console.Write(word);
                    }

                    /* is the first letter of the word a vowel, and 
                     * is the word all caps? */

                    else if (vowels.Contains(firstletterofword) && word.ToUpper() == word)
                    {
                        Console.Write(word + "WAY ");
                    }

                    /* is the first letter of the word a vowel? */

                    else if (vowels.Contains(firstletterofword))
                    {
                        Console.Write(word + "way ");
                    }

                    /* is the first letter of the word a vowel, and is the word
                     * all upper case? */

                    else if (vowels.Contains(firstletterofword) == false && word.ToUpper() == word)
                    {
                        firstvowel = word.IndexOfAny(vowels.ToCharArray());
                        string beforevowel = word.Substring(0, firstvowel);
                        string aftervowel = word.Substring(firstvowel);
                        Console.Write(aftervowel + beforevowel + "AY ");
                    }

                    /* is the first letter of the word a vowel and is the 
                     * world in Title Case? */

                    else if (vowels.Contains(firstletterofword) == false && firstletterofword.ToUpper() == firstletterofword)
                    {
                        firstvowel = word.IndexOfAny(vowels.ToCharArray());
                        string beforevowel = word.Substring(0, firstvowel);
                        string aftervowel = word.Substring(firstvowel);
                        Console.Write(char.ToUpper(aftervowel[0]) + aftervowel.Substring(1) + beforevowel.ToLower() + "ay ");
                    }

                    /* is the first letter of the word a vowel and is the word
                     * all lower case? */

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
