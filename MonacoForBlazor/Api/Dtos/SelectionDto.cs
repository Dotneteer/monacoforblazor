namespace MonacoForBlazor.Api.Dtos
{
    /// <summary>
    /// DTO class for Selection
    /// </summary>
    public class SelectionDto
    {
        /// <summary>
        /// The line number on which the selection has started.
        /// </summary>
        public int SelectionStartLineNumber { get; set; }

        /// <summary>
        /// The column on `SelectionStartLineNumber` where the selection has started.
        /// </summary>
        public int SelectionStartColumn { get; set; }

        /// <summary>
        /// The line number on which the selection has ended.
        /// </summary>
        public int PositionLineNumber { get; set; }

        /// <summary>
        /// The column on `PositionLineNumber` where the selection has ended.
        /// </summary>
        public int PositionColumn { get; set; }
    }
}
