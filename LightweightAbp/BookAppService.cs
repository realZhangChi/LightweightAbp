using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Repositories;

namespace LightweightAbp
{
    public class BookAppService : ApplicationService, IBookAppService
    {
        private readonly IRepository<Book, Guid> _repository;
        private readonly IDistributedCache<string[]> _cache;

        public BookAppService(
            IRepository<Book, Guid> repository,
            IDistributedCache<string[]> cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<string> CreateAsync(string name)
        {
            var book = await _repository.InsertAsync(new Book()
            {
                Name = name
            });

            return book.Name;
        }

        public async Task<string[]> GetAllAsync()
        {
            return await _cache.GetOrAddAsync(
                "AllBooksName",
                async () => await _repository.Select(b => b.Name).ToArrayAsync(),
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
                }
            );
        }
    }
}
