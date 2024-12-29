using Project_WebApi.Context;
using Project_WebApi.IRepo;
using Project_WebApi.Models;

namespace Project_WebApi.Repo
{
    public class RoleRepository : IRoleRepository

    {
        AppDbContext _dbContext;
        public RoleRepository(AppDbContext context)
        {

            _dbContext = context;

        }
       


       public  List<Role> GetRoles()
        {
            return _dbContext.Roles.ToList();
        }

       
    }
}
