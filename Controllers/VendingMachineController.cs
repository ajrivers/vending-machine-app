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
        private readonly ICoinBudgetRepository _coinBudgetRepository;

        #endregion

        #region Constructor

        public VendingMachineController(IProductLineRepository productLineRepository, ICoinBudgetRepository coinBudgetRepository)
        {
            _productLineRepository = productLineRepository;
            _coinBudgetRepository = coinBudgetRepository;
        }

        #endregion

        #region Actions

        [HttpGet("[action]")]
        public IEnumerable<ProductLine> GetProductLines()
        {
            return _productLineRepository.ProductLines;
        }

        [HttpGet("[action]/{productLineId}")]
        public ProductLine GetProductLine(int productLineId)
        {
            return _productLineRepository.GetProductLineById(productLineId);
        }

        [HttpPost("[action]")]
        public JsonResult SellProduct([FromBody] ProductOrder order)
        {
            try
            {
                ProductLine selectedProductLine = _productLineRepository.ProductLines.First(p => p.Product.ProductId == order.productId);
                decimal returnCredit = (decimal)(order.credit - selectedProductLine.Product.Price);
                List<CoinBudget> returnCoins = new List<CoinBudget>();
                if(selectedProductLine != null && selectedProductLine.Amount > 0)
                {
                    if(selectedProductLine.Product.Price <= order.credit)
                    {
                        _coinBudgetRepository.AddCoinBudgets(order.coins);
                        _productLineRepository.DeliverProductLine(selectedProductLine.ProductLineId);
                        
                        if(returnCredit > 0)
                        {
                            decimal[] values = _coinBudgetRepository.ReturnCoinValues();
                            foreach(decimal value in values)
                            {
                                bool emptyBudget = false;
                                while (returnCredit >= value && !emptyBudget)
                                {
                                    emptyBudget = !_coinBudgetRepository.ReturnCoinBudget(value);
                                    if (!emptyBudget)
                                    {
                                        CoinBudget returnCoin = returnCoins.FirstOrDefault(cb => cb.Value == value);
                                        if (returnCoin == null)
                                            returnCoins.Add(new CoinBudget() { Value = value, Amount = 1 });
                                        else
                                            returnCoin.Amount++;

                                        returnCredit = Math.Round(returnCredit - value, 2);
                                    }
                                }

                                if (returnCredit <= 0)
                                    break;
                            }
                        }
                    }
                    else
                    {
                        decimal creditLeft = selectedProductLine.Product.Price - order.credit;
                        return new JsonResult(new { Success = false, Message = string.Format("Insufficient Amount. You need to insert {0} to buy this product", creditLeft) });
                    }
                }
                else
                {
                    return new JsonResult(new { Success = false, Message = "Product Not Available!" });
                }

                string sMessage = "Thank You!!";
                if (returnCredit > 0)
                    sMessage += string.Format(" Unable to return €{0:N2}", returnCredit);

                return new JsonResult(new { Success = true,
                    Message = sMessage,
                    CoinsReturned = returnCoins,
                    Total = returnCoins != null ? returnCoins.Sum(cb => (cb.Amount * cb.Value)) : 0
                    });
            }
            catch(Exception ex)
            {
                return new JsonResult(new { Success = false, Message = string.Format("EXCEPTION: {0}", ex.Message) });
            }
        }

        #endregion
    }
}