using SampleMauiApp.Topics;

namespace SampleMauiApp.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        _ = App.EventBus.PublishAsync(new NavigateBackRequested());
        return true; // Wir haben das Back-Handling selbst übernommen
    }

}