using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace VendingMachineApp.Model
{
    public class CoinBudgetRepository : ICoinBudgetRepository
    {
        #region Attributes

        private readonly AppDbContext _appDbContext;

        #endregion

        #region Properties

        public IEnumerable<CoinBudget> CoinBudgets
        {
            get
            {
                return _appDbContext.CoinBudgets;
            }
        }

        #endregion

        #region Constructor

        public CoinBudgetRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #endregion

        #region Methods

        public void AddCoinBudgets(IEnumerable<CoinBudget> coins)
        {
            foreach(CoinBudget coin in coins)
            {
                CoinBudget existingCB = _appDbContext.CoinBudgets.First<CoinBudget>(cb => cb.Value == coin.Value);
                if (existingCB == null)
                    _appDbContext.CoinBudgets.Add(new CoinBudget() { Value = coin.Value, Amount = 1 });
                else
                    existingCB.Amount += 1;
            }

            _appDbContext.SaveChanges();
        }

        public bool ReturnCoinBudget(float value)
        {
            bool result = false;

            CoinBudget cbResult = _appDbContext.CoinBudgets.First(cb => cb.Value == value);
            if(cbResult != null && cbResult.Amount > 0)
            {
                cbResult.Amount--;
                result = true;
                _appDbContext.SaveChanges();
            }

            return result;
        }

        public float[] ReturnCoinValues()
        {
            return _appDbContext.CoinBudgets.OrderByDescending(cb => cb.Value).Select(cb => cb.Value).Distinct().ToArray<float>();
        }

        #endregion
    }
}
