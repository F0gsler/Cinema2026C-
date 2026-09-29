using Cinema2026.Repo.Models;
using Xunit;

namespace Cinema2026.Tests
{
    public class PersonTests
    {
        [Fact]
        public void Person_PropertyAssignment_Works()
        {
            var p = new Person
            {
                PersonId = 1,
                username = "user",
                password = "pass",
                email = "a@b",
                age = 30
            };

            Assert.Equal(1, p.PersonId);
            Assert.Equal("user", p.username);
            Assert.Equal("pass", p.password);
            Assert.Equal("a@b", p.email);
            Assert.Equal(30, p.age);
        }
    }
}
