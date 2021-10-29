using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppAiudo.PersistenceModels
{
    public class ClienteDocument //Esta clase sirve de cliente simplificado para poder guardarlo.
    {
        [Key]
        public string Id { get; protected set; }
        public string Password { get; protected set; }
        public int AccountNumber { get; set; }
        public double Balance { get; protected set; }

        public ClienteDocument(string id, string password, int accnumber, double balance)
        {
            Id = id;
            Password = password;
            AccountNumber = accnumber;
            Balance = balance;
        }
        public ClienteDocument()
        {  }

    }
}
