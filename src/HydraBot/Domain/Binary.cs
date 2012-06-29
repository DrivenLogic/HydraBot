namespace HydraBot.Domain
{
    /// <summary>
    /// Represents a binary download location
    /// </summary>
    public struct Binary : IAssetPointer
    {
        public string Uri { get; set; }
    }
}
