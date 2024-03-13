using CleanArch.MVC.Domain.Validation;

namespace CleanArch.MVC.Domain.Entities;
public sealed class Category : Entity
{
    public String Name { get; private set; }
    public ICollection<Product> Products { get; set; }

    public Category(string name)
    {
        ValidateDomain(name);
    }
    public Category(int id, string name)
    {
        DomainExcpetionValidation.When(id < 0, "Invalid id value");
        ValidateDomain(name);
        Id = id;
    }

    public void Update(string name){
        ValidateDomain(name);
    }
    public void ValidateDomain(string name){
        DomainExcpetionValidation.When(String.IsNullOrEmpty(name), "Invalid name. Name is required");
        DomainExcpetionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");
         
        Name = name;
    }
}