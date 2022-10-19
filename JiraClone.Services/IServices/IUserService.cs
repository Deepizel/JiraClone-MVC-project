using JiraClone.Domain.Contract.UsersViewModel;
using JiraClone.Domain.Contract.UserViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Services.IServices
{
    public interface IUserService
    {
        Task<UserViewModel> AuthenticateUser(LoginUserViewModel model);
        public Task<List<UserViewModel>> AllUsers();
        Task<UserViewModel> GetUser(int id);
        public Task<CreateUserViewModel> CreateUser(CreateUserViewModel Model);
        Task<UserViewModel> UpdateUser(UpdateUserViewModel model);
        Task<string> DeleteUser(int id);
        Task<string> DisableUser(int id);
        
    }
}
