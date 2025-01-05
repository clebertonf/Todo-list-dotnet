using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Todo.Domain.Entities.Task;

namespace Todo.Infra.Data.EntitiesConfiguration;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> task)
    {
        task.HasKey(t => t.Id);
        task.Property(t => t.Title).HasMaxLength(100).IsRequired();
        task.Property(t => t.Description).HasMaxLength(1000).IsRequired();
        task.Property(t => t.DueDate).HasColumnType("date");
        task.Property(t => t.IsCompleted).IsRequired();
        task.HasOne(t => t.Category).WithMany(c => c.Tasks).HasForeignKey(t => t.CategoryId);
    }
}