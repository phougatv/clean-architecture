namespace ConsoleApp.Base
{
    public class ComponentBaseResponse
    {
        public bool IsValid { get; }
        public string Message { get; }
        public ComponentBaseResponse(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
    }
}
