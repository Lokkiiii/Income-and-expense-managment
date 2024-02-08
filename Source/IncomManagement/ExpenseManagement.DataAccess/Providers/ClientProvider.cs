using ExpenseManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.DataAccess.Providers
{
    public class ClientProvider
    {
        public List<Client> ListUsers()
        {
            using (var dbContext=new ExpenseManagementContext())
            {
                return dbContext.Clients.ToList();
            }
        }
        public bool InsertUser(Client client)
        {
            try
            {
                using (var dbContext = new ExpenseManagementContext())
                {
                   
                    dbContext.Clients.Add(client);
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

        public int LoginUser(string email, string password)
        {
            try
            {
                using (var dbContext = new ExpenseManagementContext())
                {
                    int userid = (from l in dbContext.Clients
                                where l.UserEmail == email && l.UserPassword == password
                                select l.UserId).FirstOrDefault();
                    return userid;
                }
            }
            catch
            {
                throw;
            }
        }


        public bool UpdateUser(int userid, string username, string useremail, string password)
        {
            try
            {
                using (var dbContext = new ExpenseManagementContext())
                {
                    var user = (from b in dbContext.Clients where b.UserId == userid select b).FirstOrDefault();
                              

                    user.UserName = username;
                    user.UserPassword=password;
                    user.UserEmail = useremail;
                    dbContext.Clients.Update(user);
                    dbContext.SaveChanges();



                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteUser(string username)
        {
            try
            {
                using (var dbContext = new ExpenseManagementContext())
                {
                    var user = (from b in dbContext.Clients where b.UserName == username select b).FirstOrDefault();
                              

                    dbContext.Clients.Remove(user);
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
