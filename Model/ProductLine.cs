using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachineApp.Model
{
    /// <summary>
    /// Collection of products of the same type available in a vending machine
    /// </summary>
    public class ProductLine
    {
        #region Properties

        /// <summary>
        /// Product Line ID
        /// </summary>
        public int ProductLineId { get; set; }

        /// <summary>
        /// Product available in this line
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Amount of products available in this line
        /// </summary>
        public int Amount { get; set; }

        #endregion
    }
}
