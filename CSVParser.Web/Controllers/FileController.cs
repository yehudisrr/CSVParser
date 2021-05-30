using CsvHelper;
using CSVParser.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParser.Web.Controllers
{
    public class FileController : Controller
    {
        public IActionResult ViewFile(string name)
        {
            byte[] fileData = System.IO.File.ReadAllBytes($"uploads/{name}");
            return File(fileData, "APPLICATION/octet-stream", name);
        }
        public IActionResult GetPeopleCsv(int amount)
        {
            var ppl = new List<Person>();
            for (int i = 0; i < amount; i++)
            {
                ppl.Add(new Person
                {
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    Age = Faker.RandomNumber.Next(20, 80),
                    Email = Faker.Internet.Email(),
                    Address = Faker.Address.StreetAddress()
                });

            }
            var csvString = GetCsv(ppl);
            var bytes = Encoding.UTF8.GetBytes(csvString);
            return File(bytes, "text/csv", "people.csv");
        }

        static string GetCsv(List<Person> ppl)
        {
            var builder = new StringBuilder();
            var stringWriter = new StringWriter(builder);

            using var csv = new CsvWriter(stringWriter, CultureInfo.InvariantCulture);
            csv.WriteRecords(ppl);

            return builder.ToString();
        }
    }
}
