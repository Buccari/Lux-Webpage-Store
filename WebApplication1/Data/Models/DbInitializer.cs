using WebApplication1.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using LuxWebpageStore.Data.Repositories;

namespace WebApplication1.Data.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context =
                applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!context.ProductSorters.Any())
            {
                context.ProductSorters.AddRange(ProductSorters.Select(c => c.Value));
            }
            if (!context.UsersData.Any())
            {
                context.AddRange
                (
                    new User
                    {
                        FirstName = "Endy",
                        LastName = "Prekpalaj",
                        Email = "endy.prekpalaj@hotmail.com",
                        Password = "test",
                        IsAdmin = true,
                        IsEmailVerified=true
                    },
                    new User
                    {
                        FirstName = "Josip",
                        LastName = "Rukavina",
                        Email = "jrukavina@hotmail.com",
                        Password = "testRuki",
                        IsAdmin = false,
                        IsEmailVerified = false
                    },
                    new User
                    {
                        FirstName = "Samuel",
                        LastName = "Kolgjeraj",
                        Email = "samuel.kolgjeraj123@gmail.com",
                        Password = "testSamke",
                        IsAdmin = false,
                        IsEmailVerified = false
                    }
                );
            }

            if (!context.Products.Any())
            {
                context.AddRange
                (
                    new Product
                    {
                        Name = "Pizza",
                        Price = 12,
                        Description = "Always freshly baked",
                        ProductSorter = ProductSorters["Bagels"],
                        ImageURL = "https://www.cicis.com/media/1138/pizza_trad_pepperoni.png",
                        InStock = true,
                        IsMostLiked = false
                    },
                    new Product
                    {
                        Name = "Burek",
                        Price = 15,
                        Description = "Full of meat... or cheese. Your choice.",
                        ProductSorter = ProductSorters["Bagels"],
                        ImageURL = "http://finedininglovers.cdn.crosscast-system.com/ImageAlbum/15522/original_burek-finedininglovers-greek.jpg",
                        InStock = true,
                        IsMostLiked = true
                    },
                    new Product
                    {
                        Name = "White bread",
                        Price = 9,
                        Description = "Freshly baked",
                        ProductSorter = ProductSorters["Breads"],
                        ImageURL = "https://fthmb.tqn.com/SKjfxljgeY0nBIglJsTCKXd-akk=/5120x3413/filters:fill(auto,1)/white-bread-467775351-58a6ffd23df78c345b657e2f.jpg",
                        InStock = true,
                        IsMostLiked = true
                    },
                    new Product
                    {
                        Name = "Integral bread",
                        Price = 10,
                        Description = "You love healthy? We are all for it.",
                        ProductSorter = ProductSorters["Breads"],
                        ImageURL = "https://www.nautilusplus.com/content/uploads/2013/04/Bread.jpg",
                        InStock = true,
                        IsMostLiked = false
                    },
                    new Product
                    {
                        Name = "Muffin",
                        Price = 8,
                        Description = "Sweeter than your next.",
                        ProductSorter = ProductSorters["Sweets"],
                        ImageURL = "http://www.jennycraig.com/statics/img/catalog/products/PI0202-048_fullwidth.jpg",
                        InStock = true,
                        IsMostLiked = false
                    },
                    new Product
                    {
                        Name = "Croissant",
                        Price = 6,
                        Description = "Classic shit!",
                        ProductSorter = ProductSorters["Sweets"],
                        ImageURL = "http://www.creationfood.ca/wp-content/uploads/2015/02/croissants-korea-AFPrelax-151113.jpg",
                        InStock = true,
                        IsMostLiked = true
                    }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, ProductSorter> productSorters;
        public static Dictionary<string, ProductSorter> ProductSorters
        {
            get
            {
                if (productSorters == null)
                {
                    var productSortersList = new ProductSorter[]
                    {
                        new ProductSorter { Name = "Bagels", Description="All kinds of bagels" },
                        new ProductSorter { Name = "Breads", Description="All kinds of delicious bread" },
                        new ProductSorter { Name = "Sweets", Description="All kinds of sweet treats" }

                    };

                    productSorters = new Dictionary<string, ProductSorter>();

                    foreach (ProductSorter sorter in productSortersList)
                    {
                        productSorters.Add(sorter.Name, sorter);
                    }
                }

                return productSorters;
            }
        }
    }
}

