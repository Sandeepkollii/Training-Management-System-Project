using Microsoft.EntityFrameworkCore;
using Project_WebApi.Context;
using Project_WebApi.IRepo;
using Project_WebApi.Models;
using Project_WebApi.ViewModels;

namespace Project_WebApi.Repo
{
    public class UserRepository : IUserRepository
    {
        AppDbContext _dbContext;
        public UserRepository(AppDbContext context)
        {

            _dbContext = context;

        }
        public User AddUser(User user)
        {
            user.IsActive = true;
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }
        public bool UpdateUser(int UserId, User user)
        {
            User usr = GetUserById(UserId);
            if (usr != null)
            {
                usr.UserName = user.UserName;
                usr.Password = user.Password;
                usr.RoleId = user.RoleId;
                usr.Manager = user.Manager;
                usr.Updated = user.Updated;
                usr.IsActive = usr.IsActive;
                usr.UpdatedBy = user.UpdatedBy;

                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool DeleteUser(int UserId)
        {
            User user = GetUserById(UserId);
            if (user != null)
            {
                user.IsActive = false;
                //_dbContext.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;

        }

        public User GetUserById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserId == id && x.IsActive == true);
            return user;
        }




        public UserViewModel GetUserDeatilsById(int id)
        {
            //var temp = (from x in _dbContext.Batches
            //            join y in _dbContext.Course
            //            on x.CourseId equals y.CourseId
            //            where x.IsActive == true && x.BatchId == id
            //            select new BatchViewModel
            //            {
            //                BatchId = x.BatchId,
            //                BatchName = x.BatchName,
            //                StartDate = x.StartDate,
            //                EndDate = x.EndDate,
            //                CourseName = y.CourseName,
            //                CourseId = y.CourseId
            //            }).FirstOrDefault();
            //return temp;

            var temp = (from x in _dbContext.Users
                        join y in _dbContext.Roles
                        on x.RoleId equals y.RoleId
                        where x.IsActive == true && x.UserId == id
                        select new UserViewModel
                        {
                            UserId = x.UserId,
                            UserName = x.UserName,
                            Password = x.Password,
                            RoleId = x.RoleId,
                            RoleName = y.RoleName
                        }).FirstOrDefault();
            return temp;
        }

        public List<UserViewModel> GetUsers()
        {
            List<UserViewModel> userView = (from x in _dbContext.Users
                                            join y in _dbContext.Roles
                                            on x.RoleId equals y.RoleId
                                            join manager in _dbContext.Users
                                            on x.ManagerId equals manager.ManagerId
                                            into managerJoin
                                            from m in managerJoin.DefaultIfEmpty()

                                            where x.IsActive == true
                                            select new UserViewModel
                                            {
                                                UserId = x.UserId,
                                                UserName = x.UserName,
                                                Password = x.Password,
                                                RoleName = y.RoleName,
                                                RoleId = y.RoleId,
                                                ManagerId = x.ManagerId,
                                                ManagerName = m.UserName
                                            }).ToList();

            return userView;


        }
        public List<Role> GetRoles()
        {
            return _dbContext.Roles.ToList();
        }

        public List<UserViewModel> GetManagerNames()
        {
            List<UserViewModel> manager = (from x in _dbContext.Users
                                           where x.IsActive == true && x.RoleId == 2
                                           select new UserViewModel
                                           {
                                               ManagerName = x.UserName,
                                               ManagerId = x.UserId
                                           }).ToList();
            return manager;
        }

        public List<UserViewModel> GetManagers(int id)
        {
            List<UserViewModel> managerInfo = (from x in _dbContext.Users
                                                   where x.IsActive == true && x.RoleId == 2
                                                   && x.UserId != id
                                                   select new UserViewModel
                                                   {
                                                       ManagerName = x.UserName,
                                                       ManagerId = x.UserId
                                                   }).ToList();
            return managerInfo;

        }
    }
}