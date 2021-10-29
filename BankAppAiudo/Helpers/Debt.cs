using BankAppAiudo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppAiudo.Helpers
{
    public class Debt
    {
        public double Amount { get; set; }
        public DateTimeOffset SinceWhen { get; set; }
        public string IndebtedToId { get; set; }
        public Debt(Prestamo prestamo)
        {
            Amount = prestamo.Amount * (1+prestamo.Interest);
            SinceWhen = prestamo.Time;
            IndebtedToId = prestamo.OriginId;
        }
    }
}
