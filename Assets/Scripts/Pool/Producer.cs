using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    class Producer<Element> where Element : Object
    {
        internal Vector3 position;

        public readonly Element element;

        internal int size;

        public Producer(Element element)
        {
            this.element = element;
            Object.onPush += Push;
        }


        public void Initialize(int size, Vector3 position) {
            this.size = size;
            this.position = position;
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
                .Instantiate<Element>(element, position, Quaternion.identity);
        }

        public void Push(Object @object)
        {
            if (element.poolObjectType == @object.poolObjectType)
            {
                if (pool.Count + 1 <= size)
                {
                    pool.Push(@object.ReadyToPush(position) as Element);
                }
                else
                {
                    Object.Destroy(@object.gameObject);
                }
            }
        }
    }
}
