using MonacoForBlazor.Api.Abstractions;
using MonacoForBlazor.Api.Enums;

namespace MonacoForBlazor.Api.Dtos
{
    /// <summary>
    /// Editor scrollbar options
    /// </summary>
    public class EditorScrollbarOptionsDto : IEditorScrollbarOptions
    {
        /// <summary>
        /// The size of arrows (if displayed).
        /// </summary>
        public int ArrowSize { get; set; }

        /// <summary>
        /// Listen to mouse wheel events and react to them by scrolling.
        /// </summary>
        public bool HandleMouseWheel { get; set; }

        /// <summary>
        /// The visibility of the horizontal scrollbar.
        /// </summary>
        public ScrollbarVisibility Horizontal { get; set; }

        /// <summary>
        /// Indicates whether the horizontal scrollbar has arrows.
        /// </summary>
        public bool HorizontalHasArrows { get; set; }

        /// <summary>
        /// The visibility of the vertical scrollbar.
        /// </summary>
        public ScrollbarVisibility Vertical { get; set; }

        /// <summary>
        /// Cast horizontal and vertical shadows when the content is scrolled.
        /// </summary>
        public bool UseShadows { get; set; }

        /// <summary>
        /// Indicates whether the vertical scrollbar has arrows.
        /// </summary>
        public bool VerticalHasArrows { get; set; }

        public int HorizontalScrollbarSize { get; set; }
        public int HorizontalSliderSize { get; set; }
        public int VerticalScrollbarSize { get; set; }
        public int VerticalSliderSize { get; set; }
        public int MouseWheelScrollSensitivity { get; set; }
        public int FastScrollSensitivity { get; set; }
    }
}
