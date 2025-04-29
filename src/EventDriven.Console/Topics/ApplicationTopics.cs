namespace EventDriven.Console.Topics
{
    public record AdminMainMenuReady;
    public record ApplicationStart;
    public record LoginRequest;
    public record LoginSuccess(string Username);
    public record MainMenuReady;
    public record ApplicationExit;
    public record SettingsOpened;
    public record ProfileViewed;
    public record LogoutRequest;
    public record HelpRequested;
}