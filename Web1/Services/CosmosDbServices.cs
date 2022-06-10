using Microsoft.Azure.Cosmos;

using Web1.Models;

namespace Web1.Services
{
    
        public class CosmosDbServices : ICosmosDbServices
        {
            private Container _container;
            public CosmosDbServices(
                CosmosClient cosmosClient,
                string databaseName,
                string containerName)
            {
                _container = cosmosClient.GetContainer(databaseName, containerName);
            }

            public async Task<EDI> GetAsync(string id)
            {
                try
                {
                    var response = await _container.ReadItemAsync<EDI>(id, new PartitionKey(id));
                    return response.Resource;
                }
                catch (CosmosException)
                {
                    return null;
                }

            }
            public async Task<IEnumerable<EDI>> GetMultipleAsync(string queryString)
            {
                var query = _container.GetItemQueryIterator<EDI>(new QueryDefinition(queryString));
                var results = new List<EDI>();
                while (query.HasMoreResults)
                {
                    var respone = await query.ReadNextAsync();
                    results.AddRange(respone.ToList());
                }
                return results;
            }
        }
}
