using BankAppAiudo.PersistenceModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppAiudo.DbContexts
{
    public class BankAppContext: DbContext
    {
        public BankAppContext(DbContextOptions<BankAppContext> options) : base(options)
        {

        }

        public DbSet<ClienteDocument> CatalogItems { get; set; }

        public DbSet<MovimientoDocument> CatalogBrands { get; set; }

    }
}
