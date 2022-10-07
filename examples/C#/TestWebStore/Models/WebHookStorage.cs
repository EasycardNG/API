using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebStore.Models
{
    /// <summary>
    /// Sample storage from webhook data (just for demo purposes)
    /// </summary>
    public class WebHookStorage
    {
        private const string PartitionKey = "1";
        private readonly TableClient table;

        public WebHookStorage(string storageConnectionString, string tableName)
        {
            // TODO: run azure sotrage emulator or specify azure connection string before uncomment this
            //table = new TableClient(storageConnectionString, tableName);

            //table.CreateIfNotExists();
        }

        public async Task<IEnumerable<WebHookData>> GetData()
        {
            var segment = table.QueryAsync<WebHookData>("", 100);

            var e = segment.AsPages().GetAsyncEnumerator();

            if (await e.MoveNextAsync())
            {
                var res = e.Current;

                return res.Values;
            }

            return Enumerable.Empty<WebHookData>();
        }

        public async Task StoreData(WebHookData data)
        {
            await table.AddEntityAsync(data);
        }
    }
}
