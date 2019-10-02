using MonacoForBlazor.Api.Enums;

namespace MonacoForBlazor.Api.Abstractions
{
    /// <summary>
    /// Represents the scrollbar options of the editor
    /// </summary>
    public interface IEditorScrollbarOptions
    {
        /// <summary>
        /// The size of arrows (if displayed).
        /// </summary>
        int ArrowSize { get; }

        int FastScrollSensitivity { get; }

        /// <summary>
        /// Listen to mouse wheel events and react to them by scrolling.
        /// </summary>
        bool HandleMouseWheel { get; }

        /// <summary>
        /// The visibility of the horizontal scrollbar.
        /// </summary>
        ScrollbarVisibility Horizontal { get; }

        /// <summary>
        /// Indicates whether the horizontal scrollbar has arrows.
        /// </summary>
        bool HorizontalHasArrows { get; }
        int HorizontalScrollbarSize { get; }
        int HorizontalSliderSize { get; }
        int MouseWheelScrollSensitivity { get; }

        /// <summary>
        /// Cast horizontal and vertical shadows when the content is scrolled.
        /// </summary>
        bool UseShadows { get; }

        /// <summary>
        /// The visibility of the vertical scrollbar.
        /// </summary>
        ScrollbarVisibility Vertical { get; }

        /// <summary>
        /// Indicates whether the vertical scrollbar has arrows.
        /// </summary>
        bool VerticalHasArrows { get; }

        int VerticalScrollbarSize { get; }
        int VerticalSliderSize { get; }
    }
}