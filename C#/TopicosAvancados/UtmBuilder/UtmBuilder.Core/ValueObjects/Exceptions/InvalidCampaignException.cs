namespace UtmBuilder.Core.ValueObjects.Exceptions;

public partial class InvalidCampaignException : Exception {
    
    private const string DefaultMessage = "Invalid UTM Parameters";

    public InvalidCampaignException(string message) : base(message) {
    }

    public static void ThrowIfNull(string? item, string message = DefaultMessage) {
        if (string.IsNullOrEmpty(item)) {
            throw new InvalidCampaignException(message);
        }

    }
}