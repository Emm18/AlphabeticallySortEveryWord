using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphabeticallySortEveryWord
{
    class Program
    {
        static void Main(string[] args)
        {
            //SORT EVERY LETTER BY WORD IN A SENTENCE
            //Example : 
            //Input = CORN IN A CAB
            //Output = CNOR IN A ABC
            //Limitation = No validation

            Console.WriteLine("PLEASE ENTER A STRING");
            string userInput = Console.ReadLine(); //Hold the user input

            string wordHolder = ""; //Hold each word
            int wordCtr = 0; //Counter for index
            string[] dividedWordsHolder = new string[999]; //Hold divided word
            string[] readyToSortWord = new string[999]; //Will hold each letter of a word(per word, will clear each after word)
            string result = ""; //Will hold Result then print
            string temp = ""; //For sorting, will hold temporary value
            string sortedWord = ""; //Will hold sorted word

            for (int m = 0; m <= 998; m++) //Just to initialize array
            {
                dividedWordsHolder[m] = "";
                readyToSortWord[m] = "";
            }

            //Getting each word in the sentence
            for (int i = 0; i <= userInput.Length - 1; i++) //This loop will cut each word by space
            {
                if (userInput[i].ToString() != " ") //Check if the current value is not a space
                {
                    if (i == userInput.Length - 1) //if its the last index, add the word into the array
                    {
                        wordHolder = wordHolder + userInput[i];
                        dividedWordsHolder[wordCtr] = wordHolder;
                        wordCtr = wordCtr + 1;
                        wordHolder = "";
                    }
                    else //if its not the last index yet, just keep adding letters until space
                    {
                        wordHolder = wordHolder + userInput[i];
                    }
                }
                else if (userInput[i].ToString() == " ") //then if you get the space, get the current word then put in the array
                {
                    dividedWordsHolder[wordCtr] = wordHolder;
                    wordCtr = wordCtr + 1;
                    wordHolder = "";
                }
            }

            //After getting each word
            //Will go through each word one at a time
            //seperate each letter and put it to a new array
            //sort it in the new array
            //and then change the old value
            for (int m = 0; m <= dividedWordsHolder.Length - 1; m++)
            {
                if (dividedWordsHolder[m] != "")
                {
                    for (int p = 0; p <= dividedWordsHolder[m].Length - 1; p++) //this loop will put each letters in the new array
                    {
                        readyToSortWord[p] = dividedWordsHolder[m].ToString()[p].ToString();
                    }

                    for (int i = 0; i <= readyToSortWord.Length - 1; i++)//then the sorting will begin
                    {
                        if (readyToSortWord[i] != "")
                        {
                            for (int j = i + 1; j <= readyToSortWord.Length - 1; j++)//loop for sorting
                            {
                                if (readyToSortWord[j] != "")
                                {
                                    if (System.Convert.ToInt32(System.Convert.ToChar(readyToSortWord[i])) > System.Convert.ToInt32(System.Convert.ToChar(readyToSortWord[j])))
                                    //Converted the letter into ascii then compare
                                    {
                                        temp = readyToSortWord[i];
                                        readyToSortWord[i] = readyToSortWord[j];
                                        readyToSortWord[j] = temp;
                                    }
                                }
                            }
                        }
                    }

                    foreach (string letters in readyToSortWord) //combine all sorted letters
                    {
                        sortedWord = sortedWord + letters;
                    }

                    dividedWordsHolder[m] = sortedWord; //changing the unsorted letters into sorted letters
                    sortedWord = "";
                    temp = "";
                    for (int x = 0; x <= 998; x++) //clear new array for the next word
                    {
                        readyToSortWord[x] = "";
                    }
                }
            }

            foreach (string sentence in dividedWordsHolder) //put all the words back in sentence
            {
                if (sentence != "")
                {
                    result = result + sentence + " ";
                }
            }

            Console.WriteLine("Output = " + result); //Print result
        }
    }
}
