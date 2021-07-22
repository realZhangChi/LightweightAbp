using System;
using Volo.Abp.Domain.Entities;

namespace LightweightAbp
{
    public class Book : Entity<Guid>
    {
        public string Name { get; set; }
    }
}
