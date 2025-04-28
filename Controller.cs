using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly TelemetryClient _telemetryClient;

    public HomeController(TelemetryClient telemetryClient)
    {
        _telemetryClient = telemetryClient;
    }

    public IActionResult Index()
    {
        // Start the operation to track response time
        var operation = _telemetryClient.StartOperation<RequestTelemetry>("HomeController.Index");

        try
        {
            // Simulate some business logic
            System.Threading.Thread.Sleep(500); // Simulate delay (500ms)

            _telemetryClient.TrackEvent("IndexPageLoaded"); // Track custom event

            return View();
        }
        catch (Exception ex)
        {
            _telemetryClient.TrackException(ex); // Track exception
            throw;
        }
        finally
        {
            _telemetryClient.StopOperation(operation); // Stop the operation
        }
    }
}
