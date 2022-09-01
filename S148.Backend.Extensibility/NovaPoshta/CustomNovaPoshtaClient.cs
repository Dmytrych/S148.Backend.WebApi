using NovaPoshtaApi;

namespace S148.Backend.Extensibility.NovaPoshta;

public class CustomNovaPoshtaClient : ICustomNovaPoshtaClient
{
    public CustomNovaPoshtaClient(IApiConnection apiConnection, ILimitableAddressClient addressClient)
    {
        ApiConnection = apiConnection;
        Address = addressClient;
        Common = new CommonClient(ApiConnection);
        TrackingDocument = new TrackingDocumentClient(ApiConnection);
    }

    public IApiConnection ApiConnection { get; }

    public ILimitableAddressClient Address { get; }

    public ICommonClient Common { get; }

    public ITrackingDocumentClient TrackingDocument { get; }
}