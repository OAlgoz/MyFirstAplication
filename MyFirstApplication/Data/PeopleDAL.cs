using Microsoft.EntityFrameworkCore;
using MyFirstApplication.Model;

namespace MyFirstApplication.Data
{
    public class PeopleDAL : IPeopleDAL
    {
        private readonly MyFirstApplicationContext _context;

        public PeopleDAL(MyFirstApplicationContext context)
        {
            _context = context;
        }

        public async Task Create(People entity)
        {
            try
            {
                _context.People.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            People people = await Get(id);

            try
            {
                _context.People.Remove(people);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<People> Get(int id)
        {
            People people = await _context.People.FindAsync(id)
                ?? throw new KeyNotFoundException("Not found people.");

            return people;
        }

        public async Task<IEnumerable<People>> GetAll()
        {
            IEnumerable<People> people = await _context.People
                .ToListAsync();

            return people;
        }

        public async Task Update(People entity)
        {
            await Get(entity.Id);
            try
            {
                _context.People.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
