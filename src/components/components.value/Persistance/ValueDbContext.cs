namespace Components.Value.Persistance
{
    using Microsoft.EntityFrameworkCore;

    internal class ValueDbContext : DbContext
    {
        internal ValueDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Remove pluralizing table name convention (Install package - Microsoft.EntityFrameworkCore.Relational)
            foreach (var entity in builder.Model.GetEntityTypes())
                entity.SetTableName(entity.DisplayName());

            base.OnModelCreating(builder);
        }


    }
}
