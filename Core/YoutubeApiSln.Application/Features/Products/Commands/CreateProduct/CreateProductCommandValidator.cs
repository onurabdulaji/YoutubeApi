﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApiSln.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithName("Baslik");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithName("Aciklama");

        RuleFor(x => x.BrandId)
            .NotEmpty()
            .WithName("Marka");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithName("Fiyat");

        RuleFor(x => x.Discount)
            .GreaterThanOrEqualTo(0)
            .WithName("Indirim Orani");

        RuleFor(x => x.CategoryIds)
            .NotEmpty()
            .Must(categories => categories.Any())
            .WithName("Kategoriler");

    }
}
