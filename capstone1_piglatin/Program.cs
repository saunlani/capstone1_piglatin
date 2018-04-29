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
     * if word starts with a consonant, all consonants before the first vowel 
     * are moved to the end of the word, followed by an "ay".
     * accepts series of words.
     * keeps the case of the word, UPPERCASE, Title Case or lowercase.
     * accepts words with contractions.
     * accepts punctuation. */

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
            if (ValidEntryChecker(userinput) == false)
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

                    //declaring punctuation
                    string punctuation = ",.?!;:";


                    //index of punctuation
                    int puncloc = 0;

                    // index of first vowel appearance
                    int firstvowel = 0;

                    /* is the input ONLY symbols or numbers? (ex: 15252)*/
                    if (IsOnlyLetters(word) == false)
                    {

                        Console.Write(word + " ");
                    }

                    /* INDIGO = INDIGOWAY */
                    else if (PuncChecker(word) != true
                             && VowelChecker(firstletterofword) == true
                             && (word.ToUpper() == word)
                             && (word.Length >= 2))
                    {

                        Console.Write(word + "WAY ");

                    }

                    /* INDIGO. = INDIGOWAY. */
                    else if (VowelChecker(firstletterofword) == true
                             && (word.ToUpper() == word)
                             && (word.Length >= 2))
                    {
                        puncloc = word.IndexOfAny(punctuation.ToCharArray());
                        string beforepunc = word.Substring(0, puncloc);
                        string afterpunc = word.Substring(puncloc);
                        Console.Write(beforepunc + "WAY" + afterpunc + " ");

                    }

                    /* indigo = indigoway */
                    else if (PuncChecker(word) != true
                             && VowelChecker(firstletterofword) == true
                             && (word.ToLower() == word))
                    {
                        Console.Write(word + "way ");
                    }

                    /* indigo. = indigoway. */
                    else if (VowelChecker(firstletterofword) == true
                             && (word.ToLower() == word)
                             && (word.Length >= 2))
                    {
                        puncloc = word.IndexOfAny(punctuation.ToCharArray());
                        string beforepunc = word.Substring(0, puncloc);
                        string afterpunc = word.Substring(puncloc);
                        Console.Write(beforepunc + "way" + afterpunc + " ");
                    }

                    /* I = IWAY */
                    else if ((PuncChecker(word) != true
                              && ( word.Length ==1)
                              && VowelChecker(firstletterofword) == true
                              && (firstletterofword.ToUpper() == firstletterofword)))
                    {
                        Console.Write(word + "WAY ");
                    }

                    /* Indigo = Indigoway */
                    else if ((PuncChecker(word) != true
                              && VowelChecker(firstletterofword) == true
                              && (firstletterofword.ToUpper() == firstletterofword)))
                    {
                        Console.Write(word + "way ");
                    }

                    /* Indigo. = Indigoway. */
                    else if ((VowelChecker(firstletterofword) == true
                              && (firstletterofword.ToUpper() == firstletterofword)))
                    {
                        puncloc = word.IndexOfAny(punctuation.ToCharArray());
                        string beforepunc = word.Substring(0, puncloc);
                        string afterpunc = word.Substring(puncloc);
                        Console.Write(beforepunc + "way" + afterpunc + " ");
                    }

                    /* SHOES = OESHAY */
                    else if (PuncChecker(word) != true
                             && word.ToUpper() == word
                             && VowelChecker(firstletterofword) == false
                             && VowelChecker(word))
                    {
                        firstvowel = word.IndexOfAny(vowels.ToCharArray());
                        string beforevowel = word.Substring(0, firstvowel);
                        string aftervowel = word.Substring(firstvowel);
                        Console.Write(aftervowel + beforevowel + "AY ");
                    }

                    /* SHOES. = OESHAY. */
                    else if (word.ToUpper() == word
                             && VowelChecker(firstletterofword) == false
                             && VowelChecker(word))
                    {
                        puncloc = word.IndexOfAny(punctuation.ToCharArray());
                        string beforepunc = word.Substring(0, puncloc);
                        string afterpunc = word.Substring(puncloc);
                        firstvowel = word.IndexOfAny(vowels.ToCharArray());
                        string beforevowel = word.Substring(0, firstvowel);
                        string aftervowel = word.Substring(firstvowel);
                        Console.Write( aftervowel.Remove(aftervowel.Length - 1) + beforevowel + "AY" + afterpunc + " ");
                    }

                    /* shoes = oeshay */
                    else if (PuncChecker(word) != true
                             && VowelChecker(word) == true
                             && (firstletterofword.ToUpper() != firstletterofword))
                    {
                        firstvowel = word.IndexOfAny(vowels.ToCharArray());
                        string beforevowel = word.Substring(0, firstvowel);
                        string aftervowel = word.Substring(firstvowel);
                        Console.Write(aftervowel + beforevowel + "ay ");
                    }

                    /* shoes. = oeshay. */
                    else if (VowelChecker(word) == true
                             && (firstletterofword.ToUpper() != firstletterofword))
                    {
                        puncloc = word.IndexOfAny(punctuation.ToCharArray());
                        string beforepunc = word.Substring(0, puncloc);
                        string afterpunc = word.Substring(puncloc);
                        firstvowel = word.IndexOfAny(vowels.ToCharArray());
                        string beforevowel = word.Substring(0, firstvowel);
                        string aftervowel = word.Substring(firstvowel);
                        Console.Write(aftervowel.Remove(aftervowel.Length - 1) + beforevowel + "ay" + afterpunc + " ");
                    }

                    /* Shoes = Oeshay */
                    else if (PuncChecker(word) != true &&
                             VowelChecker(firstletterofword) == false
                             && firstletterofword.ToUpper() == firstletterofword
                             && VowelChecker(word) == true)
                    {
                        firstvowel = word.IndexOfAny(vowels.ToCharArray());
                        string beforevowel = word.Substring(0, firstvowel);
                        string aftervowel = word.Substring(firstvowel);
                        Console.Write(char.ToUpper(aftervowel[0]) + aftervowel.Substring(1) + beforevowel.ToLower() + "ay ");
                    }

                    /* Shoes. = Oeshay. */
                    else if (VowelChecker(firstletterofword) == false
                             && firstletterofword.ToUpper() == firstletterofword
                             && VowelChecker(word) == true)
                    {
                        puncloc = word.IndexOfAny(punctuation.ToCharArray());
                        string beforepunc = word.Substring(0, puncloc);
                        string afterpunc = word.Substring(puncloc);
                        firstvowel = word.IndexOfAny(vowels.ToCharArray());
                        string beforevowel = word.Substring(0, firstvowel);
                        string aftervowel = word.Substring(firstvowel);
                        string titledword = (aftervowel.Remove(aftervowel.Length - 1) + beforevowel + "ay" + afterpunc + " ");
                        Console.WriteLine(TitleCase(titledword));
                    }

                    /* SHH = SHHAY */
                    else if (PuncChecker(word) != true
                             && word.ToUpper() == word &&
                             VowelChecker(word) == false && word.Length >= 2)
                    {
                        Console.Write(word + "AY ");
                    }

                    /* SHH. = SHHAY. */
                    else if (VowelChecker(firstletterofword) == false
                             && (word.ToUpper() == word)
                             && (word.Length >= 2))
                    {
                        puncloc = word.IndexOfAny(punctuation.ToCharArray());
                        string beforepunc = word.Substring(0, puncloc);
                        string afterpunc = word.Substring(puncloc);
                        Console.Write(beforepunc + "AY" + afterpunc + " ");
                    }

                    /* shh = shhay */
                    else if (PuncChecker(word) != true
                             && word.ToLower() == word
                             && VowelChecker(word) == false)
                    {
                        Console.Write(word + "ay ");
                    }

                    /* shh. = shhay. */
                    else if (VowelChecker(firstletterofword) == false
                             && (word.ToLower() == word)
                             && (word.Length >= 2))
                    {
                        puncloc = word.IndexOfAny(punctuation.ToCharArray());
                        string beforepunc = word.Substring(0, puncloc);
                        string afterpunc = word.Substring(puncloc);
                        Console.Write(beforepunc + "ay" + afterpunc + " ");
                    }

                    /* Shh = Shhay */
                    else if (PuncChecker(word) != true
                             && VowelChecker(firstletterofword) == false 
                             && firstletterofword.ToUpper() == firstletterofword 
                             && VowelChecker(word) == false)
                    {

                        Console.Write(word + "ay ");                    
                    }

                    /* Shh. = Shhay. */
                    else if (VowelChecker(firstletterofword) == false 
                             && firstletterofword.ToUpper() == firstletterofword 
                             && VowelChecker(word) == false)
                    {

                        puncloc = word.IndexOfAny(punctuation.ToCharArray());
                        string beforepunc = word.Substring(0, puncloc);
                        string afterpunc = word.Substring(puncloc);
                        Console.WriteLine(beforepunc + "ay" + afterpunc);
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

        // test for input without special characters
        static bool IsOnlyLetters(string dainput)
        {
            var regexItem = new Regex("^[a-z.,!?;:_A-Z']+$");
            if (regexItem.IsMatch(dainput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // test for punctuation
        static bool PuncChecker(string input)
        {
            if (Regex.IsMatch(input, @"[.!?,;]"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // convert a string to english title case
        static string TitleCase(string dainput)
        {
            return new CultureInfo("en").TextInfo.ToTitleCase(dainput.ToLower());
        }

        // test for input greater than 0 keys
        static bool ValidEntryChecker (string aninput)
        {
            if (String.IsNullOrWhiteSpace(aninput))
                return false;
            else
            {
                return true;

            }
        }

        // test for vowels
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
