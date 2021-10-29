using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppAiudo.Entities
{
    public interface IMovimiento
    {
        string OriginId { get; }
        string DestinationId { get;  }
         DateTimeOffset Time { get; }
         string ResponsibleForThisId { get; }
         string Concepto { get;  }
         string Message { get; }
        double Amount { get; }
        Guid TransferId { get;}

    }
}
