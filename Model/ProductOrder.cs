using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachineApp.Model
{
    public class ProductOrder
    {
        public IEnumerable<CoinBudget> coins { get; set; }
        public int productId { get; set; }
        public decimal credit { get; set; }
    }
}
