namespace Components.User.Persistance
{
    using Components.User.Persistance.Poco;
    using Microsoft.EntityFrameworkCore;
    using System;

    internal sealed class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            foreach (var entity in builder.Model.GetEntityTypes())
            {
                //Remove pluralizing table name convention (Install package - Microsoft.EntityFrameworkCore.Relational)
                entity.SetTableName(entity.DisplayName());
            }

            // The following code statements adds non-public properties to the EF-Core model.
            // Follow the link for more details - https://docs.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=fluent-api%2Cwithout-nrt#included-and-excluded-properties
            //builder.Entity<User>().Property(x => x.FirstName);
            //builder.Entity<User>().Property(x => x.MiddleName);
            //builder.Entity<User>().Property(x => x.LastName);
            //builder.Entity<User>().Property(x => x.EmailId);
            //builder.Entity<User>().Property(x => x.DateOfBirth);


            base.OnModelCreating(builder);
        }

        //private void AddNonPublicPropertiesToTheModel()
        //{
        //    var types = GetAllMembersOfNamespaceOfExecutingAssembly("Components.User.Persistance.Poco");
        //    foreach (var type in types)
        //    {
        //        foreach (var propertyInfo in GetNonPublicInstancePropertyInfo(type))
        //        {
        //            var parameter = Expression.Parameter(type);
        //            var property = Expression.Property(parameter, propertyInfo);
        //            var conversion = Expression.Convert(property, typeof(object));
        //            //var lambda = Expression.Lambda<Func<, object>>
        //        }
        //    }
        //}

        //private static PropertyInfo[] GetNonPublicInstancePropertyInfo(Type type) =>
        //    type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);

        //private static Type[] GetAllMembersOfNamespaceOfExecutingAssembly(string namespaceName) =>
        //    GetAllMembersOfNamespace(namespaceName, Assembly.GetExecutingAssembly());
        //private static Type[] GetAllMembersOfNamespace(string @namespace, Assembly assembly) =>
        //    assembly
        //        .GetTypes()
        //        .Where(type => string.Equals(type.Namespace, @namespace, StringComparison.Ordinal))
        //        .ToArray();

        internal DbSet<User> Users { get; set; }
    }
}
