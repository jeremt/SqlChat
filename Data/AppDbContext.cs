using Microsoft.EntityFrameworkCore;

namespace SqlChat.Data;

public class AppDbContext : DbContext
{

    public DbSet<Channel> Channels { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=chat.db"); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}