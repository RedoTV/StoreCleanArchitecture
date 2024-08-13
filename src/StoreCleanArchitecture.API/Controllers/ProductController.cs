using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreCleanArchitecture.Application.Interfaces.Email;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Domain.Entities;

namespace StoreCleanArchitecture.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(
    IProductRepository productDbContext,
    IProductService productService,
    IEmailSender emailSender)
    : ControllerBase
{
    [HttpGet("GetFromDb")]
    public IActionResult GetFromDb()
    {
        return Ok(productDbContext.GetAll());
    }

    [HttpGet("AddWithDb")]
    public async Task<IActionResult> AddWithDb()
    {
        await productDbContext.AddAsync(new Product{
            Name = "Apple",
            Description = "Simple apple",
            Category = "Fruits",
            Cost = 0
        });
        return Ok();
    }

    [HttpGet("GetFromService")]
    public IActionResult GetFromService()
    {
        return Ok(productService.GetProducts());
    }

    [Authorize]
    [HttpGet("CheckEmail")]
    public async Task<IActionResult> CheckEmail(string reciever, string subject, string htmlMessage)
    {
        await emailSender.SendEmailAsync(reciever, subject, htmlMessage);
        return Ok();
    }
}
