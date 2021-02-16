using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.BaseInfo.DTOs
{
    public class ExpenseDTO
    {
        public int id {get ; set ;}
        public string title { get; set; }
        public CalculationFormula formula { get; set; }
    }
}
