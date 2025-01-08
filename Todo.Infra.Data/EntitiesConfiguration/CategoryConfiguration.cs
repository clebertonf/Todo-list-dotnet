using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Infra.Data.EntitiesConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> category)
    {
        category.HasKey(c => c.Id);
        category.Property(c => c.Name).HasMaxLength(100).IsRequired();
        category.Property(c => c.Description).HasMaxLength(200).IsRequired();

        /* category.HasData(
            new Category(1, "Personal",
                "Tasks related to your personal life, such as exercising, hobbies, or grocery shopping."),
            new Category(2, "Work",
                "Tasks related to your job or career, like meetings, deadlines, or projects."),
            new Category(3, "Priority",
                "High-importance tasks that require immediate attention, such as paying bills or completing urgent assignments."));
        */
    }
}