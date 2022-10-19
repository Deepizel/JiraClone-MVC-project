using JiraClone.Domain.Contract.UsersViewModel;
using JiraClone.Domain.Contract.UserViewModel;
using JiraClone.Domain.Entities;
using JiraClone.EntityFrameworkCore;
using JiraClone.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Services.Services
{
    public class UserService : IUserService
    {
        private JiraCloneDbContext _db;

        public async Task<List<UserViewModel>> AllUsers()
        {
            try
            {
                var users = await _db.Users.Select(x => new UserViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Department = x.Department,
                    Email = x.Email,
                    JobTitle = x.JobTitle
                }).ToListAsync();
                if (users == null)
                {
                    throw new Exception("No Issue Found");
                }
                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<UserViewModel> AuthenticateUser(LoginUserViewModel model)
        {
            throw new NotImplementedException();
        }


        public async Task<UserViewModel> CreateUser(UserViewModel model)
        {
            try
            {
                var user = new User
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    JobTitle = model.JobTitle,
                    Department = model.Department,
                    Email = model.Email,
                    CreatedOn = DateTime.Now,
                    //password encrypted
                };

                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();

                return new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    JobTitle = user.JobTitle,
                    Department = user.Department,
                    Email = user.Email,
                };

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<CreateUserViewModel> CreateUser(CreateUserViewModel Model)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteUser(int id)
        {
            try
            {
                var userToBeDeleted = await _db.Users.FindAsync(id);
                if (userToBeDeleted == null)
                    throw new Exception("Cannot delete a user that doesn't exist");

                _db.Users.Remove(userToBeDeleted);
                await _db.SaveChangesAsync();

                return "User deleted successfully";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<string> DisableUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserViewModel> GetUser(int id)
        {
            try
            {
                var user = await _db.Users.Where(user => user.Id == id).Select(user => new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    JobTitle = user.JobTitle,
                    Department = user.Department,
                    Email = user.Email
                }).FirstOrDefaultAsync();

                if (user == null) throw new Exception("No user found");

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

     

        public async Task<UserViewModel> UpdateUser(UpdateUserViewModel model)
        {
            try
            {
                if (model == null || model.Id < 1)
                    throw new Exception("Id is not provided.");

                //get the user
                var user = await _db.Users.FindAsync(model.Id);

                //update the user
                if (user == null)
                    throw new Exception("This user cannot be retrieved at the moment.");

                user.FirstName = string.IsNullOrEmpty(model.FirstName) ? user.FirstName : model.FirstName;
                user.LastName = string.IsNullOrEmpty(model.LastName) ? user.LastName : model.LastName;
                user.Email = string.IsNullOrEmpty(model.Email) ? user.Email : model.Email;
                user.JobTitle = string.IsNullOrEmpty(model.JobTitle) ? user.JobTitle : model.JobTitle;
                user.Department = string.IsNullOrEmpty(model.Department) ? user.FirstName : model.Department;
                user.Password = string.IsNullOrEmpty(model.Password) ? user.Password : model.Password;
                user.UpdatedOn = DateTime.Now;


                _db.Entry(user).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    JobTitle = user.JobTitle,
                    Department = user.Department,
                    Email = user.Email,
                };

            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}


   
