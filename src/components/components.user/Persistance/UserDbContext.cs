namespace Components.User.Persistance
{
    using Components.User.Persistance.Poco;
    using Microsoft.EntityFrameworkCore;

    internal sealed class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Remove pluralizing table name convention (Install package - Microsoft.EntityFrameworkCore.Relational)
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }

            base.OnModelCreating(builder);
        }

        internal DbSet<User> Users { get; set; }
    }
}
