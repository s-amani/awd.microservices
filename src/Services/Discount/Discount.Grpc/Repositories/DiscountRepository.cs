using Dapper;
using Discount.Grpc.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var result = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName});

            return result ?? new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount" };
        }

        public async Task<bool> CreateDiscount(Coupon model)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected =
                await connection.ExecuteAsync
                    ("insert into coupon (productname, description, amount) values(@ProductName, @Description, @Amount)",
                        new { ProductName = model.ProductName, Description = model.Description, Amount = model.Amount});

            return affected > 0;
        }

        public async Task<bool> UpdateDiscount(Coupon model)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected =
                await connection.ExecuteAsync
                    ("update coupon set(productname = @ProductName, description = @Description, amount = @Amount) where id = @Id)",
                        new { ProductName = model.ProductName, Description = model.Description, Amount = model.Amount, Id = model.Id });

            return affected > 0;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected =
                await connection.ExecuteAsync
                    ("delete from coupon where productname = @productname)",
                        new { ProductName = productName});

            return affected > 0;
        }
    }
}
