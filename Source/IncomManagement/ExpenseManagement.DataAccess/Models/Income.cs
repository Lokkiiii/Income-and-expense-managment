using System;
using System.Collections.Generic;

namespace ExpenseManagement.DataAccess.Models
{
    public partial class Income
    {
        public int IncomeId { get; set; }
        public string IncomeName { get; set; } = null!;
        public decimal IncomeAmount { get; set; }
        public DateTime IncomeDate { get; set; }
        public int UserId { get; set; }

        public virtual Client User { get; set; } = null!;
    }
}
