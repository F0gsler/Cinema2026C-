using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinema2026.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IGenericRepository<AdminUser> _repo;
        public AdminController(IGenericRepository<AdminUser> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public Task<AdminUser> CreateAdminUser(AdminUser adminuser)
        {
            var created = _repo.Add(adminuser);
            return created;
        }

        [HttpPut("{id:int}/adminlevel/{level:int}")]
        public async Task<AdminUser> UpdateAdminLevel(int id, int level)
        {
            var adminuser = await _repo.GetById(id);

            if (adminuser == null)
                return null!;

            adminuser.AdminLevel = level;

            await _repo.Update(adminuser);

            return adminuser;
        }

        [HttpDelete("{id:int}")]
        public async Task<AdminUser> DeleteAdminUser(int id)
        {
            var adminuser = await _repo.GetById(id);
            if (adminuser == null)
                return null!;

            await _repo.Delete(id);
            return null!;
        }
            

    }
}
