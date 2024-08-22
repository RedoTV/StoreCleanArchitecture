using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreCleanArchitecture.Application.Interfaces.Email;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Domain.Entities;

namespace StoreCleanArchitecture.API.Controllers;

[Authorize(Roles = "User")]
[ApiController]
[Route("api/[controller]")]
public class ProductController(
    IProductRepository _storeDbContext,
    IProductService productService,
    IEmailSender emailSender)
    : ControllerBase
{
    [HttpGet("GetFromService")]
    public IActionResult GetFromService()
    {
        return Ok(productService.GetProducts());
    }
    
    [HttpGet("GetFromDb")]
    public IActionResult GetFromDb()
    {
        return Ok(_storeDbContext.GetAll());
    }
    
    [HttpGet("AddWithDb")]
    public async Task<IActionResult> AddWithDb()
    {
        await _storeDbContext.AddAsync(new Product{
            Name = "Apple",
            Description = "Simple apple",
            Category = "Fruits",
            Cost = 0
        });
        return Ok();
    }
    
    [HttpGet("CheckEmail")]
    public async Task<IActionResult> CheckEmail(string reciever, string subject, string htmlMessage)
    {
        await emailSender.SendEmailAsync(reciever, subject, htmlMessage);
        return Ok();
    }
}
