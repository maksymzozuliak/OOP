using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabWork4
{
    class Program
    {

        static List<char> vowels = new List<char>
        {
            'а', 'е', 'и', 'і', 'ї', 'о', 'у', 'ю', 'я', 'a', 'e', 'i', 'o', 'u'
        };

        static List<char> consonants = new List<char>
        {
            'б', 'в', 'г', 'ґ', 'д', 'ж', 'з', 'й', 'к', 'л', 'м',
            'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ',
            'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n',
            'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z'
        };

        static void Main(string[] args)
        {
            string lineArray = "";
            string lineList = "";
            try
            {
                lineArray = File.ReadAllText("text_array.txt");
                lineList = File.ReadAllText("text_list.txt"); ;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            char[] charArray = lineArray.ToCharArray();
            List<char> charList = lineList.ToList();
            Console.WriteLine(lineArray);
            countFromArray(charArray);
            Console.WriteLine(lineList);
            countFromList(charList);
            Console.ReadLine();
        }

        static void countFromArray(char[] array)
        {
            int vowelCount = 0;
            int consonantCount = 0;

            foreach (char letter in array)
            {
                if (vowels.Contains(letter)) {
                    vowelCount++;
                } else if (consonants.Contains(letter)) {
                    consonantCount++;
                }
            }

            Console.WriteLine($"In Array : vowels = {vowelCount}, consonants = {consonantCount}");
        }

        static void countFromList(List<char> list)
        {
            int vowelCount = 0;
            int consonantCount = 0;

            foreach (char letter in list)
            {
                if (vowels.Contains(letter))
                {
                    vowelCount++;
                }
                else if (consonants.Contains(letter))
                {
                    consonantCount++;
                }
            }

            Console.WriteLine($"In List : vowels = {vowelCount}, consonants = {consonantCount}");
        }
    }
}
