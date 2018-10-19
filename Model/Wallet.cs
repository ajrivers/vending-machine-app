using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using VendingMachineApp.Helpers.Enums;

namespace VendingMachineApp.Model
{
    /// <summary>
    /// Collection of coins owned by the vending machine or the customer
    /// </summary>
    public class Wallet
    {
        #region Properties

        /// <summary>
        /// Wallet ID
        /// </summary>
        public int WalletId { get; set; }

        /// <summary>
        /// Owner of the Wallet (Customer or Vending Machine)
        /// </summary>
        public OwnerType Owner { get; set; }

        /// <summary>
        /// Collection of coins in the wallet
        /// </summary>
        public List<CoinBudget> Coins { get; set; }

        #endregion
    }
}
