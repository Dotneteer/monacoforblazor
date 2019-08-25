namespace MonacoForBlazor.Api.Abstractions
{
    /// <summary>
    /// A selection in the editor.
    /// The selection is a range that has an orientation.
    /// </summary>
    public interface ISelection
    {
        /// <summary>
        /// The line number on which the selection has started.
        /// </summary>
        int SelectionStartLineNumber { get; }

        /// <summary>
        /// The column on `SelectionStartLineNumber` where the selection has started.
        /// </summary>
        int SelectionStartColumn { get; }

        /// <summary>
        /// The line number on which the selection has ended.
        /// </summary>
        int PositionLineNumber { get; }

        /// <summary>
        /// The column on `PositionLineNumber` where the selection has ended.
        /// </summary>
        int PositionColumn { get; }
    }
}
