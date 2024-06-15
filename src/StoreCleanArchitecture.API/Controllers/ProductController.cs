using Microsoft.AspNetCore.Mvc;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Entities.Domain;

namespace StoreCleanArchitecture.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductDbContext _productDbContext;
    private readonly IProductService _productService;
    public ProductController(IProductDbContext productDbContext, IProductService productService){
        _productDbContext = productDbContext;
        _productService = productService;
    }
    
    [HttpGet("getFromDB")]
    public IActionResult GetFromDB()
    {
        return Ok(_productDbContext.Products.FirstOrDefault());
    }

    [HttpGet("addWithDB")]
    public async Task<IActionResult> AddWithDB()
    {
        _productDbContext.Products.Add(new Product{
            Name = "Apple",
            Description = "Simple apple",
            Category = "Fruits",
            Cost = 0
        });
        await _productDbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("GetFromService")]
    public async Task<IActionResult> GetFromService()
    {
        return Ok(await _productService.GetProductsAsync());
    }
}
