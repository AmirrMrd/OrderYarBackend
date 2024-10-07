namespace OrderYar.Backend.Api.Domain.Entities;

public class ItemCategory
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    // مقداردهی اولیه به مجموعه Items برای جلوگیری از NullReferenceException
    public List<Item> Items { get; set; } = new List<Item>();
}
