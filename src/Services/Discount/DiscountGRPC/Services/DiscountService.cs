using DiscountGRPC.Data;
using DiscountGRPC.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DiscountGRPC.Services
{
    public class DiscountService(DiscountContext dbContext) : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();

            if (coupon == null) {
                throw new RpcException(new Status(StatusCode.InvalidArgument,"Inavlid request"));
            }

            dbContext.Coupons.Add(coupon);

            await dbContext.SaveChangesAsync();

            var response = coupon.Adapt<CouponModel>();
            return response;
           
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if (coupon == null) {
                throw new RpcException(new Status(StatusCode.NotFound, "Inavlid request"));
            }
            dbContext.Remove(coupon);
            await dbContext.SaveChangesAsync();
            return new DeleteDiscountResponse() { Success = true };
        }
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon =  await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
            if (coupon == null) {
                coupon = new Models.Coupon() { ProductName = "No Discount" , Amount = 0, Description = "No Discount" };
            }
            var response = coupon.Adapt<CouponModel>();


            return coupon.Adapt<CouponModel>(); ;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();

            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Inavlid request"));
            }

            dbContext.Coupons.Update(coupon);

            await dbContext.SaveChangesAsync();

            var response = coupon.Adapt<CouponModel>();
            return response;
        }
    }
}
