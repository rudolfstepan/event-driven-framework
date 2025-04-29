
using EventDriven.Core.EventBus;

using SampleMauiApp.Topics;

namespace SampleMauiApp.Renderers;

public class SettingsViewRenderer
{
    public SettingsViewRenderer()
    {
        App.EventBus.Subscribe<SettingsOpened>(OnSettingsOpened);
    }

    private async Task<EventAcknowledge> OnSettingsOpened(EventEnvelope<SettingsOpened> envelope)
    {
        Console.WriteLine("[Settings] Showing Settings Page...");
        await NavigationHelper.SafeNavigateToAsync(nameof(Views.SettingsPage));
        return EventAcknowledge.Handled;
    }
}