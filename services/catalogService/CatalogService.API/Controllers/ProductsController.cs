﻿using CatalogService.Application.Features.Products.AddProduct;
using CatalogService.Application.Features.Products.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(nameof(AddProduct))]
        public async Task<IActionResult> AddProduct(AddProductRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpGet(nameof(GetAllProducts))]
        public async Task<IActionResult> GetAllProducts()
        {
            var res = await _mediator.Send(new GetAllProductsRequest());
            return Ok(res);
        }
    }
}
