using InciCreator.DbContexts;
using InciCreator.Exceptions;
using InciCreator.Models.DataTransferObjects;
using InciCreator.Models.Entities;

namespace InciCreator.Services.Implementations;

public class ApplicationService(ApplicationDbContext dbContext) : IApplicationService
{
    public async Task CreateRecords(CreationRequest creationRequest)
    {
        Account account = await dbContext.FindAccountByName(creationRequest.AccountName) ??
                          throw new AccountNotFoundException();

        Contact contact = await dbContext.FindContactByEmail(creationRequest.ContactEmail);

        if (contact != null)
        {
            contact.FirstName = creationRequest.ContactFirstName;
            contact.LastName = creationRequest.ContactLastName;

            if (!dbContext.UpdateContact(contact))
                throw new("Failed to update contact.");
        }
        else
        {
            dbContext.CreateContact(new()
            {
                FirstName = creationRequest.ContactFirstName,
                LastName = creationRequest.ContactLastName,
                Email = creationRequest.ContactEmail
            });
        }

        account.Contact = contact;

        if (!dbContext.UpdateAccount(account))
            throw new("Failed to update account.");

        dbContext.CreateIncident(new() { Account = account, Description = creationRequest.IncidentDescription });

        await dbContext.SaveChangesAsync();
    }
}
