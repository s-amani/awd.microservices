using Discount.Grpc.Protos;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baseket.API.GrpcServices
{
    public class DiscountGrpsService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _service;

        public DiscountGrpsService(DiscountProtoService.DiscountProtoServiceClient service)
        {
            _service = service;
        }

        public async Task<CopounModel> GetDiscount(string productName)
        {
            var request = new GetDiscountRequest { ProductName = productName };
            return await _service.GetDiscountAsync(request);
        }
    }
}
