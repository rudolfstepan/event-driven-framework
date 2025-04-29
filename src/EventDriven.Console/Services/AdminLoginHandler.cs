using EventDriven.Console.Topics;
using EventDriven.Core.EventBus;

namespace EventDriven.Console.Services
{
    public class AdminLoginHandler
    {
        private readonly EventBusAsync _bus;

        public AdminLoginHandler(EventBusAsync bus)
        {
            _bus = bus;
            _bus.Subscribe<LoginSuccess>(OnLoginSuccess);
        }

        private async Task<EventAcknowledge> OnLoginSuccess(EventEnvelope<LoginSuccess> envelope)
        {
            if (envelope.Payload.Username == "admin")
            {
                await _bus.PublishAsync(new AdminMainMenuReady());
            }
            else
            {
                await _bus.PublishAsync(new MainMenuReady());
            }
            return EventAcknowledge.Handled;
        }
    }
}