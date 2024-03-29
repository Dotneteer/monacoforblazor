﻿namespace MonacoForBlazor.Api.Abstractions
{
    /// <summary>
    /// Represents the current configuration of the editor
    /// </summary>
    public interface IEditorConfiguration
    {
        /// <summary>
        /// Options for auto closing brackets.
        /// </summary>
        string AutoClosingBrackets { get; }

        /// <summary>
        /// Options for auto closing quotes.
        /// </summary>
        string AutoClosingQuotes { get; }

        /// <summary>
        /// Enable auto indentation adjustment.
        /// </summary>
        bool AutoIndent { get; }

        /// <summary>
        /// Options for auto surrounding.
        /// </summary>
        string AutoSurround { get; }

        /// <summary>
        /// Enables layer hinting.
        /// </summary>
        bool CanUseLayerHinting { get; }

        /// <summary>
        /// Retrieves the editor contribution information.
        /// </summary>
        IEditorContribOptions ContribInfo { get; }

        /// <summary>
        /// Enables rich text copy.
        /// </summary>
        bool CopyWithSyntaxHighlighting { get; }
        
        /// <summary>
        /// Enables drag and drop operations.
        /// </summary>
        bool DragAndDrop { get; }

        /// <summary>
        /// Class name to be added to the editor.
        /// </summary>
        string EditorClassName { get; }

        /// <summary>
        /// Copying without a selection copies the current line.
        /// </summary>
        bool EmptySelectionClipboard { get; }

        /// <summary>
        /// Retrieves the information about the editor font.
        /// </summary>
        IFontInfo FontInfo { get; }
        
        /// <summary>
        /// Retrieves information about the editor layout
        /// </summary>
        IEditorLayoutInfo LayoutInfo { get; }

        /// <summary>
        /// The line height.
        /// </summary>
        int LineHeight { get; }

        /// <summary>
        /// Merge overlapping selections.
        /// </summary>
        bool MultiCursorMergeOverlapping { get; }

        /// <summary>
        /// The modifier key to be used to add multiple cursors with the mouse.
        /// </summary>
        string MultiCursorModifier { get; }

        /// <summary>
        /// The pixel ratio of the editor.
        /// </summary>
        double PixelRatio { get; }

        /// <summary>
        /// Is the editor read-only?
        /// </summary>        
        bool ReadOnly { get; }

        /// <summary>
        /// Controls fading out of unused variables.
        /// </summary>
        bool ShowUnused { get; }

        /// <summary>
        /// Enables tabfocus.
        /// </summary>
        bool TabFocusMode { get; }

        /// <summary>
        /// Inserting and deleting whitespace follows tab stops.
        /// </summary>
        bool UseTabStops { get; }

        /// <summary>
        /// A string containing the word separators used when doing word navigation.
        /// </summary>
        string WordSeparators { get; }

        /// <summary>
        /// Retrieves the information about the editor's view.
        /// </summary>
        IEditorViewOptions ViewInfo { get; }

        /// <summary>
        /// Retrieves the information about wrapping.
        /// </summary>
        IEditorWrappingInfo WrappingInfo { get; }
    }
}