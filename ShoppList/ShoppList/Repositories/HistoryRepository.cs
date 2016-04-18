using ShoppList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppList.Models;

namespace ShoppList.Repositories
{
    class HistoryRepository : IHistoryRepository

    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Shop> showHistory(string startDate, string endDate)
        {
            throw new NotImplementedException();
        }
    }
}
