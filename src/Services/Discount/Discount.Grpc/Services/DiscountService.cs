using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repository;
        private readonly ILogger<DiscountService> _logger;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository repository, ILogger<DiscountService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public override async Task<CopounModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var model = await _repository.GetDiscount(request.ProductName);

            if (model == null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount not found for {request.ProductName}"));

            var result = _mapper.Map<CopounModel>(model);

            return result;
        }

        public override async Task<CopounModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var model = _mapper.Map<Coupon>(request);
            var result = await _repository.CreateDiscount(model);

            if (!result)
                throw new RpcException(new Status(StatusCode.Internal, "An error occoured."));

            var result1 = _mapper.Map<CopounModel>(result);

            return result1;
        }

        public override async Task<CopounModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var model = _mapper.Map<Coupon>(request);
            var result = await _repository.UpdateDiscount(model);

            if (!result)
                throw new RpcException(new Status(StatusCode.Internal, "An error occoured."));

            var result1 = _mapper.Map<CopounModel>(result);

            return result1;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var result = await _repository.DeleteDiscount(request.ProductName);
            return new DeleteDiscountResponse { Success = result };
        }
    }
}
