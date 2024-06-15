using Api.Application.Bases;
using Api.Application.Interfaces.AutoMappers;
using Api.Application.Interfaces.UnitOfWorks;
using Api.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandQueryHandler : BaseHandler,IRequestHandler<GetAllBrandQueryRequest,IList<GetAllBrandQueryResponse>>
    {
        public GetAllBrandQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor) : base(mapper, unitOfWork, contextAccessor)
        {
        }

        public async Task<IList<GetAllBrandQueryResponse>> Handle(GetAllBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await _unitOfWork.GetReadRepository<Brand>().GetAllAsync();

            return _mapper.Map<GetAllBrandQueryResponse,Brand>(brands);
        }
    }
}
