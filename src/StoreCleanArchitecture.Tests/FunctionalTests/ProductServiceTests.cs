using FluentAssertions;
using Moq;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Application.Services.Products;
using StoreCleanArchitecture.Domain.Entities;

namespace StoreCleanArchitecture.Tests.FunctionalTests;

public class ProductServiceTests
{
    [Fact]
    public void AddProduct_ShouldAddProductToDatabase()
    {
        
    }
    
    [Fact]
    public void GetProduct_ShouldReturnProductFromDatabase()
    {
        var mockedIProductRepository = new Mock<IProductRepository>();
        
        mockedIProductRepository.Setup(repo => repo.GetAll()).Returns((new Product[]{
            new Product{ Id = 1, Category = "Fruits", Name = "Orange", Description = "Big Orange"},
            new Product{ Id = 2, Category = "Fruits", Name = "Apple", Description = "Little Apple"},
        }).AsQueryable);
        
        
        var productService = new ProductService(mockedIProductRepository.Object);

        var products = productService.GetProducts();

        products.Should().NotBeNullOrEmpty();
        products.First().Should().BeEquivalentTo(new Product
        {
            Id = 1, Category = "Fruits", Name = "Orange", Description = "Big Orange"
        });
        products.Last().Should().BeEquivalentTo(new Product
        {
            Id = 2, Category = "Fruits", Name = "Apple", Description = "Little Apple"
        });
    }

}