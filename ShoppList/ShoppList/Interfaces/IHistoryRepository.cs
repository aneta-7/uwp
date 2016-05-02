using ShoppList.Models;
using ShoppList.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppList.Interfaces
{
    public interface IHistoryRepository : IRepository, IDisposable
    {
      //  Task<ShopViewModel> showHistory(string startDate, string endDate);
    }
}
