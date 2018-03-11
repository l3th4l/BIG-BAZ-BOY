using UnityEngine;

internal abstract class Saveable : MonoBehaviour
{
    public abstract void Load(EntityState entity);

    public abstract EntityState Save();
}