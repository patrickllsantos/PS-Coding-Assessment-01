using CodingAssessment.Database;
using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodingAssessment.Features.PizzaTypes.GetAll;

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

            var pizzaTypes = await _context.PizzaTypes
                .AsNoTracking()
                .Select(x => new PizzaTypeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category.Name,
                    Ingredients = x.Ingredients
                })
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);
            
            var totalCount = await _context.PizzaTypes.CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling(totalCount / (double)req.PaginationParams.PageSize);
            var paginationMetadata = new Pagination(req.PaginationParams.PageNumber, totalPages,
                req.PaginationParams.PageSize, totalCount);

            var response = new GetAllResponse(pizzaTypes, paginationMetadata);

            return response;
        }
    }
}
