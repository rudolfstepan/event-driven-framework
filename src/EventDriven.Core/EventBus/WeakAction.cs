namespace EventDriven.Core.EventBus
{
    public class WeakAction : WeakEventBase<Action>
    {
        public void Invoke()
        {
            InvokeHandlers();
        }

        public static WeakAction operator +(WeakAction e, Action handler)
        {
            e.Register(handler);
            return e;
        }

        public static WeakAction operator -(WeakAction e, Action handler)
        {
            e.Deregister(handler);
            return e;
        }
    }
}
