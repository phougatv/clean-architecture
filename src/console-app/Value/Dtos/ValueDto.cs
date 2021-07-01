namespace ConsoleApp.Value.Dtos
{
    using Components.Value.Business.Models;
    using ConsoleApp.Base;

    public class ValueDto : ComponentBaseResponse
    {
        public ValueModel Value { get; set; }
        public ValueDto(ValueModel value, bool isValid, string message)
            : base(isValid)
        {
            Value = value;
        }
    }
}
