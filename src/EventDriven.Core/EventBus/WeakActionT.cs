namespace EventDriven.Core.EventBus
{
    public class WeakAction<T> : WeakEventBase<Action<T>>
    {
        public void Invoke(T arg)
        {
            InvokeHandlers(arg);
        }

        public static WeakAction<T> operator +(WeakAction<T> e, Action<T> handler)
        {
            e.Register(handler);
            return e;
        }

        public static WeakAction<T> operator -(WeakAction<T> e, Action<T> handler)
        {
            e.Deregister(handler);
            return e;
        }
    }
}
