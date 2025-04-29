using EventDriven.Console.Topics;

using EventDriven.Core.EventBus;

namespace EventDriven.Console.Views
{
    public class ProfileViewRenderer
    {
        public TextWriter ConsoleOutput { get; set; }

        public ProfileViewRenderer(EventBusAsync bus)
        {
            bus.Subscribe<ProfileViewed>(OnProfileViewed);
        }

        private async Task<EventAcknowledge> OnProfileViewed(EventEnvelope<ProfileViewed> envelope)
        {
            ConsoleOutput.WriteLine("Profile view opened.");
            return EventAcknowledge.Handled;
        }
    }
}