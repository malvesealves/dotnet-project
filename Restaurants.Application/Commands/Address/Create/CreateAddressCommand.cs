using MediatR;

namespace Restaurants.Application.Commands.Address.Create
{
    public record CreateAddressCommand(string Street, string City) : IRequest<int>;
}
