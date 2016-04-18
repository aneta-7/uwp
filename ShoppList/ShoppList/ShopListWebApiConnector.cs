using ShoppList.Interfaces;
using ShoppList.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppList
{
   public class ShopListWebApiConnector : IWebApiConnector
    {
        public T GetRepository<T>() where T : IRepository
        {
            if (typeof(T) == typeof(ICreateRepository))
                return (T)Activator.CreateInstance(typeof(CreateRepository));
            else if (typeof(T) == typeof(IHistoryRepository))
                return (T)Activator.CreateInstance(typeof(HistoryRepository));
            else if (typeof(T) == typeof(ISettingsRepository))
                return (T)Activator.CreateInstance(typeof(SettingsRepository));
            else
                throw new NotSupportedException();
        }
    }
}
