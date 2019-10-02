using MonacoForBlazor.Api.Abstractions;
using System.Collections.ObjectModel;

namespace MonacoForBlazor.Api.Internals
{
    /// <summary>
    /// Holds an internal representation of the contribution options for the editor.
    /// </summary>
    internal class InternalEditorContribOptions: IEditorContribOptions
    {
        /// <summary>
        /// Accept suggestions on provider defined characters.
        /// </summary>
        public bool AcceptSuggestionOnCommitCharacter { get; set; }

        /// <summary>
        /// Accept suggestions on ENTER.
        /// </summary>
        public string AcceptSuggestionOnEnter { get; set; }

        /// <summary>
        /// Code action kinds to be run on save.
        /// </summary>
        public ReadOnlyDictionary<string, bool> CodeActionsOnSave { get; set; }

        /// <summary>
        /// Timeout for running code actions on save.
        /// </summary>
        public int CodeActionsOnSaveTimeout { get; set; }

        /// <summary>
        /// Show code lens.
        /// </summary>
        public bool CodeLens { get; set; }

        /// <summary>
        /// Enable inline color decorators and color picker rendering.
        /// </summary>
        public bool ColorDecorators { get; set; }

        /// <summary>
        /// Enable custom contextmenu.
        /// </summary>
        public bool Contextmenu { get; set; }

        /// <summary>
        /// Control the behavior of the find widget.
        /// </summary>
        public IEditorFindOptions Find { get; set; }

        /// <summary>
        /// Enable code folding.
        /// </summary>
        public bool Folding { get; set; }

        /// <summary>
        /// Gets the folding strategy.
        /// </summary>
        public string FoldingStrategy { get; set; }

        /// <summary>
        /// Enable format on paste.
        /// </summary>
        public bool FormatOnPaste { get; set; }

        /// <summary>
        /// Enable format on type.
        /// </summary>
        public bool FormatOnType { get; set; }

        /// <summary>
        /// Gets go to location behavior.
        /// </summary>
        public IGoToLocationOptions GotoLocation { get; set; }

        /// <summary>
        /// Gets the editor's hover behavior
        /// </summary>
        public IEditorHoverOptions Hover { get; set; }

        /// <summary>
        /// Enables the lightbulb indicator.
        /// </summary>
        public bool LightbulbEnabled { get; set; }

        /// <summary>
        /// Enable detecting links and making them clickable.
        /// </summary>
        public bool Links { get; set; }

        /// <summary>
        /// Enable highlighting of matching brackets.
        /// </summary>
        public bool MatchBrackets { get; set; }

        /// <summary>
        /// Enable semantic occurrences highlight.
        /// </summary>
        public bool OccurrencesHighlight { get; set; }

        /// <summary>
        /// Gets information abaout parameter hints behavior.
        /// </summary>
        public IEditorParameterHintOptions ParameterHints { get; set; }

        /// <summary>
        /// Gets information about quick suggestions.
        /// </summary>
        public IQuickSuggestionOptions QuickSuggestionOptions { get; set; }

        /// <summary>
        /// Enables quick suggestions.
        /// </summary>
        public bool? QuickSuggestions { get; set; }

        /// <summary>
        /// Quick suggestions show delay (in ms).
        /// </summary>
        public int QuickSuggestionsDelay { get; set; }

        /// <summary>
        /// Enable Linux primary clipboard.
        /// </summary>
        public bool SelectionClipboard { get; set; }

        /// <summary>
        /// Enable selection highlight.
        /// </summary>
        public bool SelectionHighlight { get; set; }


        /// <summary>
        /// Controls whether the fold actions in the gutter stay always visible 
        /// or hide unless the mouse is over the gutter.
        /// </summary>
        public string ShowFoldingControls { get; set; }

        /// <summary>
        /// Gets the suggest behavior of the editor.
        /// </summary>
        public ISuggestOptions Suggest { get; set; }

        /// <summary>
        /// The font size for the suggest widget.
        /// </summary>
        public double SuggestFontSize { get; set; }

        /// <summary>
        /// The line height for the suggest widget.
        /// </summary>
        public int SuggestLineHeight { get; set; }

        /// <summary>
        /// Enable the suggestion box to pop-up on trigger characters.
        /// </summary>
        public bool SuggestOnTriggerCharacters { get; set; }

        /// <summary>
        /// The history mode for suggestions.
        /// </summary>
        public string SuggestSelection { get; set; }

        /// <summary>
        /// Enable tab completion.
        /// </summary>
        public string TabCompletion { get; set; }

        /// <summary>
        /// Enable word based suggestions.
        /// </summary>
        public bool WordBasedSuggestions { get; set; }
    }
}
