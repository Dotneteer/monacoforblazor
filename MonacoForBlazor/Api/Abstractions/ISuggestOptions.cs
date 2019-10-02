using System.Collections.ObjectModel;

namespace MonacoForBlazor.Api.Abstractions
{
    public interface ISuggestOptions
    {
        ReadOnlyDictionary<string, bool> FilteredTypes { get; set; }
        bool FilterGraceful { get; set; }
        bool LocalityBonus { get; set; }
        int MaxVisibleSuggestions { get; set; }
        bool ShareSuggestSelections { get; set; }
        bool ShowIcons { get; set; }
        bool SnippetsPreventQuickSuggestions { get; set; }
    }
}