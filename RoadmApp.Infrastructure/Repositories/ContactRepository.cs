using Microsoft.EntityFrameworkCore;
using RoadmApp.Domain.BusinessModel;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Factories;
using RoadmApp.Domain.IRepositories;
using RoadmApp.Infrastructure.Data;

namespace RoadmApp.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Contact?> GetByEmailAsync(string email)
        {
            try
            {
                ContactEntity contactt = await _context.Contacts.FirstOrDefaultAsync(u => u.Email == email);
                return contactt != null ? ModelFactory.CreateContactModel(contactt) : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<List<Contact>> AddRangeAsync(IEnumerable<ContactEntity> contacts)
        {
            try
            {
                await _context.Contacts.AddRangeAsync(contacts);
                await _context.SaveChangesAsync();
                return ModelFactory.CreateContactListModel(contacts.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public async Task<Contact> AddAsync(ContactEntity contact)
        {
            try
            {
                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();
                return ModelFactory.CreateContactModel(contact);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<Contact> GetContactbyUserId(int userId)
        {
            try
            {
                var contacts = _context.Contacts.Where(c => c.UserId == userId).ToList();
                return ModelFactory.CreateContactListModel(contacts);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}