using EventDriven.Console.Topics;
using EventDriven.Core.EventBus;

using System;

namespace EventDriven.Console.ConsoleTools
{
    public class EventConsole
    {
        private readonly EventBusAsync _bus;

        public TextWriter ConsoleOutput { get; set; }
        public TextReader ConsoleInput { get; set; }

        public EventConsole(EventBusAsync bus)
        {
            _bus = bus;
        }

        public async Task RunAsync()
        {
            ConsoleOutput.WriteLine("Event Console started. Type a command:");
            ConsoleOutput.WriteLine("Commands:");
            ConsoleOutput.WriteLine(" start, login_user, login_admin, settings, profile, help, logout, exit_app, exit_console");

            while (true)
            {
                ConsoleOutput.Write("> ");
                var input = ConsoleInput.ReadLine()?.Trim().ToLower();

                switch (input)
                {
                    case "start":
                        await _bus.PublishAsync(new ApplicationStart());
                        break;
                    case "login_user":
                        await _bus.PublishAsync(new LoginRequest());
                        await _bus.PublishAsync(new LoginSuccess("user"));
                        break;
                    case "login_admin":
                        await _bus.PublishAsync(new LoginRequest());
                        await _bus.PublishAsync(new LoginSuccess("admin"));
                        break;
                    case "settings":
                        await _bus.PublishAsync(new SettingsOpened());
                        break;
                    case "profile":
                        await _bus.PublishAsync(new ProfileViewed());
                        break;
                    case "help":
                        await _bus.PublishAsync(new HelpRequested());
                        break;
                    case "logout":
                        await _bus.PublishAsync(new LogoutRequest());
                        break;
                    case "exit_app":
                        await _bus.PublishAsync(new ApplicationExit());
                        break;
                    case "exit_console":
                        ConsoleOutput.WriteLine("Exiting Event Console.");
                        return;
                    default:
                        ConsoleOutput.WriteLine("Unknown command.");
                        break;
                }
            }
        }
    }
}