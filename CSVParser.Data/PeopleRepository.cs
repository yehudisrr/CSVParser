using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVParser.Data
{
    public class PeopleRepository
    {
        private readonly string _connectionString;

        public PeopleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddPerson(Person p)
        {
           using var ctx = new PeopleContext(_connectionString);
           ctx.People.Add(p);
           ctx.SaveChanges();
        }

        public List<Person> GetPeople()
        {
            using var ctx = new PeopleContext(_connectionString);
            return ctx.People.ToList();
        }

        public void DeletePeople()
        {
            using var context = new PeopleContext(_connectionString);
            context.Database.ExecuteSqlInterpolated($"DELETE FROM People");
        }

    }
}
