using System;
using UnityEngine;

namespace Pool
{
    public abstract class Object : MonoBehaviour
    {
        public delegate void OnPush(Object poolObject);

        public static event OnPush onPush;

        internal Boolean isAvailable { set; get; }

        public ObjectTypes poolObjectType;

        public abstract Object ResetProps();

        public abstract bool ShouldBePushed();

        public Object()
        {
            Pool.Manager.AddProducer(this);
        }

        public T ReadyToPull<T>(Vector3 position)
            where T : Object
        {
            return this
                .ResetProps()
                .SetAvailability(false)
                .ResetPosition(position) as
            T;
        }

        public Object ReadyToPush(Vector3 position)
        {
            return this.SetAvailability(true).ResetPosition(position);
        }

        private Object ResetPosition(Vector3 position)
        {
            this.isAvailable = false;
            this.transform.position = position;
            return this;
        }

        private Object SetAvailability(Boolean availability)
        {
            this.isAvailable = availability;
            this.gameObject.SetActive(!availability);
            return this;
        }

        public Object Push()
        {
            if (ShouldBePushed() && onPush != null)
            {
                onPush(this);
            }
            return null;
        }
    }
}
