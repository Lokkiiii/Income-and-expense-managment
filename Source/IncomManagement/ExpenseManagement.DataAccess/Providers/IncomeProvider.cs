using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.DataAccess.Models;


namespace ExpenseManagement.DataAccess.Providers
{
    public class IncomeProvider
    {
        public List<Income> ListIncomes(int userId , string incomenamefilter="")
        {
            using (var dbContext = new ExpenseManagementContext())
            {
                return dbContext.Incomes.Where(x => x.UserId == userId && (incomenamefilter=="" || x.IncomeName.Contains(incomenamefilter))).ToList();
            }
        }
        public bool InsertIncomes(Income income)
        {
            try
            {
                using (var dbContext = new ExpenseManagementContext())
                {
                   
                    dbContext.Incomes.Add(income);
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


        public bool UpdateIncomes(int userid, int incomeamount, string incomename, DateTime incomedate, int incomeid)
        {
            try
            {
                using (var dbContext = new ExpenseManagementContext())
                {
                    var income = (from b in dbContext.Incomes where b.UserId == userid select b).FirstOrDefault();

                    income.IncomeId = incomeid;
                    income.IncomeDate=incomedate;
                    income.IncomeName=incomename;
                    income.IncomeAmount=incomeamount;
                    income.UserId=incomeid;
                    dbContext.SaveChanges();



                }
                return true;
            }
            catch
            {
                throw;
            }
        }

      

        public bool DeleteIncomes(string incomename)
        {
            try
            {
                using (var dbContext = new ExpenseManagementContext())
                {
                    var income = (from b in dbContext.Incomes where b.IncomeName == incomename select b).FirstOrDefault();



                    dbContext.Incomes.Remove(income);
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
