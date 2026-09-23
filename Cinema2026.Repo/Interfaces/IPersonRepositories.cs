using Cinema2026.Repo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinema2026.Repo.Interfaces
{
    public interface IPersonRepositories
    {
        List<Person> GetPeople();
        Task<List<Person>> GetAllPeople();
        Task<Person?> GetPersonById(int id);
        Task<Person> CreatePerson(Person person);
        Task DeletePerson(int id);
        Task UpdatePerson(Person person);
    }
}
