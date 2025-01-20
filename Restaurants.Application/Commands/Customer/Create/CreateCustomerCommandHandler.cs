using MediatR;

namespace Restaurants.Application.Commands.Customer.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        //private readonly IRepository<Domain.Entities.Customer> _repository;

        //public CreateCustomerCommandHandler(IRepository<Domain.Entities.Customer> repository)
        //{
        //    _repository = repository;
        //}

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Customer newCustomer = new()
            {
                Name = request.Name
            };

            //var createdItem = await _repository.AddAsync(newCustomer, cancellationToken);

            //return createdItem.Id;

            return newCustomer.Id;
        }
    }
}
