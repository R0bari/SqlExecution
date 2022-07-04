using SqlExecution.Contexts;
using System;
using System.Configuration;
using System.IO;

namespace SqlExecution
{
    internal class Program
    {
        private static readonly string inputPath = ConfigurationManager.AppSettings["InputFilePath"] ?? "";
        private static readonly string outputPath = ConfigurationManager.AppSettings["OutputFilePath"] ?? "";

        static void Main(string[] args)
        {
            try
            {
                WriteToFile(
                    outputPath,
                    new MsSqlContext()
                        .Execute(ReadFromFile(inputPath))
                        .ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("Press any button to quit...");
            Console.ReadKey();
        }

        private static string ReadFromFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                return reader.ReadToEnd();
            }
        }

        private static void WriteToFile(string filePath, string content)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(content);
            }
        }
    }
}
