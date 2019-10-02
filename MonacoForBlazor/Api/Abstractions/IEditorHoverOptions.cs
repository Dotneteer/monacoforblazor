namespace MonacoForBlazor.Api.Abstractions
{
    public interface IEditorHoverOptions
    {
        int Delay { get; }
        bool Enabled { get; }
        bool Sticky { get; }
    }
}