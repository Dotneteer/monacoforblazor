using MonacoForBlazor.Api.Enums;

namespace MonacoForBlazor.Api.Abstractions
{
    /// <summary>
    /// The internal layout details of the editor.
    /// </summary>
    public interface IEditorLayoutInfo
    {
        /// <summary>
        /// Full editor width.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Full editor height.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Left position for the glyph margin.
        /// </summary>
        int GlyphMarginLeft { get; }

        /// <summary>
        /// The width of the glyph margin.
        /// </summary>
        int GlyphMarginWidth { get; }

        /// <summary>
        /// The height of the glyph margin.
        /// </summary>
        int GlyphMarginHeight { get; }

        /// <summary>
        /// Left position for the line numbers.
        /// </summary>
        int LineNumbersLeft { get; }

        /// <summary>
        /// The width of the line numbers.
        /// </summary>
        int LineNumbersWidth { get; }

        /// <summary>
        /// The height of the line numbers.
        /// </summary>
        int LineNumbersHeight { get; }

        /// <summary>
        /// Left position for the line decorations.
        /// </summary>
        int DecorationsLeft { get; }

        /// <summary>
        /// The width of the line decorations.
        /// </summary>
        int DecorationsWidth { get; }

        /// <summary>
        /// The height of the line decorations.
        /// </summary>
        int DecorationsHeight { get; }

        /// <summary>
        /// Left position for the content (actual text)
        /// </summary>
        int ContentLeft { get; }

        /// <summary>
        /// The width of the content (actual text)
        /// </summary>
        int ContentWidth { get; }

        /// <summary>
        /// The height of the content (actual height)
        /// </summary>
        int ContentHeight { get; }

        /// <summary>
        /// The position for the minimap
        /// </summary>
        int MinimapLeft { get; }

        /// <summary>
        /// The width of the minimap
        /// </summary>
        int MinimapWidth { get; }

        /// <summary>
        /// Minimap render type
        /// </summary>
        RenderMinimap RenderMinimap { get; }

        /// <summary>
        /// The number of columns (of typical characters) fitting on a viewport line.
        /// </summary>
        int ViewportColumn { get; }

        /// <summary>
        /// The width of the vertical scrollbar.
        /// </summary>
        int VerticalScrollbarWidth { get; }

        /// <summary>
        /// The height of the horizontal scrollbar.
        /// </summary>
        int HorizontalScrollbarHeight { get; }

        /// <summary>
        /// The position of the overview ruler.
        /// </summary>
        OverviewRulerPosition OverviewRuler { get; }
    }
}
