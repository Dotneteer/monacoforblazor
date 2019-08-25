﻿namespace MonacoForBlazor.Api.Enums
{
    /// <summary>
    /// The kind of animation in which the editor's cursor should be rendered.
    /// </summary>
    public enum TextEditorCursorBlinkingStyle
    {
        /// <summary>
        /// Hidden
        /// </summary>
        Hidden = 0,

        /// <summary>
        /// Blinking
        /// </summary>
        Blink = 1,

        /// <summary>
        /// Blinking with smooth fading
        /// </summary>
        Smooth = 2,

        /// <summary>
        /// Blinking with prolonged filled state and smooth fading
        /// </summary>
        Phase = 3,

        /// <summary>
        /// Expand collapse animation on the y axis
        /// </summary>
        Expand = 4,

        /// <summary>
        /// No-Blinking
        /// </summary>
        /**
         * No-Blinking
         */
        Solid = 5
    }
}
