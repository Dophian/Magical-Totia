using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Melee,
    Range,
}

public abstract class Weapon : MonoBehaviour
{
    public abstract string Name { get; }
    protected WeaponType type;

    protected void FollowGrabPoint(Vector3 position)
    {
        transform.position = position;
    }
}
