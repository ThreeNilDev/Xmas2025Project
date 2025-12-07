using System;
using System.IO;


namespace Xmas25
{
    public class Day1
    {
        private List<string> data = new List<string>();
        private List<int> vaultNumbers = new List<int>();
        public void Run()
        {
            Console.WriteLine("Hello from Day 1!");


            GetData(out data);
            ConvertStringToVaultNumber(data, out vaultNumbers);
            //Run data agaisnt rules - Start at 50
            RunRules(vaultNumbers);

        }
        private static void RunRules(List<int> vaultNumbers)
        {
            int currentPosition = 50;
            int zeroCount = 0;
            foreach (int number in vaultNumbers)
            {
                currentPosition += number;
                if (currentPosition < 0)
                {
                    currentPosition = currentPosition + 100;
                }
                else if (currentPosition > 99)
                {
                    currentPosition = currentPosition - 100;
                }

                if (currentPosition == 0)
                {
                    zeroCount += 1;
                    
                }

                Console.WriteLine($"Current Position: {currentPosition}");
               
            }
            Console.WriteLine($"Final Position: {currentPosition}");
            Console.WriteLine($"Zero Count: {zeroCount}");
        }

        private static void ConvertStringToVaultNumber(List<string> strings, out List<int> retVal)
        {
            string leftOrRight;
            int count;
            retVal = new List<int>();

            // Implementation for processing data
            foreach (string str in strings)
            {
                leftOrRight = str.Substring(0, 1);
                if (leftOrRight == "L")
                {
                    count = Int32.Parse(str.Substring(1, str.Length -1));
                    if (count > 99)
                    {
                        count = Convert.ToInt32(Math.Floor((double)(count % 100)));
                    }
                    
                    retVal.Add(-count);
                }
                else if (leftOrRight == "R")
                {
                    count = Int32.Parse(str.Substring(1, str.Length -1));
                    if (count > 99)
                    {
                        count = Convert.ToInt32(Math.Floor((double)(count % 100)));
                    }
                    retVal.Add(count);

                }

            }
        }

        void GetData(out List<string> retVal)
        {
            string? line;
            retVal = new List<string>();


            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("Input/input.txt");
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
                Console.WriteLine("Finished Importing Data.");
            }
        }

    }
}

