using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ASa.ApartmentManagement.Core.BaseInfo.DataGateways
{
    public interface IExpenseGroupTableGateway
    {
        Task<int> InsertExpenseGroupAsync(ExpenseGroup expensegroup);
    }
}