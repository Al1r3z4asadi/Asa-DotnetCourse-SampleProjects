using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.BaseInfo.DTOs
{
    public class ExpenseDTO
    {
        public int id {get ; set ;}
        public string title { get; set; }
        public int category_id { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public decimal cost {get; set ;}

    }
}
