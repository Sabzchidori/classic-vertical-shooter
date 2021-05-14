using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    class Producer<Element> where Element : Object
    {
        public Vector3 position;

        public readonly Element poolObject;

        private readonly ObjectTypes type;

        public Producer(Element element, Vector3 position)
        {
            this.position = position;
            this.poolObject = element;
            Object.onPush += Push;
            this.type = element.poolObjectType;
        }

        private Stack<Element> pool = new Stack<Element>();

        public Element Pull(Vector3 position)
        {
            if (pool.Count != 0)
            {
                var element = pool.Pop();
                return element.ReadyToPull<Element>(position);
            }
            return UnityEngine
                .Object
                .Instantiate<Element>(poolObject,
                position,
                Quaternion.identity);
        }

        public void Push(Object element)
        {
            if (type == element.poolObjectType)
            {
                pool.Push(element.ReadyToPush(position) as Element);
            }
        }
    }
}
