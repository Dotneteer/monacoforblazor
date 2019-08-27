using MonacoForBlazor.Api.Abstractions;
using System.Collections.Generic;

namespace MonacoForBlazor.Api
{
    public class EditorContribOptions : IEditorContribOptions
    {
        public bool SelectionClipboard { get; set; }
        public EditorHoverOptions Hover { get; set; }
        public bool Links { get; set; }
        public bool Contextmenu { get; set; }
        public bool? QuickSuggestions { get; set; }
        public QuickSuggestionOptions QuickSuggestionOptions { get; set; }
        public int QuickSuggestionsDelay { get; set; }
        public EditorParameterHintOptions ParameterHints { get; set; }
        public bool FormatOnType { get; set; }
        public bool FormatOnPaste { get; set; }
        public bool SuggestOnTriggerCharacters { get; set; }
        public string AcceptSuggestionOnEnter { get; set; }
        public bool AcceptSuggestionOnCommitCharacter { get; set; }
        public bool WordBasedSuggestions { get; set; }
        public string SuggestSelection { get; set; }
        public double SuggestFontSize { get; set; }
        public int SuggestLineHeight { get; set; }
        public string TabCompletion { get; set; }
        public SuggestOptions Suggest { get; set; }
        public GoToLocationOptions GotoLocation { get; set; }
        public bool SelectionHighlight { get; set; }
        public bool OccurrencesHighlight { get; set; }
        public bool CodeLens { get; set; }
        public bool Folding { get; set; }
        public string FoldingStrategy { get; set; }
        public string ShowFoldingControls { get; set; }
        public bool MatchBrackets { get; set; }
        public EditorFindOptions Find { get; set; }
        public bool ColorDecorators { get; set; }
        public bool LightbulbEnabled { get; set; }
        public Dictionary<string, bool> CodeActionsOnSave { get; set; }
        public int CodeActionsOnSaveTimeout { get; set; }
    }
}
