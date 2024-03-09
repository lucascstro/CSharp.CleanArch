public class Product
{
    public int Id { get; set; }
    public String Name { get; set; }
    public String Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public String Image { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}