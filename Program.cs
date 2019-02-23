// Sean O'Connor
// URL Encoder Challenge
// INFOTC 2040
using System;
using System.Collections.Generic;

namespace URLEncoder
{
    class Program
    {
        static string urlFormatString = "https://companyserver.com/content/{0}/files/{1}/{1}Report.pdf";

        static Dictionary<string, string> characterMap = new Dictionary<string, string>
        {
            {" ", "%20"}, {"<", "%3C"}, {">", "%3E"}, {"#", "%23"}, {"\"", "%22"},
            {";", "%3B"}, {"/", "%2F"}, {"?", "%3F"}, {":", "%3A"}, {"@", "%40"},
            {"&", "%26"}, {"=", "%3D"}, {"+", "%2B"}, {"$", "%24"}, {",", "%2C"},
            {"{", "%7B"}, {"}", "%7D"}, {"|", "%7C"}, {"\\", "%5C"}, {"^", "%5E"},
            {"[", "%5B"}, {"]", "%5D"}, {"`", "%60"}
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the URL Encoder");

            do
            {
                Console.Write("\nEnter Project name: ");
                string projectName = GetUserInput();
                Console.Write("Enter Activity name: ");
                string activityName = GetUserInput();

                Console.WriteLine(CreateURL(projectName, activityName));

                Console.Write("Would you like to do another? (yes/no): ");
            } while (Console.ReadLine().ToLower().Equals("y"));
        }

        static string CreateURL(string projectName, string activityName)
        {
            return String.Format(urlFormatString, Encode(projectName), Encode(activityName));
        }

        static string GetUserInput()
        {
            string input = "";
            do
            {
                input = Console.ReadLine();
                if (IsValid(input)) return input;
                Console.Write("The input contains invalid characters. Enter again: ");
            } while (true);
        }

        static bool IsValid(string input)
        {
            foreach (char character in input.ToCharArray())
            {
                if ((character >= 0x00 && character <= 0x1F) || character == 0x7F)
                {
                    return false;
                }
            }
            return true;
        }

        static string Encode(string value)
        {
            string encodedValue = "";
            foreach (char character in value.ToCharArray())
            {
                string characterString = character.ToString();
                encodedValue += characterMap.GetValueOrDefault(characterString, characterString);
            }
            return encodedValue;
        }
    }
}