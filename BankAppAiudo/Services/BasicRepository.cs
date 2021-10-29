using AutoMapper;
using BankAppAiudo.DbContexts;
using BankAppAiudo.Entities;
using BankAppAiudo.Helpers;
using BankAppAiudo.PersistenceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppAiudo.Services
{
    public class BasicRepository : IBankAppRepository
    {
        Random randomgenerator = new();

        private readonly BankAppContext _context;
        private readonly IMapper _mapper;

        public BasicRepository(BankAppContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
        }
        //Todo: Aquí básicamente tenemos que decidir qué inyectar para que todo funcione y haya una base de datos como Dios manda xd. A llorar.

        public IUser CreateUser(string id, string password, double amount)
        {
            var newuser = new Cliente(id, password, amount);
            Random randomgenerator = new();
            newuser.AccountNumber = randomgenerator.Next(1000000, 9999999);

            var newusertoDB = _mapper.Map<ClienteDocument>(newuser);

            _context.Add(newusertoDB);
            _context.SaveChanges();

            var userfromDB =_context.Users.Find(id);

            return _mapper.Map<Cliente>(userfromDB); //Todo: sacar esto de aquí, utilizarlo para el resto del repo
        }
        public IUser GetUser(string id, string password)
        { //TODO conseguir el cliente realmente de la base de datos, y no inventárselo (esto es relleno).
            return new Cliente(id, password, randomgenerator.Next(1000000, 9999999));
        }
        //public IUser GetUserMaster(string id, string masterid, string masterpassword)
        //{ //TODO conseguir el cliente realmente de la base de datos, y no inventárselo (esto es relleno).
        //    return new Cliente(id, masterpassword, randomgenerator.Next(1000000, 9999999));
        //}
        public Transferencia TransferMoney(string origin, string destination, string responsible, string concepto, string message, double amount)
        {
            return new Transferencia(origin, destination, DateTimeOffset.Now, responsible, concepto, message, amount); //Construimos el objeto y lo devolvemos.
        }

        public Prestamo AskForALoan(string origin, string destination, string responsible, string concepto, string message, double amount)
        {
            var interest = 4.5 / 100;
            return new Prestamo(origin, destination, DateTimeOffset.Now, responsible, concepto, message, amount, interest); //Construimos el objeto y lo devolvemos.
        }

        public IUser UpdateUser(string id, string password, IUser reneweduser)
        {
            throw new NotImplementedException();
        }

        public IUser DeleteUser(string id, string password)
        {
            throw new NotImplementedException();
        }

        public List<IMovimiento> GetHistory(string id, string password)
        {
            throw new NotImplementedException();
        }

        public List<Debt> GetDebts(string id, string password)
        {
            throw new NotImplementedException();
        }
    }
}
