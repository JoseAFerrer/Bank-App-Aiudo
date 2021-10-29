using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppAiudo.PersistenceModels
{
    public class MovimientoDocument
    {
        Guid TransferId { get; }
        string ResponsibleForThisId { get; }
        string OriginId { get; }
        string DestinationId { get; }
        DateTimeOffset Time { get; }
        string Concepto { get; }
        string Message { get; }
        double Amount { get; }
        double Interest { get; }

        public MovimientoDocument(string origin, string destination, DateTimeOffset time, string responsible, string concepto, string message, double amount, double interest, Guid transferId)
        {//Ctor de préstamo ya existente.
            OriginId = origin; DestinationId = destination; Time = time; ResponsibleForThisId = responsible; Concepto = concepto; Message = message; Amount = amount; Interest = interest; TransferId = transferId;
        }

    }
}
