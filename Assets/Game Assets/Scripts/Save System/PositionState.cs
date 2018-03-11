using System;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
internal class PositionState : EntityState
{
    private Vector3 position;

    public PositionState(Vector3 position) : base()
    {
        this.position = position;
    }

    protected PositionState(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        this.position.x = info.GetSingle("x");
        this.position.y = info.GetSingle("y");
    }

    public Vector3 Position
    {
        get { return this.position; }
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("x", this.position.x);
        info.AddValue("y", this.position.y);
    }
}