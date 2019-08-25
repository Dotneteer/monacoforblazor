namespace MonacoForBlazor.Api.Abstractions
{
    /// <summary>
    /// A range in the editor. This interface is suitable for serialization.
    /// </summary>
    public interface IRange
    {
        /// <summary>
        /// Line number on which the range starts (starts at 1).
        /// </summary>
        int StartLineNumber { get; }

        /// <summary>
        /// Column on which the range starts in line `startLineNumber` (starts at 1).
        /// </summary>
        int StartColumn { get; }

        /// <summary>
        /// Line number on which the range ends.
        /// </summary>
        int EndLineNumber { get; }

        /// <summary>
        /// Column on which the range ends in line `endLineNumber`.
        /// </summary>
        int EndColumn { get; }
    }
}
