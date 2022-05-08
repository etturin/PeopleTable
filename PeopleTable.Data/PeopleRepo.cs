﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeopleTable.Data
{
    class PeopleRepo
    {

        private string _connectionString;
        public PeopleRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Person> GetAll()
        {
            using var context = new PeopleDataContext(_connectionString);
            return context.People.ToList();
        }
        public void AddPerson(Person person)
        {
            using var context = new PeopleDataContext(_connectionString);
            context.People.Add(person);
            context.SaveChanges();
        }
        public void DeletePerson(Person person)
        {
            using var context = new PeopleDataContext(_connectionString);
            context.Database.ExecuteSqlInterpolated($"DELETE FROM People WHERE Id= {person.Id}");
            context.SaveChanges();

        }

        public void UpdatePerson(Person person)
        {
            using var context = new PeopleDataContext(_connectionString);

            context.Database.ExecuteSqlInterpolated($"UPDATE People Set FirstName={person.FirstName},  LastName={person.LastName}, Age={person.Age} Where Id={person.Id}");
            context.SaveChanges();
        }

    }
}
