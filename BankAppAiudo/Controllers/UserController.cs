using BankAppAiudo.Entities;
using BankAppAiudo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppAiudo.Controllers //TODO Este es el controlador bueno de los usuarios.
{
    [ApiController]
    [Route("api/userarea")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IBankAppRepository _bankAppRepository;

        public UserController(ILogger<UserController> logger, IBankAppRepository bankAppRepository)
        {
            _logger = logger;
            _bankAppRepository = bankAppRepository;
        }

        [HttpGet(Name ="Look at your profile")]
        [HttpHead]
        public Cliente GetUser(
            string userid,
            string userpassword)
        {
            var cliente = _bankAppRepository.GetUser(userid, userpassword);

            return (Cliente)cliente;
        }

        [HttpPost(Name = "Create a new user")]
        public Cliente CreateUser(
            string userid,
            string userpassword,
            double amount)
        {
            var cliente = _bankAppRepository.CreateUser(userid, userpassword, amount);

            return (Cliente)cliente;
        }

        [HttpPut(Name = "Update your password")]
        public Cliente Update(
            string userid,
            string userpassword,
            string newpassword)
        {
            var cliente = _bankAppRepository.UpdatePassword(userid, userpassword, newpassword);

            return (Cliente)cliente;
        }

        [HttpDelete(Name = "Delete your user (it's forever!)")]
        public void DeleteUser(
                            string userid,
                            string userpassword)
        {
            _bankAppRepository.DeleteUser(userid, userpassword);

            return ;
        }
    }
}
