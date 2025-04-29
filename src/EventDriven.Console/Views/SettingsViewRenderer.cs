using EventDriven.Console.Topics;

using EventDriven.Core.EventBus;

namespace EventDriven.Console.Views
{
    public class SettingsViewRenderer
    {
        public TextWriter ConsoleOutput { get; set; }


        public SettingsViewRenderer(EventBusAsync bus)
        {
            bus.Subscribe<SettingsOpened>(OnSettingsOpened);
        }

        private async Task<EventAcknowledge> OnSettingsOpened(EventEnvelope<SettingsOpened> envelope)
        {
            ConsoleOutput.WriteLine("Settings view opened.");
            return EventAcknowledge.Handled;
        }
    }
}