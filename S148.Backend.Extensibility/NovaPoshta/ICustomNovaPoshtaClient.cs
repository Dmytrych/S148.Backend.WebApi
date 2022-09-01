using NovaPoshtaApi;

namespace S148.Backend.Extensibility.NovaPoshta;

public interface ICustomNovaPoshtaClient
{
    IApiConnection ApiConnection { get; }
    
    ILimitableAddressClient Address { get; }

    ICommonClient Common { get; }

    ITrackingDocumentClient TrackingDocument { get; }
}