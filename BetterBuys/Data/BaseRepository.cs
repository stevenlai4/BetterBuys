using BetterBuys.Interfaces;
using BetterBuys.Models;
using BetterBuys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly StoreDbContext _db;

        public BaseRepository(StoreDbContext db)
        {
            _db = db;
        }

        //limiting traffic to the database
        public IQueryable<T> GetAll()
        { 
            return _db.Set<T>();
        }

        public ProductVM GetOne(int id)
        {
            return _db.Set<ProductVM>().Where(t => t.Id == id).FirstOrDefault();
        }
    }
}