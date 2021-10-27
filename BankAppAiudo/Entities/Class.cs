using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppAiudo.Entities
{
    public class Cliente
    {
        public string Id { get; private set; }
        public string Password { get; private set; }

        public Cliente(string id, string password)
        {
            Id = id;
            Password = password;
        }

        public double Balance { get; private set; }
        //Historial: Lista de movimientos
        //Deuda: lista de préstamos
        //Número de cuenta

    }
}
