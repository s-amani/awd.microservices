using MediatR;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System.Collections.Generic;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<List<OrderViewModel>>
    {
        public GetOrdersListQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
}
