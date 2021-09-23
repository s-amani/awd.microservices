using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuereyHandler : IRequestHandler<GetOrdersListQuery, List<OrderViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repository;

        public GetOrdersListQuereyHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OrderViewModel>> Handle(GetOrdersListQuery request, 
            CancellationToken cancellationToken)
        {
            return _mapper.Map<List<OrderViewModel>>(await _repository.GetOrdersByUserName(request.UserName));
        }
    }
}
