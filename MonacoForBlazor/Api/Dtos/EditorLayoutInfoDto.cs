using MonacoForBlazor.Api.Abstractions;
using MonacoForBlazor.Api.Enums;

namespace MonacoForBlazor.Api.Dtos
{
    /// <summary>
    /// The internal layout details of the editor.
    /// </summary>
    public class EditorLayoutInfoDto: IEditorLayoutInfo
    {
        /// <summary>
        /// Full editor width.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Full editor height.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Left position for the glyph margin.
        /// </summary>
        public int GlyphMarginLeft { get; set; }

        /// <summary>
        /// The width of the glyph margin.
        /// </summary>
        public int GlyphMarginWidth { get; set; }

        /// <summary>
        /// The height of the glyph margin.
        /// </summary>
        public int GlyphMarginHeight { get; set; }

        /// <summary>
        /// Left position for the line numbers.
        /// </summary>
        public int LineNumbersLeft { get; set; }

        /// <summary>
        /// The width of the line numbers.
        /// </summary>
        public int LineNumbersWidth { get; set; }

        /// <summary>
        /// The height of the line numbers.
        /// </summary>
        public int LineNumbersHeight { get; set; }

        /// <summary>
        /// Left position for the line decorations.
        /// </summary>
        public int DecorationsLeft { get; set; }

        /// <summary>
        /// The width of the line decorations.
        /// </summary>
        public int DecorationsWidth { get; set; }

        /// <summary>
        /// The height of the line decorations.
        /// </summary>
        public int DecorationsHeight { get; set; }

        /// <summary>
        /// Left position for the content (actual text)
        /// </summary>
        public int ContentLeft { get; set; }

        /// <summary>
        /// The width of the content (actual text)
        /// </summary>
        public int ContentWidth { get; set; }

        /// <summary>
        /// The height of the content (actual height)
        /// </summary>
        public int ContentHeight { get; set; }

        /// <summary>
        /// The position for the minimap
        /// </summary>
        public int MinimapLeft { get; set; }

        /// <summary>
        /// The width of the minimap
        /// </summary>
        public int MinimapWidth { get; set; }

        /// <summary>
        /// Minimap render type
        /// </summary>
        public RenderMinimap RenderMinimap { get; set; }

        /// <summary>
        /// The number of columns (of typical characters) fitting on a viewport line.
        /// </summary>
        public int ViewportColumn { get; set; }

        /// <summary>
        /// The width of the vertical scrollbar.
        /// </summary>
        public int VerticalScrollbarWidth { get; set; }

        /// <summary>
        /// The height of the horizontal scrollbar.
        /// </summary>
        public int HorizontalScrollbarHeight { get; set; }

        /// <summary>
        /// The position of the overview ruler.
        /// </summary>
        public OverviewRulerPosition OverviewRuler { get; set; }
	}
}
