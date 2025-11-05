using FrogManagement.Data.Models;

namespace FrogManagement.Data.Repositories
{
    public interface IFrogRepository
    {
        Task<List<Frog>> Get();
        Task<Frog> Get(Guid id);
        Task<bool> Add(FrogDTO frogDTO);
        Task<bool> Update(Guid id, FrogDTO frogDTO);
        Task<bool> Delete(Guid id);
    }
}
