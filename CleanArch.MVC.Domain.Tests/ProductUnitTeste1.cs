using CleanArch.MVC.Domain.Entities;
using FluentAssertions;

namespace CleanArch.MVC.Domain.Tests;

public class ProductUnitTeste1
{
    [Fact]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product name", "Produto Description", 9.99m, 99, "Product Image");
        action.Should()
        .NotThrow<Validation.DomainExcpetionValidation>();
    }

    [Fact]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1, "Product name", "Produto Description", 9.99m, 99, "Product Image");
        action.Should()
        .Throw<Validation.DomainExcpetionValidation>()
        .WithMessage("Invalid id value");
    }

    [Fact]
    public void CreateProduct_NameNotinformed_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, "", "Produto Description", 9.99m, 99, "Product Image");
        action.Should()
        .Throw<Validation.DomainExcpetionValidation>()
        .WithMessage("Invalid name, Name is Required");
    }
    
    [Fact]
    public void CreateProduct_ShortName_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, "Pr", "Produto Description", 9.99m, 99, "Product Image");
        action.Should()
        .Throw<Validation.DomainExcpetionValidation>()
        .WithMessage("Invalid name, too short, minimum 3 characters");
    }
    [Fact]
    public void CreateProduct_NullDescription_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, "ProductName", "", 9.99m, 99, "Product Image");
        action.Should()
        .Throw<Validation.DomainExcpetionValidation>()
        .WithMessage( "Invalid description. Description is required");
    }

    [Fact]
    public void CreateProduct_ShortDescription_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, "ProductName", "desc", 9.99m, 99, "Product Image");
        action.Should()
        .Throw<Validation.DomainExcpetionValidation>()
        .WithMessage( "Invalid description, too short, minimun 5 charachters");
    }
    [Fact]
    public void CreateProduct_InvalidPrice_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, "ProductName", "product description", -3, 99, "Product Image");
        action.Should()
        .Throw<Validation.DomainExcpetionValidation>()
        .WithMessage( "Invalid price value");
    }
    [Fact]
    public void CreateProduct_InvalidStock_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, "ProductName", "product description", 9.99m, -2, "Product Image");
        action.Should()
        .Throw<Validation.DomainExcpetionValidation>()
        .WithMessage( "Invalid stock value");
    }
    [Fact]
    public void CreateProduct_InvalidImage_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, "ProductName", "product description", 9.99m, 99, "Product Image shfahsdfhasdkfhaksdhfkashfdkahsfdkhasdfkhasdkfhaksdfhklashdfklahsdfkhsdfkhaskldfhashfahsdfhasdkfhaksdhfkashfdkahsfdkhasdfkhasdkfhaksdfhklashdfklahsdfkhsdfkhaskldfhashfahsdfhasdkfhaksdhfkashfdkahsfdkhasdfkhasdkfhaksdfhklashdfklahsdfkhsdfkhaskldfhashfahsdfhasdkfhaksdhfkashfdkahsfdkhasdfkhasdkfhaksdfhklashdfklahsdfkhsdfkhaskldfhashfahsdfhasdkfhaksdhfkashfdkahsfdkhasdfkhasdkfhaksdfhklashdfklahsdfkhsdfkhaskldfha");
        action.Should()
        .Throw<Validation.DomainExcpetionValidation>()
        .WithMessage("Invalid image name, too long, maximum 250 characters");
    }
}