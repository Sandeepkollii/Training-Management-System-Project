namespace Project_WebApi.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string RoleName {  get; set; }

        public int RoleId {  get; set; }

        public int? ManagerId { get; set; }
        public string? ManagerName { get; set; }

    }
}
