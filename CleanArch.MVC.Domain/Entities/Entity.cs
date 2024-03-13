namespace CleanArch.MVC.Domain.Entities;
public abstract class Entity
{
    //como as classes category e product possuem o atributo Id, deve-se utilizar uma 
    //classe base abstrata afim de evitar repetição de código e seguir o ddd.
    public int Id { get; protected set; } 
}