using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppAiudo.PersistenceModels
{
    public class MovimientoDocument
    {
        [Key]
        public Guid TransferId { get; set; }
        public string ResponsibleForThisId { get; set; }
        public string OriginId { get; set; }
        public string DestinationId { get; set; }
        public DateTimeOffset Time { get; set; }
        public string Concepto { get; set; }
        public string Message { get; set; }
        public double Amount { get; set; }
        public double Interest { get; set; }

        public MovimientoDocument(string origin, string destination, DateTimeOffset time, string responsible, string concepto, string message, double amount, double interest, Guid transferId)
        {
            OriginId = origin; DestinationId = destination; Time = time; ResponsibleForThisId = responsible; Concepto = concepto; Message = message; Amount = amount; Interest = interest; TransferId = transferId;
        }
        public MovimientoDocument()
        {}

    }
}
