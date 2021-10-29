using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppAiudo.Entities
{
    public class Prestamo : IMovimiento
    {
        public string OriginId { get; protected set; }
        public string DestinationId { get; protected set; }
        public DateTimeOffset Time { get; protected set; }
        public string ResponsibleForThisId { get; protected set; }
        public string Concepto { get; protected set; }
        public string Message { get; protected set; }
        public double Amount { get; protected set; }
        public double Interest { get; set; }
        public Guid TransferId { get; protected set; }


        public Prestamo(string origin, string destination, DateTimeOffset time, string responsible, string concepto, string message, double amount, double interest)
        {//Ctor de préstamo nuevo
            OriginId = origin; DestinationId = destination; Time = time; ResponsibleForThisId = responsible; Concepto = concepto; Message = message; Amount = amount; Interest = interest;
            TransferId = Guid.NewGuid();
        }
        public Prestamo(string origin, string destination, DateTimeOffset time, string responsible, string concepto, string message, double amount, double interest, Guid transferId)
        {//Ctor de préstamo ya existente.
            OriginId = origin; DestinationId = destination; Time = time; ResponsibleForThisId = responsible; Concepto = concepto; Message = message; Amount = amount; Interest = interest; TransferId = transferId;
        }

        public Prestamo()
        {

        }
    }
}
