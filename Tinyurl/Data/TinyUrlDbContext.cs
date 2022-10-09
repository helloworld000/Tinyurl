using Microsoft.EntityFrameworkCore;


namespace SystemDesign.TinyUrl
{
    public class TinyUrlDbContext:DbContext
    {
        public DbSet<UrlMaster> UrlMaster { get; set; }
        public TinyUrlDbContext() { }
        public TinyUrlDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=Data\\tu.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UrlMaster>().HasData(
            //    new UrlMaster { Id = 12345, ShortUrl = "test", LongUrl = "TEST" });

        }
    }
}
