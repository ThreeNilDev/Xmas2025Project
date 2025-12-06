using System;
using System.IO;


namespace Xmas25
{
    public class Day1
    {
        public void Run()
        {
            Console.WriteLine("Hello from Day 1!");
            GetData();
        }

        void GetData()
        {
            // Implementation for getting data
            string? line;
try
{
    //Pass the file path and file name to the StreamReader constructor
    StreamReader sr = new StreamReader("input.txt");
    //Read the first line of text
    line = sr.ReadLine();
    //Continue to read until you reach end of file
    while (line != null)
    {
        //write the line to console window
        Console.WriteLine(line);
        //Read the next line
        line = sr.ReadLine();
    }
    //close the file
    sr.Close();
    Console.ReadLine();
}
catch(Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
finally
{
    Console.WriteLine("Executing finally block.");
}
        }
    }
}