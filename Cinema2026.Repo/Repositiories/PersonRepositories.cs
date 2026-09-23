using Cinema2026.Repo.Models;
using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema2026.Repo.Repositiories
{
    public class PersonRepositories : IPersonRepositories
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Person> dbSet;

        public PersonRepositories(DatabaseContext d)
        {
            _context = d;
            dbSet = _context.Set<Person>();
        }

        List<Person> persons = new List<Person>()
        {
        };

        public List<Person> GetPeople()
        {
            return persons;
        }

        public async Task<List<Person>> GetAllPeople()
        {
            return await dbSet.ToListAsync();
        }
        // Get a single person by id
        public async Task<Person?> GetPersonById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<Person> CreatePerson(Person person)
        {
            await dbSet.AddAsync(person);
            await _context.SaveChangesAsync();
            return person;
        }
        // Delete a person by id
        public async Task DeletePerson(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null) return;
            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        // Update an existing person (user requested method)
        public async Task UpdatePerson(Person person)
        {
            dbSet.Update(person);
            await _context.SaveChangesAsync();
        }

    }
}
