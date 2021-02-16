using Asa.ApartmentSystem.Infra.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using ASa.ApartmentManagement.Core.BaseInfo.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.ApplicationService
{
    public class ExpenseService
    {
        ITableGatwayFactory tableGatwayFactory;
        public BaseInfoApplicationService(string connectionString)
        {
            //HACK: This approach is not the best one, we will change it as soon as DI tools get introduced
            tableGatwayFactory = new SqlTableGatewayFactory(connectionString);
        }
  
        public async Task<int> CreateExpnense(string title , DateTime from , DateTime to , decimal cost )
        {
            var expensemanager = new ExpenseManager(tableGatwayFactory);
            var expense= new ExpenseDTO { title = title, from = from , to=to , cost=cost };
            await expensemanager.AddExpense(expense);
            return expense.Id;
        }

        public async Task<int> CreateExpnenseGroup(string title , enum formula){

            var expensemanager = new ExpenseManager(tableGateway);
            var expenseg = new ExpenseGroupDTO{title = title , formula = formula};
            await expensemanager.AddExpenseGroup(expenseg);
            return expenseg.id ;
        }

    }
}
