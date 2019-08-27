using MonacoForBlazor.Api.Enums;

namespace MonacoForBlazor.Api.Abstractions
{
    public interface IEditorViewOptions
    {
        string AriaLabel { get; }
        TextEditorCursorBlinkingStyle CursorBlinking { get; }
        bool CursorSmoothCaretAnimation { get; }
        TextEditorCursorStyle CursorStyle { get; }
        int CursorSurroundingLines { get; }
        int CursorWidth { get; }
        bool DisableMonospaceOptimizations { get; }
        string ExtraEditorClassName { get; }
        bool FixedOverflowWidgets { get; }
        bool FontLigatures { get; }
        bool GlyphMargin { get; }
        bool HideCursorInOverviewRuler { get; }
        bool HighlightActiveIndentGuide { get; }
        InternalEditorMinimapOptions Minimap { get; }
        bool MouseWheelZoom { get; }
        bool OverviewRulerBorder { get; }
        int OverviewRulerLanes { get; }
        bool RenderControlCharacters { get; }
        bool RenderFinalNewline { get; }
        bool RenderIndentGuides { get; }
        string RenderLineHighlight { get; }
        RenderLineNumbersType RenderLineNumbers { get; }
        string RenderWhitespace { get; }
        int RevealHorizontalRightPadding { get; }
        bool RoundedSelection { get; }
        int[] Rulers { get; }
        InternalEditorScrollbarOptions Scrollbar { get; }
        int ScrollBeyondLastColumn { get; }
        bool ScrollBeyondLastLine { get; }
        bool SelectOnLineNumbers { get; }
        bool SmoothScrolling { get; }
        int StopRenderingLineAfter { get; }
    }
}