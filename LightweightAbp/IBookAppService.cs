using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightweightAbp
{
    public interface IBookAppService
    {
        Task<string> CreateAsync(string name);

        Task<string[]> GetAllAsync();
    }
}
