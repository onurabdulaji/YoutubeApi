﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApiSln.Application.DTOs;
using YoutubeApiSln.Application.Interfaces.AutoMapper;
using YoutubeApiSln.Application.Interfaces.UnitOfWorks;
using YoutubeApiSln.Domain.Entitites;

namespace YoutubeApiSln.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(b => b.Brand));

        var brand = mapper.Map<BrandDto, Brand>(new Brand());

        var map = mapper.Map<GetAllProductsQueryResponse, Product>(products);
        foreach (var item in map)
            item.Price -= (item.Price * item.Discount / 100);

        //return map;

        throw new Exception("Hata Mesaji");
    }
}
