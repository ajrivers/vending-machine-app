using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using VendingMachineApp.Helpers.Enums;

namespace VendingMachineApp.Model
{
    public class Product
    {
        #region Properties

        /// <summary>
        /// Product ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product Type
        /// </summary>
        public ProductTypeEnum Type { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Image URL for Display
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Price of the product, in euros
        /// </summary>
        public double Price { get; set; }

        #endregion
    }
}
