namespace HydraBot.Domain
{
    /// <summary>
    /// Represents a binary download location
    /// </summary>
    public class BinaryPointer : IAssetPointer
    {
        public string Uri { get; set; }
        public BinaryPointer(string uri)
        {
            Uri = uri;
        }
    }
}
