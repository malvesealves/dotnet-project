using MediatR;

namespace Restaurants.Application.Commands.Customer.Create
{
    public record CreateCustomerCommand(string Name) : IRequest<int>;
}
