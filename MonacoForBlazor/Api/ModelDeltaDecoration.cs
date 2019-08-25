namespace MonacoForBlazor.Api
{
    /// <summary>
    /// New model decorations.
    /// </summary>
    public class ModelDeltaDecoration
    {
        /// <summary>
        /// Range that this decoration covers.
        /// </summary>
        public Range Range { get; set; }

        /// <summary>
        /// Options associated with this decoration.
        /// </summary>
        public ModelDecorationOptions Options { get; set; }
    }
}
