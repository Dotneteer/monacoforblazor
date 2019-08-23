using System.Collections.Generic;

namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Suggest options.
    /// </summary>
    public class SuggestOptions
    {
        /// <summary>
        /// Enable graceful matching. Defaults to true.
        /// </summary>
        public bool FilterGraceful { get; set; } = true;

        /// <summary>
        /// Prevent quick suggestions when a snippet is active. Defaults to true.
        /// </summary>        
        public bool SnippetsPreventQuickSuggestions { get; set; }

        /// <summary>
        /// Favours words that appear close to the cursor. Defaults to false.
        /// </summary>
        public bool LocalityBonus { get; set; } = false;

        /// <summary>
        /// Enable using global storage for remembering suggestions.
        /// Defaults to false.
        /// </summary>
        public bool ShareSuggestSelections { get; set; } = false;

        /// <summary>
        /// Enable or disable icons in suggestions. Defaults to true.
        /// </summary>        
        public bool ShowIcons { get; set; }

        /// <summary>
        /// Max suggestions to show in suggestions. Defaults to 12.
        /// </summary>
        public int MaxVisibleSuggestions { get; set; } = 12;

        /// <summary>
        /**
         * Names of suggestion types to filter.
         */
        /// </summary>
        public Dictionary<string, bool> FilteredTypes { get; set; }
    }
}
