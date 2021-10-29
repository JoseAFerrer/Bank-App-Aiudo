using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppAiudo.Entities
{
    public class Transferencia : IMovimiento
    {
        public string OriginId { get;  protected set; }
        public string DestinationId { get; protected set; }
        public DateTimeOffset Time { get; protected set; }
        public string ResponsibleForThisId { get; protected set; }
        public string Concepto { get; protected set; }
        public string Message { get; protected set; }
        public double Amount { get; protected set; }
        public Guid TransferId { get; protected set; }
        
        public Transferencia(string origin, string destination, DateTimeOffset time, string responsible, string concepto, string message, double amount)
        {//Constructor de nuevas transferencias: no tiene Guid de base, así que lo genera en el momento.
            OriginId = origin; DestinationId = destination; Time = time; ResponsibleForThisId = responsible; Concepto = concepto; Message = message; Amount = amount;
            TransferId = Guid.NewGuid();
        }
        
        public Transferencia(string origin, string destination, DateTimeOffset time, string responsible, string concepto, string message, double amount, Guid transferId)
        {//Constructor para transferencias que ya existían y por lo tanto ya tienen Id.
            OriginId = origin; DestinationId = destination; Time = time; ResponsibleForThisId = responsible; Concepto = concepto; Message = message; Amount = amount; TransferId = transferId;
        }

    }
}
