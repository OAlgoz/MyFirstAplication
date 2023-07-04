using MyFirstApplication.Model;

namespace MyFirstApplication.Data
{
    public interface IPeopleDAL
    {
        Task Create(People entity);
        Task Delete(int id);
        Task<People> Get(int id);
        Task<IEnumerable<People>> GetAll();
        Task Update(People entity);
    }
}
