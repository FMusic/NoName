using DataLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class DataService
    {
        private static NoNameDbContext _db { get; set; }

        public DataService()
        {
            if (_db == null)
            {
                try
                {
                    using (_db = new NoNameDbContext())
                    {
                        _db.Database.CreateIfNotExists();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Message: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);

                    throw ex;
                }
            }
        }

        public static NoNameDbContext CreateDbContext(NoNameDbContext dbContext = null)
        {
            if (dbContext != null)
            {
                return dbContext;
            }

            var typex = typeof(NoNameDbContext).AssemblyQualifiedName;
            return Activator.CreateInstance(Type.GetType(typex)) as NoNameDbContext;
        }
    }
}
