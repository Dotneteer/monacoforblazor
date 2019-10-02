namespace MonacoForBlazor.Api.Abstractions
{
    public interface IEditorFindOptions
    {
        bool AddExtraSpaceOnTop { get; set; }
        bool AutoFindInSelection { get; set; }
        bool SeedSearchStringFromSelection { get; set; }
    }
}