using System;

namespace Pool
{
    [Serializable]
    public class InvalidObjectType : Exception
    {
        public InvalidObjectType(ObjectTypes type) :
            base(
                "The type " + type + " does not exist in pool object dictionary"
            )
        {
        }

        public InvalidObjectType(string message) :
            base(message)
        {
        }

        public InvalidObjectType(string message, Exception inner) :
            base(message, inner)
        {
        }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected InvalidObjectType(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context
        ) :
            base(info, context)
        {
        }
    }
}
