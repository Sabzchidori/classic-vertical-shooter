using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public abstract class Consumer : MonoBehaviour
    {
        public ObjectTypes poolObjectTypeToConsume;

        protected Element Consume<Element>(Vector3 position)
            where Element : Object
        {
            return Manager
                .Pull<Element>(poolObjectTypeToConsume, position);
        }  
    }
}
