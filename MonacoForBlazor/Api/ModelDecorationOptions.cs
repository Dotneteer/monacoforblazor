using MonacoForBlazor.Api.Abstractions;
using MonacoForBlazor.Api.Enums;
using System.Collections.Generic;

namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Options for a model decoration.
    /// </summary>
    public class ModelDecorationOptions
    {
        /// <summary>
        /// Customize the growing behavior of the decoration when typing at the edges 
        /// of the decoration. Defaults to TrackedRangeStickiness.AlwaysGrowsWhenTypingAtEdges
        /// </summary>
        public TrackedRangeStickiness Stickiness { get; set; } = TrackedRangeStickiness.AlwaysGrowsWhenTypingAtEdges;

        /// <summary>
        /// CSS class name describing the decoration.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Message to be rendered when hovering over the glyph margin decoration.
        /// </summary>
        public IList<IMarkdownString> GlyphMarginHoverMessage;

        /// <summary>
        /// Array of MarkdownString to render as the decoration message.
        /// </summary>
        public IList<IMarkdownString> HoverMessage;

        /// <summary>
        /// Should the decoration expand to encompass a whole line.
        /// </summary>
        public bool IsWholeLine { get; set; }

        /// <summary>
        /// Always render the decoration (even when the range it encompasses is collapsed).
        /// </summary>
        internal bool ShowIfCollapsed { get; set; }

        /// <summary>
        /// Collapse the decoration if its entire range is being replaced via an edit.
        /// </summary>
        internal bool CollapseOnReplaceEdit { get; set; }

        /// <summary>
        /// Specifies the stack order of a decoration.
        /// A decoration with greater stack order is always in front of a decoration with a lower stack order.
        /// </summary>
        public int? ZIndex;

        /// <summary>
        /// If set, render this decoration in the overview ruler.
        /// </summary>
        public ModelDecorationOverviewRulerOptions OverviewRuler { get; set; }

        /// <summary>
        /// If set, render this decoration in the minimap.
        /// </summary>
        public ModelDecorationMinimapOptions Minimap { get; set; }

        /// <summary>
        /// If set, the decoration will be rendered in the glyph margin with this CSS class name.
        /// </summary>
        public string PubglyphMarginClassName { get; set; }

        /// <summary>
        /// If set, the decoration will be rendered in the lines decorations with this CSS class name.
        /// </summary>
        public string LinesDecorationsClassName { get; set; }

        /// <summary>
        /// If set, the decoration will be rendered in the margin (covering its full width) 
        /// with this CSS class name.
        /// </summary>
        public string MarginClassName { get; set; }

        /// <summary>
        /// If set, the decoration will be rendered inline with the text with this CSS class name.
        /// Please use this only for CSS rules that must impact the text.For example, use `className`
        // to have a background color decoration.
        /// </summary>
        public string InlineClassName { get; set; }

        /// <summary>
        /// If there is an `inlineClassName` which affects letter spacing.
        /// </summary>
        public bool InlineClassNameAffectsLetterSpacing { get; set; }

        /// <summary>
        /// If set, the decoration will be rendered before the text with this CSS class name.
        /// </summary>
        public string BeforeContentClassName { get; set; }

        /// <summary>
        /// If set, the decoration will be rendered after the text with this CSS class name.
        /// </summary>
        public string AfterContentClassName { get; set; }
    }
}
