using System;
namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Provides quick suggestion options
    /// </summary>
    public class QuickSuggestionOptions
    {
        public QuickSuggestionOptions(): this(true)
        {
        }

        public QuickSuggestionOptions(bool value)
        {
            Other = Comments = Strings = value;
        }

        public bool Other { get; set; }
        public bool Comments { get; set; }
        public bool Strings { get; set; }
    }
}
