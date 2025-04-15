using Microsoft.EntityFrameworkCore;

namespace SqlChat.Data;

public class AppDbContext : DbContext
{

    public DbSet<Channel> Channels { get; set; }
    public DbSet<Message> Messages { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=chat.db"); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<Message>()
            .HasOne(m => m.Channel)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ChannelId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}