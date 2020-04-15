using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuidPoc.Data;
using GuidPoc.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuidPoc
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            using (var context = new DataContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Add(new Customer
                {
                    Id = 1
                });

                var promotion = new Promotion
                {
                    PromotionCode = "GANHE10REAIS",
                };

                context.Add(promotion);

                await context.SaveChangesAsync();
                await CreateCouponsAsync(context, promotion.PromotionId);
            }

            using (var context = new DataContext())
            {
                var customer = context.Customers.First();
            }
        }

        static async Task CreateCouponsAsync(DataContext dataContext, Guid promotionId)
        {

            Promotion promotion = await dataContext.Promotions.FirstAsync(x => x.PromotionId == promotionId);
            IList<Customer> customers = await dataContext.Customers.ToListAsync();
            var newCoupon = new Coupon();
            //newCoupon.PromotionId = promotionId;
            newCoupon.CustomerId = 1;
            promotion.Coupons.Add(newCoupon);
            /*
            foreach (Customer customer in customers)
            {
                promotion.CreateCoupon(customer);
            }
            */

            await dataContext.SaveChangesAsync();

            var allCoupons = await dataContext.Coupons.ToListAsync();
            foreach(Coupon coupon in allCoupons)
                Console.WriteLine(coupon);
        }
    }
}