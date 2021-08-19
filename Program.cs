using ConsoleTables;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace RestAPIGetter
{
    class Program
    {
        static void Main(string[] args)
        {
            GetUserInput();
        }

        static void GetUserInput()
        {
            Console.WriteLine("Enter command(-help for more information):");
            string userInput = Console.ReadLine();
            while (userInput != "-exit")
            {
                if (userInput == "-help")
                    WriteHelpInfoInConsole();
                if (userInput == "-send")
                    SendGetRequest();

                userInput = Console.ReadLine();
            }
        }

        private static void SendGetRequest()
        {
            var client = new RestClient("https://tester.consimple.pro")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            WriteResponse(response.Content);
        }

        private static void WriteResponse(string content)
        {
            Console.WriteLine("Result is: \n");
            Data parsedJson = JsonSerializer.Deserialize<Data>(content);

            ConsoleTable table = new();
            table.AddColumn(new List<string>() { "Products", "Categories" });
            foreach(var item in parsedJson.Products)
            {
                Categories category = parsedJson.Categories.Where(categ => categ.Id == item.CategoryId)
                                                           .FirstOrDefault();
                table.AddRow(item.Name, category.Name);
            }
            table.Write();
        }

        private static void WriteHelpInfoInConsole()
        {
            Console.WriteLine(@"Commands 
                                    -help: Get more info
                                    -send: Send http GET request to get Data
                                    -exit: Exit and close programm
            ");
        }
    }
}
