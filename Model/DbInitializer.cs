using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using VendingMachineApp.Helpers.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace VendingMachineApp.Model
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                AppDbContext context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                #region Products (Commented)

                //if(!context.Products.Any())
                //{
                //    context.AddRange
                //        (
                //            new Product() { ProductId = 1, Type = ProductTypeEnum.Tea, Name = "Tea", ImageUrl = "../../assets/images/tea.jpg" },
                //            new Product() { ProductId = 2, Type = ProductTypeEnum.Espresso, Name = "Espresso", ImageUrl = "../../assets/images/espresso.jpg" },
                //            new Product() { ProductId = 3, Type = ProductTypeEnum.Juice, Name = "Juice", ImageUrl = "../../assets/images/juice.png" },
                //            new Product() { ProductId = 4, Type = ProductTypeEnum.ChickenSoup, Name = "Chicken Soup", ImageUrl = "../../assets/images/chicken-soup.jpg" }
                //        );
                //}

                #endregion

                if (!context.ProductLines.Any())
                {
                    context.AddRange
                        (
                            new ProductLine()
                            {
                                Amount = 10,
                                Product = new Product() { Type = ProductTypeEnum.Tea, Name = "Tea", ImageUrl = "../../assets/images/tea.jpg", Price = 1.30 }
                            },
                            new ProductLine()
                            {
                                Amount = 20,
                                Product = new Product() { Type = ProductTypeEnum.Espresso, Name = "Espresso", ImageUrl = "../../assets/images/espresso.jpg", Price = 1.80 },
                            },
                             new ProductLine()
                             {
                                 Amount = 20,
                                 Product = new Product() { Type = ProductTypeEnum.Juice, Name = "Juice", ImageUrl = "../../assets/images/juice.png", Price = 1.80 },
                             },
                             new ProductLine()
                             {
                                 Amount = 15,
                                 Product = new Product() { Type = ProductTypeEnum.ChickenSoup, Name = "Chicken Soup", ImageUrl = "../../assets/images/chicken-soup.jpg", Price = 1.80 },
                             }
                        );
                }

                context.SaveChanges();
            }
        }
    }
}
