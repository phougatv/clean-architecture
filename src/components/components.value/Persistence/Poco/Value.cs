namespace Components.Value.Persistence.Poco
{
    using Components.Core.DataAccess.Base.Poco;
    using Components.DataAccess.Sql.Attributes;

    internal class Value : Entity
    {
        [PropertyParameterBinder("@Name")]
        internal string Name { get; set; }
    }
}
