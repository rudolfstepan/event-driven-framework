namespace EventDriven.Core.EventBus
{
    public class WeakFunc<T1, T2, TResult> : WeakEventBase<Func<T1, T2, TResult>>
    {
        public TResult? Invoke(T1 arg1, T2 arg2)
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
                            var result = handler.Method.Invoke(target, new object?[] { arg1, arg2 });
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

        public static WeakFunc<T1, T2, TResult> operator +(WeakFunc<T1, T2, TResult> e, Func<T1, T2, TResult> handler)
        {
            e.Register(handler);
            return e;
        }

        public static WeakFunc<T1, T2, TResult> operator -(WeakFunc<T1, T2, TResult> e, Func<T1, T2, TResult> handler)
        {
            e.Deregister(handler);
            return e;
        }
    }
}

