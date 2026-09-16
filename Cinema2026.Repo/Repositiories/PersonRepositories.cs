using Cinema2026.Repo.Models;
using Cinema2026.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Cinema2026.Repo.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema2026.Repo.Repositiories
{
    public class PersonRepositories : IPersonRepositories
    {
        private readonly DatabaseContext _context;

        public PersonRepositories(DatabaseContext d)
        {
            _context = d;
        }

        //create
        //get
        List<Person> persons = new List<Person>()
        {
            new Person() { PersonId = 1, name = "Marius", age = 20},
            new Person() { PersonId = 2, name = "Andreas", age = 19},
            new Person() { PersonId = 3, name = "Daniel", age = 19}
        };

        public List<Person> GetPeople()
        {
            return persons;
        }

        //public Person GetPerson(int num)
        //{
        //    return persons[num];
        //}

        public async Task<List<Person>> GetPersonAsync()
        {
            return await _context.Persons.ToListAsync<Person>();
        }

        public async Task<Person?> DeletePerson(int id)
        {
            return await _context.Persons.FirstOrDefaultAsync(i => i.PersonId == id);
        }

        public async Task<Person> CreatePerson(Person person)
        {
            // _context.Persons.Add(new Person { age = 20, name = "Marius", Id = 4 });
            _context.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }
    }
}
