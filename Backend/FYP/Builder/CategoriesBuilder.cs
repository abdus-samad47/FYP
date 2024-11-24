using FYP.Models;
using Microsoft.EntityFrameworkCore;

namespace FYP.Builder
{
    public class CategoriesBuilder
    {
        internal static void BuilderCategories(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Categories>();
            builder.ToTable("Categories");
            builder.HasKey(u => u.category_id);
            builder.Property(u => u.category_id).HasColumnName("category_id").IsRequired().ValueGeneratedOnAdd();
            builder.Property(u => u.name).HasColumnName("category_name").IsRequired().HasMaxLength(50).IsUnicode(true);
            builder.Property(u => u.description).HasColumnName("category_description").IsRequired(false).HasMaxLength(50).IsUnicode(true);

            // Add unique constraints
            builder.HasIndex(u => u.name).IsUnique();
        }
    }
}
