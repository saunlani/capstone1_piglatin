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
     * accepts words with contractions.
     * 
     * 
     * TODO:  ALLOW PUNCTUATION. */

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

                    /* is the input ONLY symbols or numbers? (ex: 15252)*/
                    if (IsOnlyLetters(word) == false)
                    {

                        Console.Write(word + " ");
                    }

                    /* INDIGO = INDIGOWAY */
                    else if (VowelChecker(firstletterofword) == true && (word.ToUpper() == word) && (word.Length >= 2))
                    {

                        Console.Write(word + "WAY");

                    }

                    /* indigo = indigoway */
                    else if (VowelChecker(firstletterofword) == true && (word.ToLower() == word))
                    {
                        Console.Write(word + "way ");
                    }

                    /* Indigo = Indigoway */
                    else if ((VowelChecker(firstletterofword) == true && (firstletterofword.ToUpper() == firstletterofword)))
                    {
                        Console.Write(word + "way ");
                    }

                    /* SHOES = OESHWAY */
                    else if (word.ToUpper() == word && VowelChecker(firstletterofword) == false && VowelChecker(word))
                    {
                        firstvowel = word.IndexOfAny(vowels.ToCharArray());
                        string beforevowel = word.Substring(0, firstvowel);
                        string aftervowel = word.Substring(firstvowel);
                        Console.Write(aftervowel + beforevowel + "AY ");
                    }

                    /* shoes = oeshay */
                    else if (VowelChecker(word) == true && (firstletterofword.ToUpper() != firstletterofword))
                    {
                        firstvowel = word.IndexOfAny(vowels.ToCharArray());
                        string beforevowel = word.Substring(0, firstvowel);
                        string aftervowel = word.Substring(firstvowel);
                        Console.Write(aftervowel + beforevowel + "ay ");
                    }

                    /* Shoes = Oeshay */
                    else if (VowelChecker(firstletterofword) == false && firstletterofword.ToUpper() == firstletterofword && VowelChecker(word) == true)
                    {
                        firstvowel = word.IndexOfAny(vowels.ToCharArray());
                        string beforevowel = word.Substring(0, firstvowel);
                        string aftervowel = word.Substring(firstvowel);
                        Console.Write(char.ToUpper(aftervowel[0]) + aftervowel.Substring(1) + beforevowel.ToLower() + "ay ");
                    }

                    /* SHH = SHHAY */
                    else if (word.ToUpper() == word && VowelChecker(word) == false)
                    {
                        Console.Write(word + "AY ");
                    }

                    /* shh = shhay */
                    else if (word.ToLower() == word && VowelChecker(word) == false)
                    {
                        Console.Write(word + "ay ");
                    }

                    /* Shh = Shhay */
                    else if (VowelChecker(firstletterofword) == false && firstletterofword.ToUpper() == firstletterofword && VowelChecker(word) == false)
                    {

                        Console.Write(word + "ay ");                    
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
            var regexItem = new Regex("^[a-z._A-Z']+$");
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

        static bool VowelChecker (string input)
        {
            if (Regex.IsMatch(input, @"[aeiou]", RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            { return false; 
            }
        }

    }
}
