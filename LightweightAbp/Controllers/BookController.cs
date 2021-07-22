using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace LightweightAbp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : AbpController
    {
        private readonly IBookAppService _service;

        public BookController(IBookAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<string> CreateAsync(string name)
        {
            return _service.CreateAsync(name);
        }

        [HttpGet("all")]
        public Task<string[]> GetAllAsync()
        {
            return _service.GetAllAsync();
        }
    }
}
