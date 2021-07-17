namespace ConsoleApp.Value.Dtos
{
    using Components.Value.Business.Models;
    using ConsoleApp.Base;

    public class ValueDto : ComponentBaseResponse
    {
        public ValueDomainModel Value { get; set; }
        public ValueDto(ValueDomainModel value, bool isValid)
            : base(isValid)
        {
            Value = value;
        }
    }
}
