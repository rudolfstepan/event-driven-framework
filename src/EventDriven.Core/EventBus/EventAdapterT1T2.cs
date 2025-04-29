﻿namespace EventDriven.Core.EventBus.Adapters
{

    public class EventAdapter<TControl, TEventArgs>
    where TControl : class
    {
        private readonly TControl _control;
        private readonly Action<TControl, EventHandler<TEventArgs>> _subscribe;
        private readonly Action<TControl, EventHandler<TEventArgs>> _unsubscribe;
        private WeakAction<object?, EventArgs> _bulletproofEvent = new();
        private bool _isHooked;

        public EventAdapter(
            TControl control,
            Action<TControl, EventHandler<TEventArgs>> subscribe,
            Action<TControl, EventHandler<TEventArgs>> unsubscribe)
        {
            _control = control ?? throw new ArgumentNullException(nameof(control));
            _subscribe = subscribe ?? throw new ArgumentNullException(nameof(subscribe));
            _unsubscribe = unsubscribe ?? throw new ArgumentNullException(nameof(unsubscribe));
        }

        public event EventHandler? Clicked
        {
            add
            {
                if (value != null && !_isHooked)
                {
                    _subscribe(_control, InternalHandler);
                    _bulletproofEvent += value.Invoke;
                    _isHooked = true;
                }
            }
            remove
            {
                if (value != null)
                {
                    _bulletproofEvent -= value.Invoke;
                    if (_bulletproofEvent.IsEmpty && _isHooked)
                    {
                        _unsubscribe(_control, InternalHandler);
                        _isHooked = false;
                    }
                }
            }
        }

        private void InternalHandler(object? sender, TEventArgs e)
        {
            _bulletproofEvent.Invoke(sender, EventArgs.Empty);
        }
    }
}
