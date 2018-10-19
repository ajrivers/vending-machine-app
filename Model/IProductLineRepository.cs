using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachineApp.Model
{
    public interface IProductLineRepository
    {
        IEnumerable<ProductLine> ProductLines { get; }
    }
}
