using CourseWebApi.Context;
using CourseWebApi.IRepo;
using CourseWebApi.Models;
using CourseWebApi.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CourseWebApi.Repo
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        public AppDbContext _dbContext;
        public AuthenticateRepository(AppDbContext context)
        {

            _dbContext = context;

        }
        public User AuthenticateUser(LoginViewModel loginViewModel)
        {
           var user = _dbContext.Users.FirstOrDefault(x=>x.UserName== loginViewModel.UserName
            && x.Password==loginViewModel.Password);
            return user;
             
        }

        public string GetRoleName(int roleId)
        {
            string temp = 
                (from x in _dbContext.Roles
                 where x.RoleId == roleId
                 select x.RoleName).FirstOrDefault();

            return temp.ToString();
        }

        public List<Role> GetAllRoles()
        {
            return _dbContext.Roles.ToList();
        }
    }
}
