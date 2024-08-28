namespace NK.ChatGPTClone.Application.Common.Models.Errors
{
    public class ErrorDto
    {
        public string PropertyName { get; set; }

        public IReadOnlyCollection<string> Messages { get; set; }

        public ErrorDto(string propertyName, List<string> messages)
        {
            PropertyName = propertyName;

            Messages = messages;
        }
    }
}
