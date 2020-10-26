using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FileIOforCSV
{
    class CSVHandler
    {
        static string importPath= @"C:\Users\LENOVO\source\repos\FileIOforCSV\FileIOforCSV\Utility\Address.csv";

        static string exportPath = @"C:\Users\LENOVO\source\repos\FileIOforCSV\FileIOforCSV\Utility\Export.csv";

        static string exportPathJson = @"C:\Users\LENOVO\source\repos\FileIOforCSV\FileIOforCSV\Utility\Export.json";

        static string JSONTOCSV = @"C:\Users\LENOVO\source\repos\FileIOforCSV\FileIOforCSV\Utility\JSONToCSV.csv";

        public static void ImplementCSVHandling()
        {
            //Converts the file into stream
            using (StreamReader str=new StreamReader(importPath))
            {
                using (CsvReader csvReader=new CsvReader(str, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<AddressData>().ToList();

                    Console.WriteLine("Reading Records from File");

                    foreach(AddressData record in records)
                    {
                        Console.WriteLine(record.firstname+": "+record.lastname+": "+record.address+": "+record.city+": "+record.state+": "+record.code);
                    }

                    Console.WriteLine();

                    Console.WriteLine("Writing data to another CSV File");

                    using (StreamWriter stw = new StreamWriter(exportPath))
                    {
                        using (CsvWriter writer = new CsvWriter(stw, CultureInfo.InvariantCulture))
                        {
                            writer.WriteRecords(records);
                        }
                    }

                }
            }
            
        }


        public static void ImplementJSONHandling()
        {
            //Converts the file into stream
            using (StreamReader str = new StreamReader(importPath))
            {
                using (CsvReader csvReader = new CsvReader(str, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<AddressData>().ToList();

                    Console.WriteLine("Reading Records from File");

                    foreach (AddressData record in records)
                    {
                        Console.WriteLine(record.firstname + ": " + record.lastname + ": " + record.address + ": " + record.city + ": " + record.state + ": " + record.code);
                    }

                    Console.WriteLine();

                    Console.WriteLine("Writing data to another JSON File");

                    JsonSerializer ser = new JsonSerializer();

                    using (StreamWriter stw = new StreamWriter(exportPathJson))
                    {
                        using (JsonTextWriter writer = new JsonTextWriter(stw))
                        {
                            ser.Serialize(writer, records);
                        }
                    }

                    Console.WriteLine();

                }
            }

        }

        public static void ReadFromJSONAndWriteToCSV()
        {
            Console.WriteLine("Reading from JSON and writing into CSV");

            string data = File.ReadAllText(exportPathJson);

            List<AddressData> records = JsonConvert.DeserializeObject<List<AddressData>>(data);

            Console.WriteLine("Reading data from Json");

            foreach(AddressData record in records)
            {
                Console.WriteLine(record.firstname + ": " + record.lastname + ": " + record.address + ": " + record.city + ": " + record.state + ": " + record.code);
            }

            Console.WriteLine("Writing into CSV file");

            using (StreamWriter stw=new StreamWriter(JSONTOCSV))
            {
                using (CsvWriter writer=new CsvWriter(stw, CultureInfo.InvariantCulture))
                {
                    writer.WriteRecords(records);
                }
            }

                
            
        }
    }

}
