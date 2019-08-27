namespace MonacoForBlazor.Api.Dtos
{
    /// <summary>
    /// DTO for an IPosition
    /// </summary>
    public class PositionDto
    {
        /// <summary>
        /// line number (starts at 1)
        /// </summary>
        public int LineNumber { get; set; }

        /// <summary>
        /// column (the first character in a line is between column 1 and column 2)
        /// </summary>
	    public int Column { get; set; }
    }
}
