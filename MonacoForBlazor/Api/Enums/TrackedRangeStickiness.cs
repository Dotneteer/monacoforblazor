namespace MonacoForBlazor.Api.Enums
{
    /// <summary>
    /// Describes the behavior of decorations when typing/editing near their edges. 
    /// Note: Please do not edit the values, as they very carefully match DecorationRangeBehavior
    /// </summary>
    public enum TrackedRangeStickiness
    {
        AlwaysGrowsWhenTypingAtEdges = 0,
        NeverGrowsWhenTypingAtEdges = 1,
        GrowsOnlyWhenTypingBefore = 2,
        GrowsOnlyWhenTypingAfter = 3
    }
}
