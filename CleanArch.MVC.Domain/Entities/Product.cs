using System.Reflection;
using CleanArch.MVC.Domain.Validation;

namespace CleanArch.MVC.Domain.Entities;

public sealed class Product : Entity
{
    public String Name { get; private set; }
    public String Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public String Image { get; private set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }
    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        DomainExcpetionValidation.When(id < 0, "Invalid id value");
        Id = id;
        ValidateDomain(name, description, price, stock, image);
    }
    public void Update(string name, string description, decimal price, int stock, string image, int CategoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        CategoryId = CategoryId;
    }
    public void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        DomainExcpetionValidation.When(string.IsNullOrEmpty(name), "Invalid name, Name is Required");
        DomainExcpetionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");
        DomainExcpetionValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required");
        DomainExcpetionValidation.When(description.Length < 5, "Invalid description, too short, minimun 5 charachters");
        DomainExcpetionValidation.When(price < 0, "Invalid price value");
        DomainExcpetionValidation.When(stock < 0, "Invalid stock value");
        DomainExcpetionValidation.When(image?.Length > 250, "Invalid image name, too long, maximum 250 characters");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }
}