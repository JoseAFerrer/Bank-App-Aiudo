using AutoMapper;
using BankAppAiudo.DbContexts;
using BankAppAiudo.Entities;
using BankAppAiudo.Helpers;
using BankAppAiudo.PersistenceModels;
using Microsoft.EntityFrameworkCore;
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
            var userfromDB = _context.Users.Find(id);
            if (!(userfromDB.Password == password))
            {
                throw new InvalidOperationException();
            }
            var refilleduser = FillUser(_mapper.Map<Cliente>(userfromDB));
            return refilleduser;
        }

        public IUser UpdatePassword(string id, string password, string newpassword)
        {
            var userfromDB = _context.Users.Find(id);
            if (!(userfromDB.Password == password))
            {
                throw new InvalidOperationException();
            }
            userfromDB.Password = newpassword;
            _context.Update(userfromDB);
            _context.SaveChanges();

            var refilleduser = FillUser(_mapper.Map<Cliente>(userfromDB));
            return refilleduser;
        }

        public void DeleteUser(string id, string password)
        {
            var userfromDB = _context.Users.Find(id);
            if (!(userfromDB.Password == password))
            {
                throw new InvalidOperationException();
            }
            _context.Remove(userfromDB);
            _context.SaveChanges();

            return;
        }
        public Transferencia TransferMoney(string destination, string responsibleId, string responsiblepassword, string concepto, string message, double amount)
        {
            var userfromDB = _context.Users.Find(responsibleId);
            var destineduserfromDB = _context.Users.Find(destination);
            if ((!(userfromDB.Password == responsiblepassword)) || (destineduserfromDB is null))
            {
                throw new InvalidOperationException();
            }
            var transferencia = new Transferencia(userfromDB.Id, destination, DateTimeOffset.UtcNow, userfromDB.Id, concepto, message, amount, Guid.NewGuid());
            userfromDB.Balance = userfromDB.Balance - amount;
            destineduserfromDB.Balance = destineduserfromDB.Balance + amount;

            _context.Movements.Add(_mapper.Map<MovimientoDocument>(transferencia));
            _context.Update(userfromDB);
            _context.Update(destineduserfromDB);
            _context.SaveChanges();

            return transferencia;
        }

        public Prestamo AskForALoan(string origin, string responsibleId, string responsiblepassword, string concepto, string message, double amount)
        {
            var userfromDB = _context.Users.Find(responsibleId);
            var interest = 4.5 / 100;

            if (!(userfromDB.Password == responsiblepassword))
            {
                throw new InvalidOperationException();
            }

            var prestamo = new Prestamo(origin, userfromDB.Id, DateTimeOffset.UtcNow, userfromDB.Id, concepto, message, amount, interest, Guid.NewGuid());
            
            _context.Users.Find(origin).Balance = _context.Users.Find(origin).Balance - amount;
            userfromDB.Balance = userfromDB.Balance + amount;
            Console.WriteLine(userfromDB.Balance);
            Console.WriteLine(userfromDB.Balance + amount);

            _context.Movements.Add(_mapper.Map<MovimientoDocument>(prestamo));
            _context.Users.Update(userfromDB);
            _context.Users.Update(_context.Users.Find(origin));
            _context.SaveChanges();

            return prestamo;
        }


        public List<IMovimiento> GetHistory(string id, string password)
        {
            var userfromDB = _context.Users.Find(id);
            if (!(userfromDB.Password == password))
            {
                throw new InvalidOperationException();
            }

            var movementsdocument = _context.Movements
               .Where(fila => fila.ResponsibleForThisId == id);

            var Historial = new List<IMovimiento>();

            foreach (var movimiento in movementsdocument)
            {
                if (movimiento.Interest>0)
                {
                    Historial.Add(_mapper.Map<Prestamo>(movimiento));
                }
                else
                {
                    Historial.Add(_mapper.Map<Transferencia>(movimiento));
                }
            }
            //Todo: meter también la deuda y el método para ejecutar la deuda, que se expresaría al usuario con HATEOAS.
            return Historial;
        }

        public List<Debt> GetDebts(string id, string password)
        {
            var userfromDB = _context.Users.Find(id);
            if (!(userfromDB.Password == password))
            {
                throw new InvalidOperationException();
            }

            var movementsdocument = _context.Movements
               .Where(fila => fila.ResponsibleForThisId == id);

            var Historial = new List<Debt>();

            foreach (var movimiento in movementsdocument)
            {
                if (movimiento.Interest > 0)
                {
                    Historial.Add(new Debt(_mapper.Map<Prestamo>(movimiento)));
                }
            }
            //Todo: meter también la deuda y el método para ejecutar la deuda, que se expresaría al usuario con HATEOAS.
            return Historial;
        }

        public Cliente FillUser(Cliente cliente)
        {
            var movementsdocument = _context.Movements
               .Where(fila => fila.ResponsibleForThisId == cliente.Id);

            var histocliente = GetHistory(cliente.Id, cliente.Password);
            var deudacliente = GetDebts(cliente.Id, cliente.Password); //Lo ideal sería que todo esto solo
                                                                       //hiciera un acceso a base de datos y todo eso,
                                                                       //pero por el momento se queda así.
                                                                       //Todo.

            cliente.Historial = histocliente;
            cliente.Deudas = deudacliente;
            //foreach (var movimiento in movementsdocument)
            //{
            //    if (movimiento.Interest > 0)
            //    {
            //        cliente.Historial.Add(_mapper.Map<Prestamo>(movimiento));
            //    }
            //    else
            //    {
            //        cliente.Historial.Add(_mapper.Map<Transferencia>(movimiento));
            //    }
            //}
            //Todo: meter también la deuda y el método para ejecutar la deuda, que se expresaría al usuario con HATEOAS.
            return cliente;
        }
    }
}
