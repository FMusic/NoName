using DataLayer.DAO;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataServices
{
    public class GenericDataService : DataService
    {
        // SELECT
        public async Task<List<T>> GetAllAsync<T>(NoNameDbContext dbContext = null) where T : class
        {
            var db = CreateDbContext(dbContext);
            try
            {
                return await db.Set<T>().ToListAsync();
            }
            finally
            {
                if (dbContext == null)
                {
                    db.Dispose();
                }
            }
        }

        public async Task<T> GetByIdAsync<T>(int id, NoNameDbContext dbContext = null) where T : class
        {
            var db = CreateDbContext(dbContext);
            try
            {
                return await db.Set<T>().FindAsync(id);
            }
            finally
            {
                if (dbContext == null)
                {
                    db.Dispose();
                }
            }
        }

        public async Task AddAsync<T>(T item, NoNameDbContext dbContext = null) where T : class
        {
            var db = CreateDbContext(dbContext);
            try
            {
                db.Set<T>().Add(item);
                await db.SaveChangesAsync();
            }
            finally
            {
                if (dbContext == null)
                {
                    db.Dispose();
                }
            }
        }

        public async Task AddRangeAsync<T>(List<T> items, NoNameDbContext dbContext = null) where T : class
        {
            var db = CreateDbContext(dbContext);
            try
            {
                db.Set<T>().AddRange(items);
                await db.SaveChangesAsync();
            }
            finally
            {
                if (dbContext == null)
                {
                    db.Dispose();
                }
            }
        }

        // UPDATE
        public async Task UpdateAsync<T>(T item, NoNameDbContext dbContext = null) where T : class
        {
            var db = CreateDbContext(dbContext);
            try
            {
                db.Set<T>().Attach(item);
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            finally
            {
                if (dbContext == null)
                {
                    db.Dispose();
                }
            }
        }

        public async Task UpdateRangeAsync<T>(List<T> items, NoNameDbContext dbContext = null) where T : class
        {
            var db = CreateDbContext(dbContext);
            try
            {
                foreach (var item in items)
                {
                    db.Set<T>().Attach(item);
                    db.Entry(item).State = EntityState.Modified;
                }
                await db.SaveChangesAsync();
            }
            finally
            {
                if (dbContext == null)
                {
                    db.Dispose();
                }
            }
        }

        public async Task DeleteAsync<T>(T item, NoNameDbContext dbContext = null) where T : class
        {
            var db = CreateDbContext(dbContext);
            try
            {
                db.Set<T>().Attach(item);
                db.Entry(item).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }
            finally
            {
                if (dbContext == null)
                {
                    db.Dispose();
                }
            }
        }

        public async Task DeleteRangeAsync<T>(List<T> items, NoNameDbContext dbContext = null) where T : class
        {
            var db = CreateDbContext(dbContext);
            try
            {
                foreach (var item in items)
                {
                    db.Set<T>().Attach(item);
                    db.Entry(item).State = EntityState.Deleted;
                }

                await db.SaveChangesAsync();
            }
            finally
            {
                if (dbContext == null)
                {
                    db.Dispose();
                }
            }
        }
    }
}
