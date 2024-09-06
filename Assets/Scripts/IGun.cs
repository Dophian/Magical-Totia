using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunState
{
    ReadyToShot,
    Shot,
    WaitForFireRate,
    AmmoEmpty,
    Reload,
}

public enum GunFireType
{
    SemiAuto,
    ThreeRoundBurst,
    FullAuto,
}

public interface IGun
{
    // Prefabs
    public GameObject BulletPrefab { get; }

    // Properties
    public int MaxAmmo { get; }
    public int CurrentAmmo { get; }
    public float Damage { get; }
    public float ShotRate { get; }
    public float LastShotTime { get; }
    public float ShotRateTimer { get; }
    public float ReloadTime { get; }
    public float ReloadTimer { get; }

    public GunFireType FireType { get; } 

    public GunState State { get; }

    public void Fire();
    public void Reload();
}
