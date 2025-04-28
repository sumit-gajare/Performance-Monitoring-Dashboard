public class Service
{
    private readonly TelemetryClient _telemetryClient;

    public SomeService(TelemetryClient telemetryClient)
    {
        _telemetryClient = telemetryClient;
    }

    public void Process()
    {
        _telemetryClient.TrackEvent("ProcessStarted");

        try
        {
            // Process logic here
        }
        catch (Exception ex)
        {
            _telemetryClient.TrackException(ex);
            throw;
        }

        _telemetryClient.TrackEvent("ProcessCompleted");
    }
}
