using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleProject.Server.Infrastructure.Persistance.Configuration.Todo;

internal sealed class TodoConfiguration : IEntityTypeConfiguration<Domain.Todo.Todo>
{
    public void Configure(EntityTypeBuilder<Domain.Todo.Todo> builder)
    {
        builder.ToTable("Todo", "TODO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Description).HasMaxLength(100);
        builder.Property(x => x.Completed).HasDefaultValue(false);
    }
}