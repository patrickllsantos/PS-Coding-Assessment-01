using CodingAssessment.Database;
using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodingAssessment.Features.Pizzas.GetAll;

public static class GetAllQueryHandler
{
    internal sealed class Handler : IRequestHandler<GetAllQuery, GetAllResponse>
    {
        private readonly DatabaseContext _context;

        public Handler(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<GetAllResponse> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var req = request.Request;
            var skip = req.PaginationParams.PageSize * (req.PaginationParams.PageNumber - 1);
            var take = req.PaginationParams.PageSize;

            var pizzas = await _context.Pizzas
                .Select(x => new PizzaDto
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

            var response = new GetAllResponse(pizzas, paginationMetadata);

            return response;
        }
    }
}