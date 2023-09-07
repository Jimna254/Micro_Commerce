using System.ComponentModel.DataAnnotations;

namespace Micro_Commerce_Cuopons.Models
{
    public class Coupon
    {
        [Key]
        public Guid CouponId { get; set; }

        public string CouponCode { get; set; } = string.Empty;

        public int CouponAmount { get; set; }

        public int CouponMinAmont { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
