namespace MonacoForBlazor.Api.Abstractions
{
    /// <summary>
    /// A position in the editor. This interface is suitable for serialization.
    /// </summary>
    public interface IPosition
    {
        /// <summary>
        /// line number (starts at 1)
        /// </summary>
        int LineNumber { get; }

        /// <summary>
        /// column (the first character in a line is between column 1 and column 2)
        /// </summary>
	    int Column { get; }
    }
}
