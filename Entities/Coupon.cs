using System;

namespace GuidPoc.Entities {
    public class Coupon
    {
        public string CouponId { get; private set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public Coupon()
        {
            CouponId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"Coupon {CouponId}";
        }
    }
}
