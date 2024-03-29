﻿using System.Collections.ObjectModel;

namespace MonacoForBlazor.Api.Abstractions
{
    /// <summary>
    /// Represents the contribution options for the editor.
    /// </summary>
    public interface IEditorContribOptions
    {
        /// <summary>
        /// Accept suggestions on provider defined characters.
        /// </summary>
        bool AcceptSuggestionOnCommitCharacter { get; }

        /// <summary>
        /// Accept suggestions on ENTER.
        /// </summary>
        string AcceptSuggestionOnEnter { get; }

        /// <summary>
        /// Code action kinds to be run on save.
        /// </summary>
        ReadOnlyDictionary<string, bool> CodeActionsOnSave { get; }

        /// <summary>
        /// Timeout for running code actions on save.
        /// </summary>
        int CodeActionsOnSaveTimeout { get; }

        /// <summary>
        /// Show code lens.
        /// </summary>
        bool CodeLens { get; }

        /// <summary>
        /// Enable inline color decorators and color picker rendering.
        /// </summary>
        bool ColorDecorators { get; }

        /// <summary>
        /// Enable custom contextmenu.
        /// </summary>
        bool Contextmenu { get; }

        /// <summary>
        /// Control the behavior of the find widget.
        /// </summary>
        IEditorFindOptions Find { get; }

        /// <summary>
        /// Enable code folding.
        /// </summary>
        bool Folding { get; }

        /// <summary>
        /// Gets the folding strategy.
        /// </summary>
        string FoldingStrategy { get; }

        /// <summary>
        /// Enable format on paste.
        /// </summary>
        bool FormatOnPaste { get; }

        /// <summary>
        /// Enable format on type.
        /// </summary>
        bool FormatOnType { get; }

        /// <summary>
        /// Gets go to location behavior.
        /// </summary>
        IGoToLocationOptions GotoLocation { get; }

        /// <summary>
        /// Gets the editor's hover behavior
        /// </summary>
        IEditorHoverOptions Hover { get; }

        /// <summary>
        /// Enables the lightbulb indicator.
        /// </summary>
        bool LightbulbEnabled { get; }

        /// <summary>
        /// Enable detecting links and making them clickable.
        /// </summary>
        bool Links { get; }

        /// <summary>
        /// Enable highlighting of matching brackets.
        /// </summary>
        bool MatchBrackets { get; }

        /// <summary>
        /// Enable semantic occurrences highlight.
        /// </summary>
        bool OccurrencesHighlight { get; }

        /// <summary>
        /// Gets information abaout parameter hints behavior.
        /// </summary>
        IEditorParameterHintOptions ParameterHints { get; }

        /// <summary>
        /// Gets information about quick suggestions.
        /// </summary>
        IQuickSuggestionOptions QuickSuggestionOptions { get; }

        /// <summary>
        /// Enables quick suggestions.
        /// </summary>
        bool? QuickSuggestions { get; }

        /// <summary>
        /// Quick suggestions show delay (in ms).
        /// </summary>
        int QuickSuggestionsDelay { get; }

        /// <summary>
        /// Enable Linux primary clipboard.
        /// </summary>
        bool SelectionClipboard { get; }

        /// <summary>
        /// Enable selection highlight.
        /// </summary>
        bool SelectionHighlight { get; }

        /// <summary>
        /// Controls whether the fold actions in the gutter stay always visible 
        /// or hide unless the mouse is over the gutter.
        /// </summary>
        string ShowFoldingControls { get; }

        /// <summary>
        /// Gets the suggest behavior of the editor.
        /// </summary>
        ISuggestOptions Suggest { get; }

        /// <summary>
        /// The font size for the suggest widget.
        /// </summary>
        double SuggestFontSize { get; }

        /// <summary>
        /// The line height for the suggest widget.
        /// </summary>
        int SuggestLineHeight { get; }

        /// <summary>
        /// Enable the suggestion box to pop-up on trigger characters.
        /// </summary>
        bool SuggestOnTriggerCharacters { get; }

        /// <summary>
        /// The history mode for suggestions.
        /// </summary>
        string SuggestSelection { get; }

        /// <summary>
        /// Enable tab completion.
        /// </summary>
        string TabCompletion { get; }

        /// <summary>
        /// Enable word based suggestions.
        /// </summary>
        bool WordBasedSuggestions { get; }
    }
}