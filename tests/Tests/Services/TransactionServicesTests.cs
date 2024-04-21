using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Moq;
using Services.Events.CreateUpdateReportEvent;
using Services.Services;
using Services.Services.Interfaces;
using Services.Services.Requests;

namespace Tests.Services;

public class TransactionServicesTests
{
    [Fact]
    public async Task CreateTest()
    {
        var request = new CreateTransactionRequest(410.20M, TransactionType.Credit);

        var mediator = new Mock<IMediator>();
        var repository = new Mock<ITransactionRepository>();

        repository.Setup(x => x.CommitAsync())
            .ReturnsAsync(true);

        var service = BuildServices(repository, mediator);

        var response = await service.Create(request);

        mediator.Verify(x => 
            x.Publish(It.IsAny<CreateUpdateReportEventRequest>(), It.IsAny<CancellationToken>()), Times.Once);

        Assert.NotNull(response);
        Assert.True(response.Success);
    }

    private ITransactionServices BuildServices(Mock<ITransactionRepository> transactionRepository = null, Mock<IMediator> mediator = null)
    {
        transactionRepository ??= new Mock<ITransactionRepository>();
        mediator ??= new Mock<IMediator>();

        return new TransactionServices(transactionRepository.Object, mediator.Object);
    }
}