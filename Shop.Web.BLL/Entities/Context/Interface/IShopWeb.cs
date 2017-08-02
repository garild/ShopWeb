using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Context.Interface
{
    public interface IShopWeb
    {
        T Add<T>(T data, bool save) where T : class, new();
        T Update<T>(T data, bool save) where T : class, new();
        T Delete<T>(T data, bool save) where T : class, new();
        int Save();
    }
}
