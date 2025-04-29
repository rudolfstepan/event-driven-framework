using EventDriven.Console.Topics;

using EventDriven.Core.EventBus;

namespace EventDriven.Console.Views
{
    public class AdminMainMenuViewRenderer
    {
        private readonly EventBusAsync _bus;

        public TextWriter ConsoleOutput { get; set; }

        public AdminMainMenuViewRenderer(EventBusAsync bus)
        {
            _bus = bus;
            _bus.Subscribe<AdminMainMenuReady>(OnAdminMainMenuReady);
        }

        private async Task<EventAcknowledge> OnAdminMainMenuReady(EventEnvelope<AdminMainMenuReady> envelope)
        {
            ConsoleOutput.WriteLine("AdminMainMenu: Welcome, Admin User!");
            return EventAcknowledge.Handled;
        }
    }
}