using System;

namespace FileIOforCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Data Handling for CSV files!");
            Console.WriteLine();
            //CSVHandler.ImplementCSVHandling();
            CSVHandler.ImplementJSONHandling();
            CSVHandler.ReadFromJSONAndWriteToCSV();
        }
    }
}
