namespace ConsoleApp.Base
{
    public class ComponentBaseResponse
    {
        public bool IsValid { get; }

        public ComponentBaseResponse(bool isValid)
        {
            IsValid = isValid;
        }
    }
}
