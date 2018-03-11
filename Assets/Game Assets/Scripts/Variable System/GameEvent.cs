namespace ScriptableObjectUtility.Events
{
    using System;
    using System.Linq;
    using UnityEngine;

    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        private event Action Event;

        public static GameEvent operator -(GameEvent @event, Action del)
        {
            @event.Event -= del;
            return @event;
        }

        public static GameEvent operator +(GameEvent @event, Action del)
        {
            @event.Event += del;
            return @event;
        }

        public void Raise()
        {
            if (this.Event != null)
            {
                this.Event();
            }
        }

        public void Register(Action del)
        {
            // TODO: Check whether this is necessary
            if (this.Event == null || !this.Event.GetInvocationList().Contains(del))
            {
                this.Event += del;
            }
        }

        public void Reset()
        {
            this.Event = null;
        }

        public void Unregister(Action del)
        {
            // TODO: Check whether this is necessary
            if (this.Event.GetInvocationList().Contains(del))
            {
                this.Event -= del;
            }
        }
    }
}