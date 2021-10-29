using BankAppAiudo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppAiudo.Entities
{
    public class Cliente : IUser
    {
        public string Id { get; protected set; }
        public string Password { get; protected set; }
        public int AccountNumber { get;  set; }
        public double Balance { get; protected set; }
        public List<IMovimiento> Historial { get; protected set; }
        public List<Debt> Deudas { get; protected set; }

        public Cliente(string id, string password, int accnumber)
        {
            Id = id;
            Password = password;
            AccountNumber = accnumber;
        }


        string IUser.ChangePassword(string id, string password, string newpassword)
        {
            string result;
            if (id == Id && password == Password)
            {
                Password = newpassword;
                result = "Your password was changed successfully";
            }
            else
            { result = "Either your id or your password do not match"; }

            return result;
        }


    }
}
