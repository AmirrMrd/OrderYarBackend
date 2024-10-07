namespace OrderYar.Backend.Api.Application.Common.Models.Items;

public class ItemDTO
{
    public string ItemName { get; set; } = string.Empty;
    public string ItemPrice { get; set; } = string.Empty;
    public string ItemDescription { get; set; } = string.Empty;
    public int ItemCategoryId { get; set; }
    public string CategoryName { get; set; }
}
