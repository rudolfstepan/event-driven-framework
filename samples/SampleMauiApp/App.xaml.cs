
using SampleMauiApp.Topics;

using SampleMauiApp.Renderers;

using Microsoft.Maui.Controls.Handlers.Compatibility;
using EventDriven.Core.EventBus;

namespace SampleMauiApp;

public partial class App : Application
{
    public static EventBusAsync EventBus = new();

    public App()
    {
        InitializeComponent();

        // Starte Event-Initialisierung erst nach kurzem Delay!
        _ = Task.Run(async () =>
        {
            await Task.Delay(200); // Warten bis Shell aktiv ist
            InitializeEventSystem();
            RegisterViews();
            await EventBus.PublishAsync(new ApplicationStart());
        });
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = new Window(new AppShell());
        return window;
    }

    private void InitializeEventSystem()
    {
        //EventBus.SubscribeWithLogging<ApplicationStart>();
        //EventBus.SubscribeWithLogging<SplashCompleted>();
        //EventBus.SubscribeWithLogging<LoginRequest>();
        //EventBus.SubscribeWithLogging<LoginSuccess>(e => $"[Event Received] LoginSuccess for user: {e.Payload.Username}");
        //EventBus.SubscribeWithLogging<MainMenuReady>();
        //EventBus.SubscribeWithLogging<SettingsOpened>();
        //EventBus.SubscribeWithLogging<ProfileViewed>();
        //EventBus.SubscribeWithLogging<LogoutRequest>();
        //EventBus.SubscribeWithLogging<ApplicationExit>();
    }

    private void RegisterViews()
    {
        new SplashViewRenderer();
        new LoginViewRenderer();
        new MainMenuViewRenderer();
        new SettingsViewRenderer();
        new ProfileViewRenderer();
    }
}