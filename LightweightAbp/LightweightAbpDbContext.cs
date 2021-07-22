using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace LightweightAbp
{
    [ConnectionStringName("Default")]
    public class LightweightAbpDbContext : AbpDbContext<LightweightAbpDbContext>
    {
        public LightweightAbpDbContext(DbContextOptions<LightweightAbpDbContext> options)
            : base(options)
        { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>(b =>
            {
                b.ToTable(nameof(Books));
            });
        }
    }
}
