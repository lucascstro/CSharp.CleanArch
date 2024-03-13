using CleanArch.MVC.Domain.Entities;
using FluentAssertions;

namespace CleanArch.MVC.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category with valid state")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action
            .Should()
            .NotThrow<Validation.DomainExcpetionValidation>();
    }

    [Fact]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");
        action
            .Should()
            .Throw<Validation.DomainExcpetionValidation>().WithMessage("Invalid id value");
    }

    [Fact]
    public void CrateCategory_ShortNameValue_DomainExceptionValidation()
    {
        Action action = () => new Category(1, "ca");

        action.Should().Throw<Validation.DomainExcpetionValidation>()
        .WithMessage("Invalid name, too short, minimum 3 characters");
    }


    [Fact]
    public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, string.Empty);
        action
            .Should()
            .Throw<Validation.DomainExcpetionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact]
    public void CreateCategory_NullNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, null);
        action
            .Should()
            .Throw<Validation.DomainExcpetionValidation>();
    }
}