using MediatR;

namespace Restaurants.Application.Commands.Dish.Create
{
    public record CreateDishCommand(string Name, string Description) : IRequest<int>;
}
