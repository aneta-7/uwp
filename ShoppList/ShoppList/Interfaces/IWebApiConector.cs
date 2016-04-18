using ShoppList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppList.Interfaces
{
    public interface IWebApiConnector
    {
        T GetRepository<T>() where T : IRepository;
    }
}
