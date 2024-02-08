using System;
using System.Collections.Generic;

namespace ExpenseManagement.DataAccess.Models
{
    public partial class Expense
    {
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; } = null!;
        public DateTime ExpenseDate { get; set; }
        public decimal ExpenseAmount { get; set; }
        public int UserId { get; set; }

        public virtual Client User { get; set; } = null!;
    }
}
