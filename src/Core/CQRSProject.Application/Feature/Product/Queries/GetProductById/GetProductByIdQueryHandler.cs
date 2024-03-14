using AutoMapper;
using CQRSProject.Application.Feature.Product.Queries.GetProductById;
using CQRSProject.Application.Wrappers;
using MediatR;
using UnitOfWorkPattern.Application.Interfaces.UnitOfWork;

namespace CQRSProject.Application.Feature.Product.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ApiResponse<GetProductByIdQueryResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public GetProductByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    public async Task<ApiResponse<GetProductByIdQueryResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _uow.Products.GetByIdAsync(request.Id);

        var resulViewModelList = _mapper.Map<GetProductByIdQueryResponse>(result);

        return new ApiResponse<GetProductByIdQueryResponse>(resulViewModelList);
    }
}
