using MonacoForBlazor.Api.Abstractions;
using System;

namespace MonacoForBlazor.Api
{
    /// <summary>
    /// A range in the editor. (startLineNumber,startColumn) is <= (endLineNumber,endColumn)
    /// </summary>
    public class Range : IRange, IEquatable<IRange>
    {
        /// <summary>
        /// Line number on which the range starts (starts at 1).
        /// </summary>
        public int StartLineNumber { get; }

        /// <summary>
        /// Column on which the range starts in line `startLineNumber` (starts at 1).
        /// </summary>
        public int StartColumn { get; }

        /// <summary>
        /// Line number on which the range ends.
        /// </summary>
        public int EndLineNumber { get; }

        /// <summary>
        /// Column on which the range ends in line `endLineNumber`.
        /// </summary>
        public int EndColumn { get; }

        public Range(int startLineNumber, int startColumn, int endLineNumber, int endColumn)
        {
            if ((startLineNumber > endLineNumber) || (startLineNumber == endLineNumber && startColumn > endColumn))
            {
                StartLineNumber = endLineNumber;
                StartColumn = endColumn;
                EndLineNumber = startLineNumber;
                EndColumn = startColumn;
            }
            else
            {
                StartLineNumber = startLineNumber;
                StartColumn = startColumn;
                EndLineNumber = endLineNumber;
                EndColumn = endColumn;
            }
        }

        /// <summary>
        /// Test if this range is empty.
        /// </summary>
        public bool IsEmpty() => IsEmpty(this);

        /// <summary>
        /// Test if the specified range is empty.
        /// </summary>
        public static bool IsEmpty(IRange range)
            => (range?.StartLineNumber ?? 0) == range.EndLineNumber
                && (range?.StartColumn ?? 0) == range.EndColumn;

        /// <summary>
        /// Test if position is in this range. If the position is at the edges, will return true.
        /// </summary>
        /// <param name="position">Position to test</param>
        public bool ContainsPosition(IPosition position)
            => ContainsPosition(this, position);

        /// <summary>
        /// Test if `position` is in `range`. If the position is at the edges, will return true.
        /// </summary>
        /// <param name="range">Range in which to test the position</param>
        /// <param name="position">Position to test</param>
        public static bool ContainsPosition(IRange range, IPosition position)
        {
            if (range == null || position == null) return false;
            if (position.LineNumber < range.StartLineNumber
                || position.LineNumber > range.EndLineNumber)
            {
                return false;
            }
            if (position.LineNumber == range.StartLineNumber
                && position.Column < range.StartColumn)
            {
                return false;
            }
            return position.LineNumber != range.EndLineNumber
                || position.Column <= range.EndColumn;
        }

        /// <summary>
        /// Test if range is in this range. If the range is equal to this range, will return true.
        /// </summary>
        /// <param name="range">Range to check</param>
        public bool ContainsRange(IRange range)
            => ContainsRange(this, range);

        /// <summary>
        /// Test if `otherRange` is in `range`. If the ranges are equal, will return true.
        /// </summary>
        /// <param name="range">Range in wich to check</param>
        /// <param name="otherRange">Range to check</param>
        public static bool ContainsRange(IRange range, IRange otherRange)
        {
            if (range == null || otherRange == null) return false;
            if (otherRange.StartLineNumber < range.StartLineNumber
                || otherRange.EndLineNumber < range.StartLineNumber)
            {
                return false;
            }
            if (otherRange.StartLineNumber > range.EndLineNumber
                || otherRange.EndLineNumber > range.EndLineNumber)
            {
                return false;
            }
            if (otherRange.StartLineNumber == range.StartLineNumber
                && otherRange.StartColumn < range.StartColumn)
            {
                return false;
            }
            return otherRange.EndLineNumber != range.EndLineNumber
                || otherRange.EndColumn <= range.EndColumn;
        }

        /// <summary>
        /// Test if `range` is strictly in this range. `range` must start after
        /// and end before this range for the result to be true.
        /// </summary>
        /// <param name="range">Range to check</param>
        public bool StrictContainsRange(IRange range)
            => StrictContainsRange(this, range);

        /// <summary>
        /// Test if `otherRange` is strinctly in `range` (must start after, and end before).
        /// If the ranges are equal, will return false.
        /// </summary>
        /// <param name="range">Range in wich to check</param>
        /// <param name="otherRange">Range to check</param>
        public static bool StrictContainsRange(IRange range, IRange otherRange)
        {
            if (range == null || otherRange == null) return false;
            if (otherRange.StartLineNumber < range.StartLineNumber
                || otherRange.EndLineNumber < range.StartLineNumber)
            {
                return false;
            }
            if (otherRange.StartLineNumber > range.EndLineNumber
                || otherRange.EndLineNumber > range.EndLineNumber)
            {
                return false;
            }
            if (otherRange.StartLineNumber == range.StartLineNumber
                && otherRange.StartColumn <= range.StartColumn)
            {
                return false;
            }
            return otherRange.EndLineNumber != range.EndLineNumber
                || otherRange.EndColumn < range.EndColumn;
        }

