using MediatR;

namespace Restaurants.Application.Commands.Dish.Create
{
    public class CreateDishCommandHandler : IRequestHandler<CreateDishCommand, int>
    {
        //private readonly IRepository<Domain.Entities.Dish> _repository;

        //public CreateDishCommandHandler(IRepository<Domain.Entities.Dish> repository)
        //{
        //    _repository = repository;
        //}

        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Dish newDish = new()
            {
                Name = request.Name,
                Description = request.Description
            };

            //var createdItem = await _repository.AddAsync(newDish, cancellationToken);

            //return createdItem.Id;

            return newDish.Id;
        }
    }
}
