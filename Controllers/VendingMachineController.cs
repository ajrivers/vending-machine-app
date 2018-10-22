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

        [HttpPost("[action]")]
        public JsonResult SellProduct(IEnumerable<CoinBudget> coins, int productId, float credit)
        {
            try
            {
                ProductLine selectedProductLine = _productLineRepository.ProductLines.First(p => p.Product.ProductId == productId);
                List<CoinBudget> returnCoins = new List<CoinBudget>();
                if(selectedProductLine != null && selectedProductLine.Amount > 0)
                {
                    if(selectedProductLine.Product.Price <= credit)
                    {
                        _coinBudgetRepository.AddCoinBudgets(coins);
                        float returnCredit = credit - (float)selectedProductLine.Product.Price;
                        if(returnCredit > 0)
                        {
                            float[] values = _coinBudgetRepository.ReturnCoinValues();
                            foreach(float value in values)
                            {
                                bool emptyBudget = false;
                                while (returnCredit > value && !emptyBudget)
                                {
                                    emptyBudget = !_coinBudgetRepository.ReturnCoinBudget(value);
                                    if (!emptyBudget)
                                    {
                                        CoinBudget returnCoin = returnCoins.First(cb => cb.Value == value);
                                        if (returnCoin == null)
                                            returnCoins.Add(new CoinBudget() { Value = value, Amount = 1 });
                                        else
                                            returnCoin.Amount++;
                                    }
                                }

                                if (returnCredit <= 0)
                                    break;
                            }
                        }
                    }
                    else
                    {
                        float creditLeft = (float)selectedProductLine.Product.Price - credit;
                        return new JsonResult(new { Success = false, Message = string.Format("You need to insert {0} to buy this product", creditLeft) });
                    }
                }
                else
                {
                    return new JsonResult(new { Success = false, Message = "Product Not Available!" });
                }

                return new JsonResult(new { Success = true, Message = "Product Delivered!", Coins = returnCoins });
            }
            catch(Exception ex)
            {
                return new JsonResult(new { Success = false, Message = string.Format("EXCEPTION: {0}", ex.Message) });
            }
        }

        #endregion
    }
}