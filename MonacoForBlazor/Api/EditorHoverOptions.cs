namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Configuration options for editor hover
    /// </summary>
    public class EditorHoverOptions
    {
        /// <summary>
        /// Enable the hover.
        /// Defaults to true.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Delay for showing the hover.
        /// Defaults to 300.
        /// </summary>
        public int Delay { get; set; } = 300;

        /// <summary>
        /// Is the hover sticky such that it can be clicked and its contents selected?
        /// Defaults to true.
        /// </summary>
        public bool Sticky { get; set; } = true;
    }
}
