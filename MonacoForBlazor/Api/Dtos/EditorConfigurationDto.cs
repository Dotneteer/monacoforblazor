namespace MonacoForBlazor.Api.Dtos
{
    /// <summary>
    /// Transfers the current configuration of the editor
    /// from JavaScript to .NET.
    /// </summary>
    public class EditorConfigurationDto
    {
        /// <summary>
        /// Options for auto closing brackets.
        /// </summary>
        public string AutoClosingBrackets { get; set; }

        /// <summary>
        /// Options for auto closing quotes.
        /// </summary>
        public string AutoClosingQuotes { get; set; }

        /// <summary>
        /// Enable auto indentation adjustment.
        /// </summary>
        public bool AutoIndent { get; set; }

        /// <summary>
        /// Options for auto surrounding.
        /// </summary>
        public string AutoSurround { get; set; }

        /// <summary>
        /// Enables layer hinting.
        /// </summary>
        public bool CanUseLayerHinting { get; set; }

        /// <summary>
        /// Retrieves the editor contribution information.
        /// </summary>
        public EditorContribOptionsDto ContribInfo { get; set; }

        /// <summary>
        /// Enables rich text copy.
        /// </summary>
        public bool CopyWithSyntaxHighlighting { get; set; }

        /// <summary>
        /// Enables drag and drop operations.
        /// </summary>
        public bool DragAndDrop { get; set; }

        /// <summary>
        /// Class name to be added to the editor.
        /// </summary>
        public string EditorClassName { get; set; }

        /// <summary>
        /// Copying without a selection copies the current line.
        /// </summary>
        public bool EmptySelectionClipboard { get; set; }

        /// <summary>
        /// Retrieves the information about the editor font.
        /// </summary>
        public FontInfoDto FontInfo { get; set; }

        /// <summary>
        /// Retrieves information about the editor layout
        /// </summary>
        public EditorLayoutInfoDto LayoutInfo { get; set; }

        /// <summary>
        /// The line height.
        /// </summary>
        public int LineHeight { get; set; }

        /// <summary>
        /// Merge overlapping selections.
        /// </summary>
        public bool MultiCursorMergeOverlapping { get; set; }

        /// <summary>
        /// The modifier key to be used to add multiple cursors with the mouse.
        /// </summary>
        public string MultiCursorModifier { get; set; }

        /// <summary>
        /// The pixel ratio of the editor.
        /// </summary>
        public double PixelRatio { get; set; }

        /// <summary>
        /// Is the editor read-only?
        /// </summary>        
        public bool ReadOnly { get; set; }

        /// <summary>
        /// Controls fading out of unused variables.
        /// </summary>
        public bool ShowUnused { get; set; }

        /// <summary>
        /// Enables tabfocus.
        /// </summary>
        public bool TabFocusMode { get; set; }

        /// <summary>
        /// Inserting and deleting whitespace follows tab stops.
        /// </summary>
        public bool UseTabStops { get; set; }

        /// <summary>
        /// A string containing the word separators used when doing word navigation.
        /// </summary>
        public string WordSeparators { get; set; }

        /// <summary>
        /// Retrieves the information about the editor's view.
        /// </summary>
        public EditorViewOptionsDto ViewInfo { get; set; }

        /// <summary>
        /// Retrieves the information about wrapping.
        /// </summary>
        public EditorWrappingInfoDto WrappingInfo { get; set; }
    }
}
