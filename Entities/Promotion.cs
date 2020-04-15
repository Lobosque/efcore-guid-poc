using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GuidPoc.Entities
{
    public class Promotion
    {
        public Guid PromotionId { get; private set; }

        public string PromotionCode { get; set; }

        public virtual ICollection<Coupon> Coupons { get; set; }

        public Promotion()
        {
            PromotionId = Guid.NewGuid();
            Coupons = new Collection<Coupon>();
        }

        public Coupon CreateCoupon(Customer customer) {
            var coupon = new Coupon();
            coupon.Customer = customer;
            Coupons.Add(coupon);
            return coupon;
        }

    }
}