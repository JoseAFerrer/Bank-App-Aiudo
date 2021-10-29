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

        public Cliente(string id, string password, int accnumber) //Todo: realmente cuando cargues un cliente el número de cuenta ya lo tendrás,
                                                                  //así que no tiene sentido pedirlo porque la base de datos siempre te lo va a dar.
        {
            Id = id;
            Password = password;
            AccountNumber = accnumber;
        }
        public Cliente(string id, string password, double amount)
        {
            Id = id;
            Password = password;
            Balance = amount;
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
