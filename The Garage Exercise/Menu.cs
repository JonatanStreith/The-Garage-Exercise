using System;
using System.Collections.Generic;
using System.Text;

namespace The_Garage_Exercise
{
    internal class Menu
    {
        string openingText = "Welcome to the Garage! We accept all vehicles!" +
            "\nService desk hours are 9:00-19:00. Closed february 12th for repairs." +
            "\nMake sure all garbage is placed in appropriate containers" +
            "\nand all outstanding fees are paid within 9 workdays." +
            "\nFailure to comply may result in vehicular reposession or destruction." +
            "\n";

        string listOfChoices = "Options are:" +
            "\n" +
            "\n(P)ark vehicle (in available spot)" +
            "\n(R)etrieve vehicle" +
            "\n(L)ist all vehicles" +
            "\n(T)ypes of vehicles and numbers of each parked in the garage" +
            "\n(S)earch for vehicle" +
            "\n(Q)uit and leave the garage" +
            "\n";
        public void DisplayMenu()
        {
            Console.WriteLine(openingText);
            Console.WriteLine(listOfChoices);
            Console.Write("Please make a selection: ");
        }

        public void MakeChoice(string choice)
        {
            switch (choice)
            {
                case "P":
                case "Park":
                    {
                        break;
                    }

                case "R":
                case "Retrieve":
                    {
                        break;
                    }

                case "L":
                case "List":
                    {
                        break;
                    }

                case "T":
                case "Types":
                    {
                        break;
                    }

                case "S":
                case "Search":
                    {
                        break;
                    }

                case "Q":
                case "Quit":
                    {
                        break;
                    }


                default:
                    {
                        Console.WriteLine("That is not an acceptable choice."); ;
                        break;
                    }



            }
        }

        public static string Capitalize(string input)   //This turns a string into a capitalized string
        {
            if (input.Length < 2)
                return input.ToUpper();
            else
                return string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1));
        }

    }
}
