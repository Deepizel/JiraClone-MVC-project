using JiraClone.Domain.Contract.UserViewModel;
using JiraClone.Helpers.Formatting;
using JiraClone.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JiraClone.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public IActionResult Index()
        {
            return View();
        }

        [Route("createUser")]
        [HttpPost]
        public async Task<DataResult> CreateIssue(CreateUserViewModel model)
        {
            DataResult dataResult;
            try
            {
                if (!ModelState.IsValid)
                {
                    dataResult = new DataResult
                    {
                        StatusCode = "400",
                        Message = "Bad Request",
                        Data = false
                    };
                }

                try
                {
                    object data = await _userService.CreateUser(model);
                    dataResult = new DataResult
                    {
                        StatusCode = "200",
                        Message = "Successful",
                        Data = data
                    };
                }
                catch (Exception ex)
                {

                    dataResult = new DataResult
                    {
                        StatusCode = "404",
                        Message = ex.Message,
                        Data = false
                    };
                }
            }

            catch (Exception ex)
            {

                dataResult = new DataResult
                {
                    StatusCode = "406",
                    Message = "Unknown Error",
                    ExceptionErrorMessage = ex.Message,
                    Data = null
                };
            }
            return dataResult;
        }

        [Route("getUsers")]
        [HttpGet]
        public async Task<DataResult> AllUsers()
        {
            DataResult dataResult;
            try
            {
                if (!ModelState.IsValid)
                {
                    dataResult = new DataResult
                    {
                        StatusCode = "400",
                        Message = "Bad Request",
                        Data = false
                    };
                }

                try
                {
                    object data = await _userService.AllUsers();
                    dataResult = new DataResult
                    {
                        StatusCode = "200",
                        Message = "Successful",
                        Data = data
                    };
                }
                catch (Exception ex)
                {

                    dataResult = new DataResult
                    {
                        StatusCode = "404",
                        Message = ex.Message,
                        Data = false
                    };
                }
            }

            catch (Exception ex)
            {

                dataResult = new DataResult
                {
                    StatusCode = "406",
                    Message = "Unknown Error",
                    ExceptionErrorMessage = ex.Message,
                    Data = null
                };
            }
            return dataResult;
        }

        [Route("getUser")]
        [HttpGet]
        public async Task<DataResult> GetUser(int id)
        {
            DataResult dataResult;
            try
            {
                if (!ModelState.IsValid)
                {
                    dataResult = new DataResult
                    {
                        StatusCode = "400",
                        Message = "Bad Request",
                        Data = false
                    };
                }

                try
                {
                    object data = await _userService.GetUser(id);
                    dataResult = new DataResult
                    {
                        StatusCode = "200",
                        Message = "Successful",
                        Data = data
                    };
                }
                catch (Exception ex)
                {

                    dataResult = new DataResult
                    {
                        StatusCode = "404",
                        Message = ex.Message,
                        Data = false
                    };
                }
            }

            catch (Exception ex)
            {

                dataResult = new DataResult
                {
                    StatusCode = "406",
                    Message = "Unknown Error",
                    ExceptionErrorMessage = ex.Message,
                    Data = null
                };
            }
            return dataResult;
        }

        [Route("updateUser")]
        [HttpPut]
        public async Task<DataResult> UpdateUser(UpdateUserViewModel model)
        {
            DataResult dataResult;
            try
            {
                if (!ModelState.IsValid)
                {
                    dataResult = new DataResult
                    {
                        StatusCode = "400",
                        Message = "Bad Request",
                        Data = false
                    };
                }

                try
                {
                    object data = await _userService.UpdateUser(model);
                    dataResult = new DataResult
                    {
                        StatusCode = "200",
                        Message = "Successful",
                        Data = data
                    };
                }
                catch (Exception ex)
                {

                    dataResult = new DataResult
                    {
                        StatusCode = "404",
                        Message = ex.Message,
                        Data = false
                    };
                }
            }

            catch (Exception ex)
            {

                dataResult = new DataResult
                {
                    StatusCode = "406",
                    Message = "Unknown Error",
                    ExceptionErrorMessage = ex.Message,
                    Data = null
                };
            }
            return dataResult;
        }
    }
}
