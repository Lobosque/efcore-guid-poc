
using System.Collections.Generic;

namespace GuidPoc.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public virtual ICollection<Coupon> Coupons { get; set; }
        
    }
}