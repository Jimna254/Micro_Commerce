using Micro_Commerce_Cuopons.Data;
using Micro_Commerce_Cuopons.Models;
using Micro_Commerce_Cuopons.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Micro_Commerce_Cuopons.Services
{
    public class CouponService : ICouponInterface
    {
        //DI dbcontext
        private readonly AppDbContext _context;
        public CouponService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<string> AddCouponAsync(Coupon coupon)
        {
            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();
            return "Coupon Added Succesfully";
        }

        public async Task<string> DeleteCouponAsync(Coupon coupon)
        {
            _context.Coupons.Remove(coupon);
            await _context.SaveChangesAsync();
            return "Coupon Deleted Succesfully";
        }

        public async Task<Coupon> GetCouponByIdAsync(Guid id)
        {
            return await _context.Coupons.FirstOrDefaultAsync(c => c.CouponId == id);
        }

        public async Task<Coupon> GetCouponByNameAsync(string couponCode)
        {
            return await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);
        }

        public async Task<IEnumerable<Coupon>> GetCouponsAsync()
        {
            return await _context.Coupons.ToListAsync();
        }

        public async Task<string> UpdateCouponAsync(Coupon coupon)
        {
            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();
            return "Coupon Updated Succesfully";
        }
    }
}
