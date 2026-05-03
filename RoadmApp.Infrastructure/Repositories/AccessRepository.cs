using RoadmApp.Domain.BusinessModel;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Factories;
using RoadmApp.Domain.IRepositories;
using RoadmApp.Infrastructure.Data;

namespace RoadmApp.Infrastructure.Repositories
{
    public class AccessRepository : IAccessRepository
    {
        private readonly AppDbContext _context;

        public AccessRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Success> FirstAccess(AccessEntity accessEntity)
        {
            try
            {
                throw new NotImplementedException();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Access> AddAsync(AccessEntity accessEntity)
        {
            try
            {
                await _context.Accesses.AddAsync(accessEntity);
                await _context.SaveChangesAsync();
                return ModelFactory.CreateAccessBusiness(accessEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}