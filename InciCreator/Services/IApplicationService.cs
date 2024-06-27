using InciCreator.Models.DataTransferObjects;

namespace InciCreator.Services;

public interface IApplicationService
{
    public Task CreateRecords(CreationRequest creationRequest);
}
