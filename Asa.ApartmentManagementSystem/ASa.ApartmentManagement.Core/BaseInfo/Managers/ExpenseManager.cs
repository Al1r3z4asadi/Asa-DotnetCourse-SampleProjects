using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using ASa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASa.ApartmentManagement.Core.BaseInfo.Managers
{
    public class ExpenseManager
    {
        ITableGatwayFactory _tablegatwayFactory;
        public BuildingManager(ITableGatwayFactory tablegatwayFactory)
        {
            _tablegatwayFactory = tablegatwayFactory;
        }
       
        public async Task AddExpense(ExpenseDTO expense){
          
          var tableGateway = _tablegatwayFactory.CreateIExpenseTableGateway();
          var id = await tableGateway.InsertExpenseAsync(expense).ConfigureAwait(false);
          expense.id = id ;
        }


        public async Task AddExpenseGroup(ExpenseGroupDTO expensegroup){
          var tableGateway = _tablegatwayFactory.CreateIExpenseTableGateway();
          var id = await tableGateway.InsertExpenseGroupAsync(expensegroup).ConfigureAwait(false);
          expensegroup.id = id ;
        }
       
        public async Task<IEnumerable<ExpenseDTO>> GetExpenses(int expenseID)
        {
            var tableGateway = _tablegatwayFactory.CreateIExpenseGroupTableGateway();
            return  await tableGateway.GetAllExpenses(expenseID).ConfigureAwait(false);            
        }

    }
}