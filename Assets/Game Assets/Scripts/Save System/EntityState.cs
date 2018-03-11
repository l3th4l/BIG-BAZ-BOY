using System;
using System.Runtime.Serialization;

[Serializable]
internal class EntityState : ISerializable
{
    protected EntityState()
    {
    }

    protected EntityState(SerializationInfo info, StreamingContext context)
    {
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
    }
}