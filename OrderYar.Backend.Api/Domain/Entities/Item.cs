namespace OrderYar.Backend.Api.Domain.Entities;

public class Item
{
    public int Id { get; set; }
    public string ItemName { get; set; }
    public string ItemPrice { get; set; }
    public string ItemDescription { get; set; }
    public int ItemCategoryId { get; set; }
    public ItemCategory ItemCategory { get; set; }
}