        /// <summary>
        /// A reunion of the two ranges. The smallest position will be used as the start 
        /// point, and the largest one as the end point.
        /// </summary>
        /// <param name="range">Range to unite</param>
        public Range PlusRange(IRange range)
            => PlusRange(this, range);

        /// <summary>
        /// A reunion of the two ranges. The smallest position will be used as the start 
        /// point, and the largest one as the end point.
        /// </summary>
        /// <param name="a">Range `a`</param>
        /// <param name="b">Range `b`</param>
        public static Range PlusRange(IRange a, IRange b)
        {
            if (a == null || b == null) return null;
            int startLineNumber;
            int startColumn;
            int endLineNumber;
            int endColumn;

            if (b.StartLineNumber < a.StartLineNumber)
            {
                startLineNumber = b.StartLineNumber;
                startColumn = b.StartColumn;
            }
            else if (b.StartLineNumber == a.StartLineNumber)
            {
                startLineNumber = b.StartLineNumber;
                startColumn = Math.Min(b.StartColumn, a.StartColumn);
            }
            else
            {
                startLineNumber = a.StartLineNumber;
                startColumn = a.StartColumn;
            }

            if (b.EndLineNumber > a.EndLineNumber)
            {
                endLineNumber = b.EndLineNumber;
                endColumn = b.EndColumn;
            }
            else if (b.EndLineNumber == a.EndLineNumber)
            {
                endLineNumber = b.EndLineNumber;
                endColumn = Math.Max(b.EndColumn, a.EndColumn);
            }
            else
            {
                endLineNumber = a.EndLineNumber;
                endColumn = a.EndColumn;
            }
            return new Range(startLineNumber, startColumn, endLineNumber, endColumn);
        }

        /// <summary>
        /// A intersection of the two ranges.
        /// </summary>
        /// <param name="range">Range to use</param>
        public Range IntersectRanges(IRange range)
            => IntersectRanges(this, range);

        /// <summary>
        /// A intersection of the two ranges.
        /// </summary>
        /// <param name="a">Range `a`</param>
        /// <param name="b">Range `b`</param>
        public static Range IntersectRanges(IRange a, IRange b)
        {
            var resultStartLineNumber = a.StartLineNumber;
            var resultStartColumn = a.StartColumn;
            var resultEndLineNumber = a.EndLineNumber;
            var resultEndColumn = a.EndColumn;
            var otherStartLineNumber = b.StartLineNumber;
            var otherStartColumn = b.StartColumn;
            var otherEndLineNumber = b.EndLineNumber;
            var otherEndColumn = b.EndColumn;

            if (resultStartLineNumber < otherStartLineNumber)
            {
                resultStartLineNumber = otherStartLineNumber;
                resultStartColumn = otherStartColumn;
            }
            else if (resultStartLineNumber == otherStartLineNumber)
            {
                resultStartColumn = Math.Max(resultStartColumn, otherStartColumn);
            }

            if (resultEndLineNumber > otherEndLineNumber)
            {
                resultEndLineNumber = otherEndLineNumber;
                resultEndColumn = otherEndColumn;
            }
            else if (resultEndLineNumber == otherEndLineNumber)
            {
                resultEndColumn = Math.Min(resultEndColumn, otherEndColumn);
            }

            // --- Check if selection is now empty
            if (resultStartLineNumber > resultEndLineNumber)
            {
                return null;
            }
            if (resultStartLineNumber == resultEndLineNumber
                && resultStartColumn > resultEndColumn)
            {
                return null;
            }
            return new Range(resultStartLineNumber, resultStartColumn, resultEndLineNumber, resultEndColumn);
        }

        /// <summary>
        /// Test if this range equals other.
        /// </summary>
        /// <param name="other">Other range</param>
        /// <returns>True, if ranges are equal; otherwise, false.</returns>
        public bool Equals(IRange other)
            => Equals(this, other);

        /// <summary>
        /// Test if range `a` equals `b`.
        /// </summary>
        /// <param name="a">Range `a`</param>
        /// <param name="b">Range `b`</param>
        public static bool Equals(IRange a, IRange b)
        {
            return
                a != null &&
                b != null &&
                a.StartLineNumber == b.StartLineNumber &&
                a.StartColumn == b.StartColumn &&
                a.EndLineNumber == b.EndLineNumber &&
                a.EndColumn == b.EndColumn;
        }

        /// <summary>
        /// Return the end position (which will be after or equal to the start position)
        /// </summary>
        public Position GetEndPosition()
            => new Position(EndLineNumber, EndColumn);

        /// <summary>
        /// Return the start position (which will be before or equal to the end position)
        /// </summary>
        public Position GetStartPosition()
            => new Position(StartLineNumber, StartColumn);

        /// <summary>
        /// Transform to a user presentable string representation.
        /// </summary>
        public override string ToString()
            => $"[{StartLineNumber},{StartColumn} -> {EndLineNumber},{EndColumn}]";

        /// <summary>
        /// Create a new range using this range's start position, and using 
        /// endLineNumber and endColumn as the end position.
        /// </summary>
        /// <param name="endLineNumber">New end line number</param>
        /// <param name="endColumn">New end column</param>
        public Range SetEndPosition(int endLineNumber, int endColumn)
            => new Range(StartLineNumber, StartColumn, endLineNumber, endColumn);

