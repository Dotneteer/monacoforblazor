namespace MonacoForBlazor.Api.Abstractions
{
    /// <summary>
    /// Represents the minmap options for the editor.
    /// </summary>
    public interface IEditorMinimapOptions
    {
        /// <summary>
        /// Enable the rendering of the minimap.
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// Limit the width of the minimap to render at most a certain number of columns.
        /// </summary>
        int MaxColumn { get; }

        /// <summary>
        /// Render the actual text on a line (as opposed to color blocks).
        /// </summary>
        bool RenderCharacters { get; }

        /// <summary>
        /// Control the rendering of the minimap slider.
        /// </summary>
        string ShowSlider { get; }

        /// <summary>
        /// Control the side of the minimap in editor.
        /// </summary>
        string Side { get; }
    }
}