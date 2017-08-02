using DataLayer.Entities.Context.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Context.Respository
{
    public class ShopWebRepository<TContext> : IShopWeb,IDisposable where TContext : DbContext,new()
    {
        public TContext Context { get; set; }

        public ShopWebRepository()
        {
           Context = new TContext();
        }

        public T Add<T>(T data,bool save) where T : class, new()
        {
            Context.Entry(data).State = EntityState.Added;
            if (save)
                Save();
            return data;
        }

        public T Delete<T>(T data, bool save) where T : class, new()
        {
            Context.Entry(data).State = EntityState.Deleted;
            if (save)
                Save();
            return data;
        }
      
        public int Save()
        {
            return Context.SaveChanges();
        }

        public T Update<T>(T data, bool save) where T : class, new()
        {
            Context.Entry(data).State = EntityState.Modified;
            if (save)
                Save();
            return data;
        }

        public void Dispose()
        {
            Context.Dispose();
        }


    }
}
