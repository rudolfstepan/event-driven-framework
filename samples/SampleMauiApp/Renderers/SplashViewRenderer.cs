
using SampleMauiApp.Topics;

using SampleMauiApp.Views;

using EventDriven.Core.EventBus;

namespace SampleMauiApp.Renderers;

public class SplashViewRenderer
{
    public SplashViewRenderer()
    {
        App.EventBus.Subscribe<ApplicationStart>(OnApplicationStart);
    }

    private async Task<EventAcknowledge> OnApplicationStart(EventEnvelope<ApplicationStart> envelope)
    {
        Console.WriteLine("[Splash] Showing Splash Screen...");
        await NavigationHelper.SafeNavigateToAsync(nameof(SplashPage));

        await Task.Delay(3000); // wait 3 seconds
        await App.EventBus.PublishAsync(new SplashCompleted());

        return EventAcknowledge.Handled;
    }
}