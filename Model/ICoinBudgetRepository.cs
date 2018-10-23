using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachineApp.Model
{
    public interface ICoinBudgetRepository
    {
        IEnumerable<CoinBudget> CoinBudgets { get; }

        void AddCoinBudgets(IEnumerable<CoinBudget> coins);
        bool ReturnCoinBudget(float value);
        double[] ReturnCoinValues();
    }
}
