namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Configuration options for auto closing quotes and brackets
    /// </summary>
    public static class EditorAutoClosingStrategy
    {
        public const string Always = "always";
        public const string LanguageDefined = "languageDefined";
        public const string BeforeWhiteSpace = "beforeWhitespace";
        public const string Never = "never";
    }
}