        /// <summary>
        /// Create a new range using this range's end position, and using 
        /// startLineNumber and startColumn as the start position.
        /// </summary>
        /// <param name="startLineNumber">New line number</param>
        /// <param name="startColumn">New start column</param>
        public Range SetStartPosition(int startLineNumber, int startColumn)
            => new Range(startLineNumber, startColumn, EndLineNumber, EndColumn);

        /// <summary>
        /// Create a new empty range using this range's start position.
        /// </summary>
        public Range CollapseToStart()
            => CollapseToStart(this);

        /// <summary>
        /// Create a new empty range using this range's start position.
        /// </summary>
        /// <param name="range">Range to use</param>
        public static Range CollapseToStart(IRange range)
            => new Range(range.StartLineNumber, range.StartColumn,
                range.StartLineNumber, range.StartColumn);

        /// <summary>
        /// Create a new range from the specified positions
        /// </summary>
        public static Range FromPositions(IPosition start, IPosition end = null)
        {
            if (end == null) end = start;
            return new Range(start.LineNumber, start.Column, end.LineNumber, end.Column);
        }

        /// <summary>
        /// Create a `Range` from an `IRange`.
        /// </summary>
        /// <param name="range">IRange value to lift</param>
        public static Range Lift(IRange range)
            => range == null
                ? null
                : new Range(range.StartLineNumber, range.StartColumn,
                range.EndLineNumber, range.EndColumn);

        /// <summary>
        /// Test if the two ranges are touching in any way.
        /// </summary>
        public static bool AreIntersectingOrTouching(IRange a, IRange b)
        {
            // --- Check if `a` is before `b`
            if (a.EndLineNumber < b.StartLineNumber
                || (a.EndLineNumber == b.StartLineNumber && a.EndColumn < b.StartColumn))
            {
                return false;
            }

            // --- Check if `b` is before `a`
            if (b.EndLineNumber < a.StartLineNumber
                || (b.EndLineNumber == a.StartLineNumber && b.EndColumn < a.StartColumn))
            {
                return false;
            }
            // --- These ranges must intersect
            return true;
        }

        /// <summary>
        /// Test if the two ranges are intersecting in any way.
        /// </summary>
        /// <param name="a">Range `a`</param>
        /// <param name="b">Range `b`</param>
        public static bool AreIntersecting(IRange a, IRange b)
        {
            // --- Check if `a` is before `b`
            if (a.EndLineNumber < b.StartLineNumber
                || (a.EndLineNumber == b.StartLineNumber && a.EndColumn <= b.StartColumn))
            {
                return false;
            }

            // --- Check if `b` is before `a`
            if (b.EndLineNumber < a.StartLineNumber
                || (b.EndLineNumber == a.StartLineNumber && b.EndColumn <= a.StartColumn))
            {
                return false;
            }

            // --- These ranges must intersect
            return true;
        }

        /// <summary>
        /// A function that compares ranges, useful for sorting ranges
	    /// It will first compare ranges on the startPosition and then on the endPosition
        /// </summary>
        /// <param name="a">Range `a`</param>
        /// <param name="b">Range `b`</param>
        public static int CompareRangesUsingStarts(IRange a, IRange b)
        {
            if (a == null || b == null)
            {
                var aExists = (a == null ? 1 : 0);
                var bExists = (b == null ? 1 : 0);
                return aExists - bExists;
            }
            if (a.StartLineNumber == b.StartLineNumber)
            {
                if (a.StartColumn == b.StartColumn)
                {
                    if (a.EndLineNumber == b.EndLineNumber)
                    {
                        return a.EndColumn - b.EndColumn;
                    }
                    return a.EndLineNumber - b.EndLineNumber;
                }
                return a.StartColumn - b.StartColumn;
            }
            return a.StartLineNumber - b.StartLineNumber;
        }

        /// <summary>
        /// A function that compares ranges, useful for sorting ranges
        /// It will first compare ranges on the endPosition and then on the startPosition
        /// </summary>
        /// <param name="a">Range `a`</param>
        /// <param name="b">Range `b`</param>
        public static int CompareRangesUsingEnds(IRange a, IRange b)
        {
            if (a == null || b == null)
            {
                var aExists = (a == null ? 1 : 0);
                var bExists = (b == null ? 1 : 0);
                return aExists - bExists;
            }
            if (a.EndLineNumber == b.EndLineNumber)
            {
                if (a.EndColumn == b.EndColumn)
                {
                    if (a.StartLineNumber == b.StartLineNumber)
                    {
                        return a.StartColumn - b.StartColumn;
                    }
                    return a.StartLineNumber - b.StartLineNumber;
                }
                return a.EndColumn - b.EndColumn;
            }
            return a.EndLineNumber - b.EndLineNumber;
        }

        /// <summary>
        /// Test if the range spans multiple lines.
        /// </summary>
        /// <param name="range">Range to check</param>
        public static bool SpansMultipleLines(IRange range)
            => range.EndLineNumber > range.StartLineNumber;
    }
}
