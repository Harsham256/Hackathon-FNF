using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments
{
    internal class Assessment2
    {
        static void Main(string[] args)
        {
      
            Console.Write("Enter the number of books: ");
            int bookCount;
            while (!int.TryParse(Console.ReadLine(), out bookCount) || bookCount <= 0)
            {
                Console.Write("Please enter a valid positive integer: ");
            }

            List<string> books = new List<string>();

           for (int i = 1; i < bookCount; i++)
            {
                Console.Write($"Enter book #{i } in format \"Title\" by Author(s): ");
                string input = Console.ReadLine();
                books.Add(input);
            }

            List<string> sortedTitles = SortTitles(books);

           
            for (int i = 0; i < sortedTitles.Count; i++)
            {
                Console.WriteLine(sortedTitles[i]);
            }
        }

        
        public static List<string> SortTitles(List<string> books)
        {
            List<string> titles = new List<string>();
            List<string> authors = new List<string>();
            List<string> sorted = new List<string>();

            for (int i = 0; i < books.Count; i++)
            {
                string book = books[i];

                
                int start = book.IndexOf('"') + 1;
                int end = book.IndexOf('"', start);
                string title = book.Substring(start, end - start);

                int byIndex = book.IndexOf("by") + 3;
                string authorPart = book.Substring(byIndex);
                string firstAuthor = authorPart.Split(new string[] { " and", "," }, StringSplitOptions.None)[0].Trim();

                titles.Add(title);
                authors.Add(firstAuthor);
            }

      
            for (int i = 0; i < titles.Count - 1; i++)
            {
                for (int j = i + 1; j < titles.Count; j++)
                {
                    bool swap = false;

                    if (string.Compare(authors[i], authors[j]) > 0)
                        swap = true;
                    else if (authors[i] == authors[j] && string.Compare(titles[i], titles[j]) > 0)
                        swap = true;

                    if (swap)
                    {
                        string tempA = authors[i];
                        authors[i] = authors[j];
                        authors[j] = tempA;

                       
                        string tempT = titles[i];
                        titles[i] = titles[j];
                        titles[j] = tempT;
                    }
                }
            }

      
            for (int i = 0; i < titles.Count; i++)
            {
                sorted.Add(titles[i]);
            }

            return sorted;
        }
    }
}




