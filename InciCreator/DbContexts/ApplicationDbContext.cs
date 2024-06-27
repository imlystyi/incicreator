using InciCreator.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InciCreator.DbContexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Contact> Contacts { get; set; }

    public DbSet<Account> Accounts { get; set; }

    public DbSet<Incident> Incidents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Incident>()
                    .HasOne(i => i.Account)
                    .WithMany(a => a.Incidents)
                    .HasForeignKey(i => i.AccountId);

        modelBuilder.Entity<Account>()
                    .HasOne(a => a.Contact)
                    .WithMany(c => c.Accounts)
                    .HasForeignKey(a => a.ContactId);
    }
}
