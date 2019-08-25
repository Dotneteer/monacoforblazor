using MonacoForBlazor.Api.Abstractions;
using System;

namespace MonacoForBlazor.Api
{
    /// <summary>
    /// A position in the editor.
    /// </summary>
    public class Position : IPosition, 
        IEquatable<IPosition>,
        IComparable<IPosition>
    {
        /// <summary>
        /// line number (starts at 1)
        /// </summary>
        public int LineNumber { get; }

        /// <summary>
        /// column (the first character in a line is between column 1 and column 2)
        /// </summary>
	    public int Column { get; }

        /// <summary>
        /// Initiazlizes the position
        /// </summary>
        /// <param name="lineNumber">Line number</param>
        /// <param name="column">Column information</param>
        public Position(int lineNumber, int column)
        {
            LineNumber = lineNumber;
            Column = column;
        }

        /// <summary>
        /// Create a new position from this position.
        /// </summary>
        /// <param name="newLineNumber">New line number</param>
        /// <param name="newColumn">New column</param>
        public Position With(int? newLineNumber = null, int? newColumn = null)
        {
            if (newLineNumber == null) newLineNumber = LineNumber;
            if (newColumn == null) newColumn = Column;
            return newLineNumber == LineNumber && newColumn == Column 
                ? (this) 
                : new Position(newLineNumber.Value, newColumn.Value);
        }

        /// <summary>
        /// Derive a new position from this position.
        /// </summary>
        /// <param name="deltaLineNumber">Line number delta</param>
        /// <param name="deltaColumn">Column delta</param>
        public Position Delta(int deltaLineNumber = 0, int deltaColumn = 0) 
            => With(LineNumber + deltaLineNumber, Column + deltaColumn);

        /// <summary>
        /// Test if this position equals other position
        /// </summary>
        /// <param name="other">Other position</param>
        /// <returns>True, if positions are equal; otherwise, false</returns>
        public bool Equals(IPosition other)
            => Equals(this, other);


        /// <summary>
        /// Test if position `a` equals position `b`
        /// </summary>
        /// <param name="a">Position `a`</param>
        /// <param name="b">Position `b`</param>
        public static bool Equals(IPosition a, IPosition b) 
            => a == null && b == null
                ? true
                : a != null &&
                    b != null &&
                    a.LineNumber == b.LineNumber &&
                    a.Column == b.Column;

        /// <summary>
        /// Test if this position is before other position.
        /// </summary>
        /// <param name="other">Other position</param>
        /// <return>
        /// If the two positions are equal, the result will be false.
        /// </return>
        public bool IsBefore(IPosition other) 
            => IsBefore(this, other);

        /// <summary>
        /// Test if position `a` is before position `b`.
        /// </summary>
        /// <param name="a">Position `a`</param>
        /// <param name="b">Position `b`</param>
        /// <return>
        /// If the two positions are equal, the result will be false.
        /// </return>
        public static bool IsBefore(IPosition a, IPosition b) 
        {
            if (a == null || b == null) return false;
            if (a.LineNumber < b.LineNumber) return true;
            if (b.LineNumber < a.LineNumber) return false;
            return a.Column < b.Column;
        }

        /// <summary>
        /// Test if this position is before other position.
        /// </summary>
        /// <param name="other">Other position</param>
        /// <return>
        /// If the two positions are equal, the result will be false.
        /// </return>
        public bool IsBeforeOrEqual(IPosition other)
            => IsBeforeOrEqual(this, other);

        /// <summary>
        /// A position in the editor.
        /// </summary>
        /// <remarks>
        /// If the two positions are equal, the result will be true.
        /// </remarks>
        public static bool IsBeforeOrEqual(IPosition a, IPosition b)
        {
            if (a == null || b == null) return false;
		    if (a.LineNumber < b.LineNumber) return true;
    		if (b.LineNumber < a.LineNumber) return false;
    		return a.Column <= b.Column;
	    }

        public int CompareTo(IPosition other)
            => Compare(this, other);

        /// <summary>
        /// A function that compares positions, useful for sorting
        /// </summary>
        /// <param name="a">Position `a`</param>
        /// <param name="b">Position `b`</param>
        public static int Compare(IPosition a, IPosition b) {

		    var aLineNumber = a?.LineNumber ?? 0;
            var bLineNumber = b?.LineNumber ?? 0;
    		if (aLineNumber == bLineNumber) 
            {
			    var aColumn = a?.Column ?? 0;
                var bColumn = b?.Column ?? 0;
			    return aColumn - bColumn;
		    }
    		return aLineNumber - bLineNumber;
	    }

        /// <summary>
        /// Clone this position.
        /// </summary>
        public Position Clone() => new Position(LineNumber, Column);

        /// <summary>
        /// A position in the editor.
        /// </summary>
        /**
         * Convert to a human-readable representation.
         */
        public override string ToString() => $"({LineNumber},{Column})";

        /// <summary>
        /// Create a `Position` from an `IPosition`.
        /// </summary>
        public static Position Lift(IPosition pos)
            => new Position(pos.LineNumber, pos.Column);
	}
}