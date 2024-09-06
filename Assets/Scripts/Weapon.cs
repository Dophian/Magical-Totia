using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EWeaponType
{
    Melee,
    Range,
}

public class Weapon : MonoBehaviour
{
    public string name;
    public EWeaponType type;
}
