using System.ComponentModel.DataAnnotations;

namespace Micro_Commerce_Cuopons.Models.DTOs
{
    public class CouponRequestDTO
    {
        [Required]
        public string CouponCode { get; set; } = string.Empty;

        [Required]
        public int CouponAmount { get; set; }

        [Required]
        public int CouponMinAmont { get; set; }
    }
}
