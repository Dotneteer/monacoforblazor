namespace MonacoForBlazor.Api.Abstractions
{
    public interface IEditorConfiguration
    {
        string AutoClosingBrackets { get; }
        string AutoClosingQuotes { get; }
        bool AutoIndent { get; }
        string AutoSurround { get; }
        bool CanUseLayerHinting { get; }
        EditorContribOptions ContribInfo { get; }
        bool CopyWithSyntaxHighlighting { get; }
        bool DragAndDrop { get; }
        string EditorClassName { get; }
        bool EmptySelectionClipboard { get; }
        FontInfo FontInfo { get; }
        EditorLayoutInfo LayoutInfo { get; }
        int LineHeight { get; }
        bool MultiCursorMergeOverlapping { get; }
        string MultiCursorModifier { get; }
        double PixelRatio { get; }
        bool ReadOnly { get; }
        bool ShowUnused { get; }
        bool TabFocusMode { get; }
        bool UseTabStops { get; }
        EditorViewOptions ViewInfo { get; }
        string WordSeparators { get; }
        EditorWrappingInfo WrappingInfo { get; }
    }
}