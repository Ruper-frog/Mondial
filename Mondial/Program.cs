using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CountryFifaHouses
{
    internal class Program
    {

        // --------------------------------------------------------------------------------------------------------------

        static void Main(string[] args)
        { // checks if the inputted country is in the fifa world cup and prints the other countries in its group and
            // the group the inputted country is in.

            const string location = "C:\\Visual Studio" + // file location
            "\\score.txt"; // on the computer. change if needed.

            string[] fifaHouses = System.IO.File.ReadAllLines(location); // moving .txt file info to a string array.
            int length = fifaHouses.Count(); // calculating the amount of lines the file (and the array) has.

            Console.Write("Please enter a country: ");
            string country = Console.ReadLine(); // getting country input from user and preparing it.
            country = char.ToUpper(country[0]) + country.Substring(1); // in the file the first letter of each country is in caps lock so we want to capitalize it as well.

            bool isFound = false; // made to take care of an invalid input edge case.

            for (int i = 0; i < length; i += 2) // we want our loop to only check the names of the countries so we jump 2 Lines at once.
            {
                if (fifaHouses[i] == country) // checks to see if the inputted country exists in the file.
                {
                    char Group = (char)(97 + i / 8); // each group is made of 4 countries so each group we pass we want to add one to the Group variable.

                    Console.WriteLine("\nThe Country is in Group: {0}", Group);
                    Console.WriteLine("\nThe Countries that are in the same group are:");

                    i -= i % 8; // we want to jump to the first country in the group.
                    for (int j = 1; j < 5; j++) // for there all we gonna do is to run a loop 4 times to write which team is in the group as well And we want to ignore the requested team.
                    {
                        if (fifaHouses[i] != country) // checking if that's the requested team.
                            Console.Write(fifaHouses[i] + "\t|\t"); // printing each team.
                        i += 2; // again we want to avoid the score and only check the country name.
                    }
                    Console.WriteLine();
                    isFound = true; // also marks the isFound object as true (will have an effect later).
                    break; // and finally, stops looking if the country inputted exists in the file.
                }
            }
            if (!isFound) // only true if the inputted country exists in the file.
                          // (and therefore, plays in the world cup).
            {
                Console.WriteLine();
                Console.WriteLine("The country you have entered is invalid.");// prints incorrect input message.
            }
            Console.WriteLine();
        }

        // --------------------------------------------------------------------------------------------------------------

    }
}