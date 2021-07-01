namespace Components.Core.DataAccess.Extensions
{
    using Components.Core.Exceptions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    public static class EntityEntryExtension
    {
        public static bool IsAdded(this EntityEntry entityEntry)
        {
            entityEntry.ThrowArgumentNullException();
            return EntityState.Added == entityEntry.State;
        }
        public static bool IsDeleted(this EntityEntry entityEntry)
        {
            entityEntry.ThrowArgumentNullException();
            return EntityState.Deleted == entityEntry.State;
        }
        public static bool IsDetached(this EntityEntry entityEntry)
        {
            entityEntry.ThrowArgumentNullException();
            return EntityState.Detached == entityEntry.State;
        }
        public static bool IsModified(this EntityEntry entityEntry)
        {
            entityEntry.ThrowArgumentNullException();
            return EntityState.Modified == entityEntry.State;
        }
        public static bool IsUnchanged(this EntityEntry entityEntry)
        {
            entityEntry.ThrowArgumentNullException();
            return EntityState.Unchanged == entityEntry.State;
        }
        public static EntityEntry SetStateToAdded(this EntityEntry entityEntry)
        {
            entityEntry.ThrowArgumentNullException();
            entityEntry.State = EntityState.Added;
            return entityEntry;
        }
        public static EntityEntry SetStateToDeleted(this EntityEntry entityEntry)
        {
            entityEntry.ThrowArgumentNullException();
            entityEntry.State = EntityState.Deleted;
            return entityEntry;
        }
        public static EntityEntry SetStateToDetached(this EntityEntry entityEntry)
        {
            entityEntry.ThrowArgumentNullException();
            entityEntry.State = EntityState.Detached;
            return entityEntry;
        }
        public static EntityEntry SetStateToModified(this EntityEntry entityEntry)
        {
            entityEntry.ThrowArgumentNullException();
            entityEntry.State = EntityState.Modified;
            return entityEntry;
        }
        public static EntityEntry SetStateToUnchanged(this EntityEntry entityEntry)
        {
            entityEntry.ThrowArgumentNullException();
            entityEntry.State = EntityState.Unchanged;
            return entityEntry;
        }

        private static void ThrowArgumentNullException(this EntityEntry entityEntry)
        {
            if (null == entityEntry)
                Throw.ArgumentNullException(nameof(entityEntry));
        }
    }
}
