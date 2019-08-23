namespace MonacoForBlazor.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class GotoLocationOptions
    {
        /// <summary>
        /// Control how goto-command work when having multiple results.
        /// Available values: 'peek', 'gotAndPeek', 'goto'
        /// </summary>
        public string Multiple { get; set; }
    }
}
