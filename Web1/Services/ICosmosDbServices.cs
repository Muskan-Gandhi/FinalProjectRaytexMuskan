using Web1.Models;

namespace Web1.Services
{
    public interface ICosmosDbServices
    {
        Task<IEnumerable<EDI>> GetMultipleAsync(string queryString);
        Task<EDI> GetAsync(string id);

    }
}
