using EventDriven.Core.EventBus;

namespace EventDriven.Console.Workflow
{
    public class WorkflowManager
    {
        private readonly EventBusAsync _bus;

        public WorkflowManager(EventBusAsync bus)
        {
            _bus = bus;
        }

        public async Task ExecuteAsync<TStartEvent>(TStartEvent startEvent, List<Func<Task>> steps)
        {
            await _bus.PublishAsync(startEvent);

            foreach (var step in steps)
            {
                await step.Invoke();
            }
        }

        public async Task ExecuteConditionalAsync<TEvent>(TEvent triggerEvent, Func<TEvent, bool> condition, Func<Task> onTrue, Func<Task> onFalse)
        {
            _bus.Subscribe<TEvent>(async envelope =>
            {
                if (condition(envelope.Payload))
                {
                    await onTrue();
                }
                else
                {
                    await onFalse();
                }
                return EventAcknowledge.Handled;
            });
        }

        public async Task DelayedPublishAsync<TEvent>(TEvent @event, int delayMilliseconds)
        {
            await Task.Delay(delayMilliseconds);
            await _bus.PublishAsync(@event);
        }
    }
}