using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public enum EFireType
    {
        SemiAuto,
        ThreeRoundBurst,
        FullAuto,
    }
    public EFireType FireType { get; } 
    public enum EState
    {
        ReadyToShot,
        Shot,
        WaitForFireRate,
        AmmoEmpty,
        Reload,
    }
    public EState State { get; }

    public void Fire();
    public void Reload();
}
