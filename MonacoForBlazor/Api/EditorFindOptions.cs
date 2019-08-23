namespace MonacoForBlazor.Api
{

    /// <summary>
    /// Configuration options for editor find widget
    /// </summary>
    public class EditorFindOptions
    {
        /// <summary>
        /// Controls if we seed search string in the Find Widget with editor selection.
        /// Defaults to true.
        /// </summary>
        public bool SeedSearchStringFromSelection { get; set; } = true;

        /// <summary>
        /// Controls if Find in Selection flag is turned on when multiple lines of text are 
        /// selected in the editor. Defaults to false.
        /// </summary>
        public bool AutoFindInSelection { get; set; } = false;

        /// <summary>
        /// Signs if extra space should be added on the top of the widget.
        /// Defaults to true.
        /// </summary>
        public bool AddExtraSpaceOnTop { get; set; } = true;
    }
}
