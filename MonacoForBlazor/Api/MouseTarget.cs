﻿using MonacoForBlazor.Api.Enums;

namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Target hit with the mouse in the editor.
    /// </summary>
    public class MouseTarget
    {
        /// <summary>
        /// The target element
        /// </summary>
        public string ElementId { get; set; }

        /// <summary>
        /// The target type
        /// </summary>
        public MouseTargetType Type { get; set; }

        /// <summary>
        /// The 'approximate' editor position
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Desired mouse column (e.g. when position.column gets clamped to text length 
        /// -- clicking after text on a line).
        /// </summary>
        public int MouseColumn { get; set; }

        /// <summary>
        /// The 'approximate' editor range
        /// </summary>
        public Range Range { get; set; }

        /// <summary>
        /// Provides human-readable representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => $"(id: {ElementId}, type: {Type}, mousecol: {MouseColumn}, pos: {Position}, range: {Range})";
    }
}
