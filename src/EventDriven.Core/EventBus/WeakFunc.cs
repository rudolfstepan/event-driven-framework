namespace EventDriven.Core.EventBus
{
    public class WeakFunc<T, TResult> : WeakEventBase<Func<T, TResult>>
    {
        public TResult? Invoke(T arg)
        {
            lock (_lock)
            {
                foreach (var handler in _handlers.ToList())
                {
                    try
                    {
                        if (!handler.IsDead)
                        {
                            var target = handler.TargetRef?.Target;
                            var result = handler.Method.Invoke(target, new object?[] { arg });
                            return (TResult?)result;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (DebugLogging)
                            Console.WriteLine($"[WeakEvent] Fehler beim Aufruf: {ex.Message}");
                    }
                }

                CleanupDeadHandlers();
            }

            return default;
        }

        public static WeakFunc<T, TResult> operator +(WeakFunc<T, TResult> e, Func<T, TResult> handler)
        {
            e.Register(handler);
            return e;
        }

        public static WeakFunc<T, TResult> operator -(WeakFunc<T, TResult> e, Func<T, TResult> handler)
        {
            e.Deregister(handler);
            return e;
        }
    }
}
