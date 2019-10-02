namespace MonacoForBlazor.Api.Abstractions
{
    public interface IQuickSuggestionOptions
    {
        bool Comments { get; set; }
        bool Other { get; set; }
        bool Strings { get; set; }
    }
}