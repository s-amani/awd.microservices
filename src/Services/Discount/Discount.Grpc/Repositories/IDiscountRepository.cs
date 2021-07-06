using Discount.Grpc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string productName);
        
        Task<bool> CreateDiscount(Coupon model);
        
        Task<bool> UpdateDiscount(Coupon model);
        
        Task<bool> DeleteDiscount(string productName);
    }
}
