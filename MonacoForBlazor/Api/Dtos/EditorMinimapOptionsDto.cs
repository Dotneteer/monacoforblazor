using MonacoForBlazor.Api.Abstractions;

namespace MonacoForBlazor.Api.Dtos
{
    /// <summary>
    /// Transfers the minimap options for the editor from
    /// JavaScript to .NET.
    /// </summary>
    public class EditorMinimapOptionsDto : IEditorMinimapOptions
    {
        /// <summary>
        /// Enable the rendering of the minimap.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Limit the width of the minimap to render at most a certain number of columns.
        /// </summary>
        public int MaxColumn { get; set; }

        /// <summary>
        /// Render the actual text on a line (as opposed to color blocks).
        /// </summary>
        public bool RenderCharacters { get; set; }

        /// <summary>
        /// Control the rendering of the minimap slider.
        /// </summary>
        public string ShowSlider { get; set; }

        /// <summary>
        /// Control the side of the minimap in editor.
        /// </summary>
        public string Side { get; set; }
    }
}
