using MonacoForBlazor.Api.Abstractions;
using MonacoForBlazor.Api.Enums;

namespace MonacoForBlazor.Api
{
    /// <summary>
    /// The view options for the editor
    /// </summary>
    public class EditorViewOptions : IEditorViewOptions
    {
        public string ExtraEditorClassName { get; set; }
        public bool DisableMonospaceOptimizations { get; set; }
        public int[] Rulers { get; set; }
        public string AriaLabel { get; set; }
        public RenderLineNumbersType RenderLineNumbers { get; set; }
        public int CursorSurroundingLines { get; set; }
        public bool RenderFinalNewline { get; set; }
        public bool SelectOnLineNumbers { get; set; }
        public bool GlyphMargin { get; set; }
        public int RevealHorizontalRightPadding { get; set; }
        public bool RoundedSelection { get; set; }
        public int OverviewRulerLanes { get; set; }
        public bool OverviewRulerBorder { get; set; }
        public TextEditorCursorBlinkingStyle CursorBlinking { get; set; }
        public bool MouseWheelZoom { get; set; }
        public bool CursorSmoothCaretAnimation { get; set; }
        public TextEditorCursorStyle CursorStyle { get; set; }
        public int CursorWidth { get; set; }
        public bool HideCursorInOverviewRuler { get; set; }
        public bool ScrollBeyondLastLine { get; set; }
        public int ScrollBeyondLastColumn { get; set; }
        public bool SmoothScrolling { get; set; }
        public int StopRenderingLineAfter { get; set; }
        public string RenderWhitespace { get; set; }
        public bool RenderControlCharacters { get; set; }
        public bool FontLigatures { get; set; }
        public bool RenderIndentGuides { get; set; }
        public bool HighlightActiveIndentGuide { get; set; }
        public string RenderLineHighlight { get; set; }
        public InternalEditorScrollbarOptions Scrollbar { get; set; }
        public InternalEditorMinimapOptions Minimap { get; set; }
        public bool FixedOverflowWidgets { get; set; }
    }
}
