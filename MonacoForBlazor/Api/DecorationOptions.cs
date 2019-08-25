namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Represents an abstract decoration option
    /// </summary>
    public abstract class DecorationOptions
    {
        /// <summary>
        /// Color to render
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Color to render in the theme registry
        /// </summary>
        public ThemeColor ThemeColor { get; set; }

        /// <summary>
        /// Dark color to render
        /// </summary>
        public string DarkColor { get; set; }

        /// <summary>
        /// Dark color to render in the theme registry
        /// </summary>
        public ThemeColor DarkThemeColor { get; set; }
    }
}
