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
    [Route("api/userarea/movements")] //    [Route("api/userarea/{userId}/movements")] Antes era así pero daba problemas. todo: arreglar.
    public class MovementsController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IBankAppRepository _bankAppRepository;

        public MovementsController(ILogger<UserController> logger, IBankAppRepository bankAppRepository)
        {
            _logger = logger;
            _bankAppRepository = bankAppRepository;
        }

        [HttpGet(Name = "Look at your history")]
        [HttpHead]
        public List<IMovimiento> GetHistory(
            string userid,
            string userpassword)
        {
            var history = _bankAppRepository.GetHistory(userid, userpassword);

            return history;
        }

        [HttpPost(Name = "Transfer or borrow money")] //Todo: la función "ejecutar deuda" debería ir aquí, supongo,
                                                      //porque al fin y al cabo estás creando una transferencia.
        public IMovimiento TransferOrBorrow(
            string responsibleId,
            string responsiblepassword,
            string theotheruser,
            string concepto,
            string message,
            double amount,
            string TransferOrBorrow)
        {
            if (TransferOrBorrow == "Transfer")
            {
                var transfer = _bankAppRepository.TransferMoney(theotheruser,
                                                responsibleId,
                                                responsiblepassword,
                                                concepto,
                                                message,
                                                amount);
                return transfer;
            }
            else if (TransferOrBorrow == "Borrow")
            {
                var loan = _bankAppRepository.AskForALoan(theotheruser,
                                                responsibleId,
                                                responsiblepassword,
                                                concepto,
                                                message,
                                                amount);
                return loan;
            }
            else
                throw new InvalidOperationException();
        }
    }
}
