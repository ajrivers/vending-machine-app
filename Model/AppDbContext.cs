using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace VendingMachineApp.Model
{
    public class AppDbContext : DbContext
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        #endregion

        #region Properties

        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<CoinBudget> CoinBudgets { get; set; }

        #endregion
    }
}
