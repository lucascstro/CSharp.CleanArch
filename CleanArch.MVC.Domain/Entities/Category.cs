public class Category
{
    public int Id { get; set; }
    public String Name { get; set; }
    public ICollection<Product> Products { get; set; }
}