using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApiSln.Domain.Common;

namespace YoutubeApiSln.Domain.Entitites;

public class Product : EntityBase
{
    public Product()
    {

    }
    public Product(string title, string description, int brandId, decimal price, decimal discount)
    {
        Title = title;
        Description = description;
        BrandId = brandId;
        Price = price;
        Discount = discount;
    }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int BrandId { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public Brand? Brand { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; }
}
