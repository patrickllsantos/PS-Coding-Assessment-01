using CodingAssessment.Database;
using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodingAssessment.Features.Pizzas.GetPizzas;

/// <summary>
/// Handler for the <see cref="GetPizzasQuery"/>.
/// </summary>
public static class GetPizzasQueryHandler
{
    internal sealed class Handler : IRequestHandler<GetPizzasQuery, GetPizzasResponse>
    {
        private readonly DatabaseContext _context;

        public Handler(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<GetPizzasResponse> Handle(GetPizzasQuery request, CancellationToken cancellationToken)
        {
            var req = request.Request;
            var skip = req.PaginationParams.PageSize * (req.PaginationParams.PageNumber - 1);
            var take = req.PaginationParams.PageSize;

            var pizzas = await _context.Pizzas
                .Select(x => new PizzaResponse
                {
                    Id = x.Id,
                    PizzaType = x.PizzaType.Name,
                    Size = x.Size.ToString(),
                    Price = x.Price
                })
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);
            
            var totalCount = await _context.Pizzas.CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling(totalCount / (double)req.PaginationParams.PageSize);
            var paginationMetadata = new Pagination(req.PaginationParams.PageNumber, totalPages,
                req.PaginationParams.PageSize, totalCount);

            var response = new GetPizzasResponse(pizzas, paginationMetadata);

            return response;
        }
    }
}