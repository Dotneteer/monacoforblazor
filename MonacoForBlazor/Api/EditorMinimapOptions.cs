using System;
using System.Collections.Generic;
using System.Text;

namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Configuration options for editor minimap
    /// </summary>
    public class EditorMinimapOptions
    {
        /// <summary>
        /// Enable the rendering of the minimap.
        /// Defaults to true.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Control the side of the minimap in editor.
        /// Defaults to 'right'.
        /// </summary>
        public string Side { get; set; } = EditorSideValues.Right;

        /// <summary>
        /// Control the rendering of the minimap slider.
        /// Defaults to 'mouseover'.
        /// </summary>
        public string ShowSlider { get; set; } = ShowPartValues.MouseOver;

        /// <summary>
        /// Render the actual text on a line (as opposed to color blocks).
        /// Defaults to true.
        /// </summary>
        public bool RenderCharacters { get; set; } = true;

        /// <summary>
        /// Limit the width of the minimap to render at most a certain number of columns.
        /// Defaults to 120.
        /// </summary>
        public int MaxColumn { get; set; } = 120;
    }
}
