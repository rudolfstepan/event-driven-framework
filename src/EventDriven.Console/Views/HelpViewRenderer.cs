using EventDriven.Console.Topics;

using EventDriven.Core.EventBus;

namespace EventDriven.Console.Views
{
    public class HelpViewRenderer
    {
        public TextWriter ConsoleOutput { get; set; }

        public HelpViewRenderer(EventBusAsync bus)
        {
            bus.Subscribe<HelpRequested>(OnHelpRequested);
        }

        private async Task<EventAcknowledge> OnHelpRequested(EventEnvelope<HelpRequested> envelope)
        {
            ConsoleOutput.WriteLine("Help view opened.");
            return EventAcknowledge.Handled;
        }
    }
}