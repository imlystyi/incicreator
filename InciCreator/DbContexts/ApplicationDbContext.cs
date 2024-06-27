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

    #nullable enable

    public async Task<Contact?> FindContactByEmail(string email) => await this.Contacts.FirstOrDefaultAsync(c => c.Email == email);

    public async Task<Account?> FindAccountByName(string name) => await this.Accounts.FirstOrDefaultAsync(a => a.Name == name);

    public bool UpdateContact(Contact contact) => this.Contacts.Update(contact).State == EntityState.Modified;

    public bool UpdateAccount(Account account) => this.Accounts.Update(account).State == EntityState.Modified;

    public void CreateContact(Contact contact) => this.Contacts.Add(contact);

    public void CreateIncident(Incident incident) => this.Incidents.Add(incident);

}
