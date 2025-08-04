using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Question 1. Word frequency counter allows you to count the frequency usage of each word in your text
//. Write a program to find the word and its frequency.




namespace Assessments
{

    internal class Assessment1
    {
        static void Main()
        {
            Console.WriteLine("Enter a text:");
            string input = Console.ReadLine();

         
            CountWords(input);
        }

      
        static void CountWords(string input) { 
        
            string cleanedInput = "";
            foreach (char c in input)
            {
                if (char.IsLetter(c) || c == ' ')
                {
                    cleanedInput += c;
                }
            }


            string[] words = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                Console.WriteLine(0);
                return;
            }

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string lowerWord = word.ToLower();
                if (wordCounts.ContainsKey(lowerWord))
                    wordCounts[lowerWord]++;
                else
                    wordCounts[lowerWord] = 1;
            }

       
            var sortedWords = wordCounts
                .OrderByDescending(pair => pair.Value)
                .ThenByDescending(pair => pair.Key);

     
            foreach (var pair in sortedWords)
            {
                Console.WriteLine($"{pair.Value} {pair.Key}");
            }
        }
    }

}