using AddressService.Domain.Entities;
using AddressService.Domain.Interfaces.Repositories;
using Raven.Client.Documents;

namespace AddressService.Infrastructure.Repositories
{
    public class PersonAddressRepository : IPersonAddressRepository
    {
        private readonly IDocumentStore _store;

        public PersonAddressRepository(IDocumentStore store)
        {
            _store = store;
        }

        public async Task<PersonAddress> GetByIdAsync(string id)
        {
            using (var session = _store.OpenAsyncSession())
            {
                return await session.LoadAsync<PersonAddress>(id);
            }
        }

        public async Task<IEnumerable<PersonAddress>> GetAllAsync()
        {
            using (var session = _store.OpenAsyncSession())
            {
                return await session.Query<PersonAddress>().ToListAsync();
            }
        }

        public async Task AddAsync(PersonAddress address)
        {
            using (var session = _store.OpenAsyncSession())
            {
                await session.StoreAsync(address);
                await session.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(PersonAddress address)
        {
            using (var session = _store.OpenAsyncSession())
            {
                await session.StoreAsync(address);
                await session.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(string id)
        {
            using (var session = _store.OpenAsyncSession())
            {
                var address = await session.LoadAsync<PersonAddress>(id);
                if (address != null)
                {
                    session.Delete(address);
                    await session.SaveChangesAsync();
                }
            }
        }
    }
}
