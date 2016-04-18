using ShoppList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppList.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace ShoppList.Repositories
{
    class CreateRepository : ICreateRepository
    {
        private const string HOST = "uzupelnic pozniej";
        private HttpClient _client;

        public async Task<Shop> createNew()
        {
            //poprawic pozniej format
            string uri = String.Format("{0}/api/create", HOST);
            string result = await _client.GetStringAsync(new Uri(uri));
            return JsonConvert.DeserializeObject<Shop>(result);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
