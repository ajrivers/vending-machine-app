using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace VendingMachineApp.Model
{
    public class ProductLineRepository : IProductLineRepository
    {
        #region Attributes

        private readonly AppDbContext _appDbContext;

        #endregion

        #region Properties

        public IEnumerable<ProductLine> ProductLines
        {
            get
            {
                return _appDbContext.ProductLines.Include(p => p.Product);
            }
        }

        #endregion

        #region Constructor

        public ProductLineRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #endregion
    }
}
