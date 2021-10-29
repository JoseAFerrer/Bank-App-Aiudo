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
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UserController> _logger;
        private readonly IBankAppRepository bankAppRepository;

        public UserController(ILogger<UserController> logger, IBankAppRepository bankAppRepository)
        {
            _logger = logger;
            this.bankAppRepository = bankAppRepository;
        }

        [HttpGet(Name ="GetUser")]
        [HttpHead]
        public Cliente GetUser()
        {
            //Todo: esto obviamente hay que corregirlo, es provisional. De hecho, tendrá que venir del header, o de algún otro sitio.
            var userid = "Pepetoni"; var userpassword = "pepetonispassword";
            var cliente = bankAppRepository.GetUser(userid, userpassword);

            return (Cliente)cliente;
        }
    }
}
