namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Gets a visible position
    /// </summary>
    public class VisiblePosition
    {
        /// <summary>
        /// Top position
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// Left position
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// Position height
        /// </summary>
        public int Height { get; set; }

        public override string ToString() => $"({Top},{Left}):{Height}";
    }
}
