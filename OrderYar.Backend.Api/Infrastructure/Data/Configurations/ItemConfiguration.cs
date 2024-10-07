using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderYar.Backend.Api.Infrastructure.Data.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items");

        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.ItemCategory);
        // تعریف رابطه چند‌به‌یک با مشخص کردن کلید خارجی
        builder.HasOne(x => x.ItemCategory)
               .WithMany(x => x.Items)
               .HasForeignKey(x => x.ItemCategoryId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
