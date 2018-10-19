using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using VendingMachineApp.Model;

namespace VendingMachineApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendingMachineController : ControllerBase
    {
        #region Attributes

        private readonly IProductLineRepository _productLineRepository;

        #endregion

        #region Constructor

        public VendingMachineController(IProductLineRepository productLineRepository)
        {
            _productLineRepository = productLineRepository;
        }

        #endregion

        #region Actions

        [HttpGet("[action]")]
        public IEnumerable<ProductLine> GetProductLines()
        {
            return _productLineRepository.ProductLines;
        }

        #endregion
    }
}