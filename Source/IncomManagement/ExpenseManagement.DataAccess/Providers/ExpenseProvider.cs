using ExpenseManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.DataAccess.Providers
{
    public class ExpenseProvider
    {
        public List<Expense> ListExpenses(int userId, string expensenamefilter="")
        {
            using (var dbContext = new ExpenseManagementContext())
            {
                return dbContext.Expenses.Where(x => x.UserId == userId && (expensenamefilter=="" || x.ExpenseName.Contains(expensenamefilter))).ToList();
                
            }
        }
        public bool InsertExpenses(Expense expense)
        {
            try
            {
                using (var dbContext = new ExpenseManagementContext())
                {
                  
                    dbContext.Expenses.Add(expense);
                    dbContext.SaveChanges();




                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                throw;
            }

        }


        public bool UpdateExpenses(int userid, int expenseamount, string expensename, DateTime expensedate, int expenseid)
        {
            try
            {
                using (var dbContext = new ExpenseManagementContext())
                {
                    var expense = (from b in dbContext.Expenses where b.UserId == userid select b).FirstOrDefault();

                    expense.ExpenseName= expensename;
                    expense.ExpenseDate= expensedate;
                    expense.ExpenseAmount= expenseamount;
                    expense.ExpenseId= expenseid;
                    expense.UserId= userid;
                    dbContext.SaveChanges();



                }
                return true;
            }
            catch
            {
                throw;
            }
        }



        public bool DeleteExpenses(string expensename)
        {
            try
            {
                using (var dbContext = new ExpenseManagementContext())
                {
                    var expense = (from b in dbContext.Expenses where b.ExpenseName == expensename select b).FirstOrDefault();



                    dbContext.Expenses.Remove(expense);
                    dbContext.SaveChanges();



                }
                return true;
            }
            catch
            {
                throw;
            }
        }







    }
}
