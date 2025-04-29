namespace EventDriven.Core.EventBus
{
    public class WeakAction<T1, T2> : WeakEventBase<Action<T1, T2>>
    {
        public void Invoke(T1 arg1, T2 arg2)
        {
            InvokeHandlers(arg1, arg2);
        }

        public static WeakAction<T1, T2> operator +(WeakAction<T1, T2> e, Action<T1, T2> handler)
        {
            e.Register(handler);
            return e;
        }

        public static WeakAction<T1, T2> operator -(WeakAction<T1, T2> e, Action<T1, T2> handler)
        {
            e.Deregister(handler);
            return e;
        }
    }
}
