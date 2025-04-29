using EventDriven.Core.EventBus;

namespace EventDriven.Console.Simulation
{
    public class EventSimulator
    {
        private readonly EventBusAsync _bus;
        private readonly Random _random = new();

        public TextWriter ConsoleOutput { get; set; }

        public EventSimulator(EventBusAsync bus)
        {
            _bus = bus;
        }

        public async Task SimulateEventAsync<T>(T @event, int delayMs = 0)
        {
            if (delayMs > 0)
                await Task.Delay(delayMs);

            await _bus.PublishAsync(@event);
            ConsoleOutput.WriteLine($"Simulated Event: {@event.GetType().Name}");
        }

        public async Task SimulateChainAsync(IEnumerable<object> events, int delayBetweenEventsMs = 0)
        {
            foreach (var e in events)
            {
                await SimulateEventAsync(e, delayBetweenEventsMs);
            }
        }

        public async Task SimulateRandomEventsAsync(IEnumerable<object> possibleEvents, int count, int maxDelayMs = 0)
        {
            var eventList = possibleEvents.ToList();

            for (int i = 0; i < count; i++)
            {
                var randomEvent = eventList[_random.Next(eventList.Count)];
                int delay = maxDelayMs > 0 ? _random.Next(maxDelayMs) : 0;
                await SimulateEventAsync(randomEvent, delay);
            }
        }
    }
}