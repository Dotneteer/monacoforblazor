using System.Collections.Generic;

namespace MonacoForBlazor.Api.Abstractions
{
    public interface IEditorContribOptions
    {
        bool AcceptSuggestionOnCommitCharacter { get; }
        string AcceptSuggestionOnEnter { get; }
        Dictionary<string, bool> CodeActionsOnSave { get; }
        int CodeActionsOnSaveTimeout { get; }
        bool CodeLens { get; }
        bool ColorDecorators { get; }
        bool Contextmenu { get; }
        EditorFindOptions Find { get; }
        bool Folding { get; }
        string FoldingStrategy { get; }
        bool FormatOnPaste { get; }
        bool FormatOnType { get; }
        GoToLocationOptions GotoLocation { get; }
        EditorHoverOptions Hover { get; }
        bool LightbulbEnabled { get; }
        bool Links { get; }
        bool MatchBrackets { get; }
        bool OccurrencesHighlight { get; }
        EditorParameterHintOptions ParameterHints { get; }
        QuickSuggestionOptions QuickSuggestionOptions { get; }
        bool? QuickSuggestions { get; }
        int QuickSuggestionsDelay { get; }
        bool SelectionClipboard { get; }
        bool SelectionHighlight { get; }
        string ShowFoldingControls { get; }
        SuggestOptions Suggest { get; }
        double SuggestFontSize { get; }
        int SuggestLineHeight { get; }
        bool SuggestOnTriggerCharacters { get; }
        string SuggestSelection { get; }
        string TabCompletion { get; }
        bool WordBasedSuggestions { get; }
    }
}