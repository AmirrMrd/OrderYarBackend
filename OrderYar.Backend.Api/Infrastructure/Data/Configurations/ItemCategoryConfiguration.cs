using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderYar.Backend.Api.Infrastructure.Data.Configurations;

public class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
{
    public void Configure(EntityTypeBuilder<ItemCategory> builder)
    {

        builder.ToTable("ItemCategories");

        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Items);
        // تعریف رابطه یک‌به‌چند با مشخص کردن کلید خارجی و رفتار حذف
        builder.HasMany(x => x.Items)
               .WithOne(x => x.ItemCategory)
               .HasForeignKey(x => x.ItemCategoryId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
