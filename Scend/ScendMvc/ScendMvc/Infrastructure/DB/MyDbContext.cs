using Microsoft.EntityFrameworkCore;
using ScendMvc.Models.Paypal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScendMvc.Infrastructure.DB
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<PaypalOrderParamterModel> PaypalOrder { get; set; }

        public DbSet<PaypalRecord> PaypalRecord { get; set; }

        public DbSet<ApiTransaction> ApiTransactions { get; set; }
        public DbSet<Api> Apis { get; set; }

        public DbSet<PaypalTokenId> PaypalTokenId { get; set; }
    }
}
