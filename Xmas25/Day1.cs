using System;
using System.IO;


namespace Xmas25
{
    public class Day1
    {
        private List<string> data = new List<string>();
        private List<int> vaultNumbers = new List<int>();
        public string Location = "Input/Input.txt";
        public void Run()
        {
            //Console.WriteLine("Hello from Day 1!");


            GetData(Location, out data);
            ConvertStringToVaultNumber(data, out vaultNumbers);
            //Run data agaisnt rules - Start at 50
            RunRules(vaultNumbers,50);

        }
        private static void RunRules(List<int> vaultNumbers, int StartingPosition)
        {
            int currentPosition = StartingPosition;
            int countZero = 0;

            foreach (int number in vaultNumbers)
            {
                currentPosition += number;


                if (currentPosition == 0)
                {

                    countZero++;

                }
                else if (currentPosition < 0)
                {
                    while (currentPosition < 0)
                    {
                        currentPosition = currentPosition + 100;

                    }
                    if (currentPosition == 0)
                    {
                        countZero++;
                    }

                }
                else if (currentPosition > 99)
                {
                    while (currentPosition > 99)
                    {
                        currentPosition = currentPosition - 100;
                       
                    }
                    if (currentPosition == 0)
                    {
                        countZero++;
                    }

                }


                Console.WriteLine($"Current Position: {currentPosition}");

            }
            Console.WriteLine($"Final Position: {currentPosition}");
            Console.WriteLine($"Zero Count: {countZero}");
        }

        private static void ConvertStringToVaultNumber(List<string> strings, out List<int> retVal)
        {
            string leftOrRight;
            int numbers;
            retVal = new List<int>();

            // Implementation for processing data
            foreach (string str in strings)
            {
                leftOrRight = str.Substring(0, 1);
                if (leftOrRight == "L")
                {
                    numbers = Int32.Parse(str.Substring(1, str.Length -1));                
                    retVal.Add(-numbers);
                }
                else if (leftOrRight == "R")
                {
                    numbers = Int32.Parse(str.Substring(1, str.Length -1));
                    retVal.Add(numbers);

                }

            }
        }

        void GetData(string Location, out List<string> retVal)
        {
            string? line;
            retVal = new List<string>();


            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(Location);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    //Console.WriteLine(line);

                    //Add line to return list
                    retVal.Add(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Ending GetData.");
            }
        }

    }
}

