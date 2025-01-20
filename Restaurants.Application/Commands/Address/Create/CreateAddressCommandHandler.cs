using MediatR;

namespace Restaurants.Application.Commands.Address.Create
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        //private readonly IRepository<Domain.Entities.Address> _repository;

        //public CreateAddressCommandHandler(IRepository<Domain.Entities.Address> repository)
        //{
        //    _repository = repository;
        //}

        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Address newAddress = new()
            {
                Street = request.Street,
                City = request.City
            };

            //var createdItem = await _repository.AddAsync(newAddress, cancellationToken);

            //return createdItem.Id;

            return newAddress.Id;
        }
    }
}
