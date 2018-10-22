using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachineApp.Model
{
    public class CoinBudget
    {
        #region Properties

        /// <summary>
        /// Coin Budget ID
        /// </summary>
        public int CoinBudgetId { get; set; }

        /// <summary>
        /// Coin value
        /// </summary>
        public float Value { get; set; }

        /// <summary>
        /// Amount of coins available
        /// </summary>
        public int Amount { get; set; }

        #endregion
    }
}
