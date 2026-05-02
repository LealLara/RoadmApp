using RoadmApp.Domain.BusinessModel;
using RoadmApp.Domain.Entities;

namespace RoadmApp.Domain.IRepositories
{
    public interface IContactRepository
    {
        Task<Contact> AddAsync(ContactEntity contact);
        Task<List<Contact>> AddRangeAsync(IEnumerable<ContactEntity> contacts);
        List<Contact> GetContactbyUserId(int userId);
        Task<Contact?> GetByEmailAsync(string email);
    }
}