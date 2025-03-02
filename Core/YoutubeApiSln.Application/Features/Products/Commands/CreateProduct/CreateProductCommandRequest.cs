﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApiSln.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandRequest : IRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int BrandId { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public IList<int>? CategoryIds { get; set; }
}
