namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Represents the parts of an URI
    /// </summary>
    public class UriComponents
    {
        public string Scheme { get; set; }
	    public string Authority { get; set; }
	    public string Path { get; set; }
	    public string Query { get; set; }
	    public string Fragment { get; set; }
    }
}
