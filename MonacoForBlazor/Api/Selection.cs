using MonacoForBlazor.Api.Abstractions;
using MonacoForBlazor.Api.Enums;
using System;
using System.Collections.Generic;

namespace MonacoForBlazor.Api
{
    /// <summary>
    /// A selection in the editor.
    /// The selection is a range that has an orientation.
    /// </summary>
    public class Selection : Range,
        ISelection,
        IEquatable<Selection>
    {
        /// <summary>
        /// The line number on which the selection has started.
        /// </summary>
        public int SelectionStartLineNumber { get; }

        /// <summary>
        /// The column on `SelectionStartLineNumber` where the selection has started.
        /// </summary>
        public int SelectionStartColumn { get; }

        /// <summary>
        /// The line number on which the selection has ended.
        /// </summary>
        public int PositionLineNumber { get; }

        /// <summary>
        /// The column on `PositionLineNumber` where the selection has ended.
        /// </summary>
        public int PositionColumn { get; }

        /// <summary>
        /// A selection in the editor.
        /// </summary>
        public Selection(int selectionStartLineNumber,
            int selectionStartColumn,
            int positionLineNumber,
            int positionColumn) : base(selectionStartLineNumber,
                selectionStartColumn,
                positionLineNumber,
                positionColumn)
        {
            SelectionStartLineNumber = selectionStartLineNumber;
            SelectionStartColumn = selectionStartColumn;
            PositionLineNumber = positionLineNumber;
            PositionColumn = positionColumn;
        }

        /// <summary>
        /// Clone this selection.
        /// </summary>
        public Selection Clone()
            => new Selection(SelectionStartLineNumber,
                SelectionStartColumn,
                PositionLineNumber,
                PositionColumn);

        /// <summary>
        /// Transform to a human-readable representation.
        /// </summary>
        public override string ToString()
            => $"[{SelectionStartLineNumber},{SelectionStartColumn} -> {PositionLineNumber},{PositionColumn}]";

        /// <summary>
        /// Test if equals other selection. 
        /// </summary>
        /// <param name="other">Other selection</param>
        /// <returns></returns>
        public bool Equals(Selection other)
            => Equals(this, other);

        /// <summary>
        /// Test if the two selections are equal.
        /// </summary>
        /// <param name="a">Selection `a`</param>
        /// <param name="a">Selection `b`</param>
        public static bool Equals(ISelection a, ISelection b)
            => a.SelectionStartLineNumber == b.SelectionStartLineNumber &&
                a.SelectionStartColumn == b.SelectionStartColumn &&
                a.PositionLineNumber == b.PositionLineNumber &&
                a.PositionColumn == b.PositionColumn;


        /// <summary>
        /// Get directions (LTR or RTL).
        /// </summary>
        public SelectionDirection GetDirection()
            => SelectionStartLineNumber == StartLineNumber && SelectionStartColumn == StartColumn
                ? SelectionDirection.LTR
                : SelectionDirection.RTL;

        /// <summary>
        /// Create a new selection with a different `positionLineNumber` and `positionColumn`.
        /// </summary>
        /// <param name="endLineNumber">New end line number</param>
        /// <param name="endColumn">New end column</param>
        public new Selection SetEndPosition(int endLineNumber, int endColumn)
            => GetDirection() == SelectionDirection.LTR
                ? new Selection(StartLineNumber, StartColumn, EndLineNumber, EndColumn)
                : new Selection(endLineNumber, endColumn, StartLineNumber, StartColumn);

        /// <summary>
        /// Get the position at `positionLineNumber` and `positionColumn`.
        /// </summary>
        public Position GetPosition()
            => new Position(PositionLineNumber, PositionColumn);

        /// <summary>
        /// Create a new selection with a different `selectionStartLineNumber` and `selectionStartColumn`.
        /// </summary>
        public new Selection SetStartPosition(int startLineNumber, int startColumn)
            => GetDirection() == SelectionDirection.LTR
                ? new Selection(startLineNumber, startColumn, EndLineNumber, EndColumn)
                : new Selection(EndLineNumber, EndColumn, startLineNumber, startColumn);

        /// <summary>
        /// Create a `Selection` from one or two positions
        /// </summary>
        public new static Selection FromPositions(IPosition start, IPosition end = null)
        {
            if (end == null) end = start;
            return new Selection(start.LineNumber, start.Column, end.LineNumber, end.Column);
        }

        /// <summary>
        /// Create a `Selection` from an `ISelection`.
        /// </summary>
        public static Selection LiftSelection(ISelection sel)
            => new Selection(sel.SelectionStartLineNumber,
                sel.SelectionStartColumn,
                sel.PositionLineNumber,
                sel.PositionColumn);

        /// <summary>
        /// Selection array `a` equals selection array `b`.
        /// </summary>
        public static bool SelectionsArrEqual(IList<ISelection> a, IList<ISelection> b)
        {
            if (a == null && b != null || a != null && b == null)
            {
                return false;
            }
            if (a == null && b == null)
            {
                return true;
            }
            if (a.Count != b.Count)
            {
                return false;
            }
            for (var i = 0; i < a.Count; i++)
            {
                if (!Equals(a[i], b[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Create with a direction.
        /// </summary>
        public static Selection CreateWithDirection(int startLineNumber,
            int startColumn,
            int endLineNumber,
            int endColumn,
            SelectionDirection direction)
            => direction == SelectionDirection.LTR
                ? new Selection(startLineNumber, startColumn, endLineNumber, endColumn)
                : new Selection(endLineNumber, endColumn, startLineNumber, startColumn);
    }
}