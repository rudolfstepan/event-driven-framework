using EventDriven.Console;
using EventDriven.Console.ConsoleTools;
using EventDriven.Console.Simulation;
using EventDriven.Console.Topics;
using EventDriven.Core.EventBus;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _bus = new EventBusAsync();

            var _simulator = new EventSimulator(_bus);
            _simulator.ConsoleOutput = Console.Out;

            var _console = new EventConsole(_bus);
            _console.ConsoleInput = Console.In;
            _console.ConsoleOutput = Console.Out;

            _bus.SubscribeWithLogging<ApplicationStart>();
            _bus.SubscribeWithLogging<LoginRequest>();
            _bus.SubscribeWithLogging<LoginSuccess>(e => $"[Event Received] LoginSuccess for user: {e.Payload.Username}");
            _bus.SubscribeWithLogging<MainMenuReady>();
            _bus.SubscribeWithLogging<AdminMainMenuReady>();             
            _bus.SubscribeWithLogging<SettingsOpened>();
            _bus.SubscribeWithLogging<ProfileViewed>();
            _bus.SubscribeWithLogging<HelpRequested>();
            _bus.SubscribeWithLogging<LogoutRequest>();
            _bus.SubscribeWithLogging<ApplicationExit>();

            _console.RunAsync().GetAwaiter().GetResult();

            DemoRunner demoRunner = new DemoRunner(Console.Out, Console.In);

            demoRunner.RunAsync().GetAwaiter().GetResult();
        }
    }
}
