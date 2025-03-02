﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApiSln.Domain.Common;

namespace YoutubeApiSln.Domain.Entitites;

public class ProductCategory : IEntityBase
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public Product? Product { get; set; }
    public Category? Category { get; set; }
}
