using MonacoForBlazor.Api.Abstractions;

namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Current editor configuration values
    /// </summary>
    public class EditorConfiguration : IEditorConfiguration
    {
        public bool CanUseLayerHinting { get; set; }
        public double PixelRatio { get; set; }
        public string EditorClassName { get; set; }
        public int LineHeight { get; set; }
        public bool ReadOnly { get; set; }
        public string MultiCursorModifier { get; set; }
        public bool MultiCursorMergeOverlapping { get; set; }
        public bool ShowUnused { get; set; }
        public string WordSeparators { get; set; }
        public string AutoClosingBrackets { get; set; }
        public string AutoClosingQuotes { get; set; }
        public string AutoSurround { get; set; }
        public bool AutoIndent { get; set; }
        public bool UseTabStops { get; set; }
        public bool TabFocusMode { get; set; }
        public bool DragAndDrop { get; set; }
        public bool EmptySelectionClipboard { get; set; }
        public bool CopyWithSyntaxHighlighting { get; set; }
        public EditorLayoutInfo LayoutInfo { get; set; }
        public FontInfo FontInfo { get; set; }
        public EditorViewOptions ViewInfo { get; set; }
        public EditorWrappingInfo WrappingInfo { get; set; }
        public EditorContribOptions ContribInfo { get; set; }
    }
}
