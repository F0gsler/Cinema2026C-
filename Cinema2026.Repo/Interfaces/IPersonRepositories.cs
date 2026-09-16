using Cinema2026.Repo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema2026.Repo.Interfaces
{
    public interface IPersonRepositories
    {
        public List<Person> GetPeople();
        public Task<List<Person>> GetPersonAsync();
        public Task<Person> CreatePerson(Person person);
        public Task<Person?> DeletePerson(int id);
    }
}
