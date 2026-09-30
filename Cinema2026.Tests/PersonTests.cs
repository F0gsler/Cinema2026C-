using Cinema2026.Repo.Data;
using Cinema2026.Repo.Models;
using Cinema2026.Repo.Repositiories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Cinema2026.Tests
{
    public class PersonTests
    {
        private readonly DbContextOptions<DatabaseContext> options;
        private readonly DatabaseContext context;
        private readonly PersonRepositories repository;
        public int tal;

        public PersonTests()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            context = new DatabaseContext(options);
            repository = new PersonRepositories(context);

            Person p1 = new Person() { PersonId = 1, username = "John", password = "pass123", age = 30 };
            Person p2 = new Person() { PersonId = 2, username = "Bodil", password = "pass456", age = 50 };
            context.Persons.Add(p1);
            context.Persons.Add(p2);
            context.SaveChanges();

            Console.Write(p1.username);
        }

        [Fact]
        public async Task getById_Person_ReturnsPerson()
        {
            // Use the repository method that exists in your repository type.
            // The signatures you provided include GetPersonById(int), so call that.
            var result = await repository.GetPersonById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.PersonId);
        }
    }
}
