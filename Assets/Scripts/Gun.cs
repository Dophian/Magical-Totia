using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : Weapon, IGun
{
    // TO DO
    // Gun 부모 클래스 만들기
    // 근접 무기 만들거 생각해서 Weapon 클래스나 인터페이스 생각하기
    public GameObject BulletPrefab => bulletPrefab;
    protected GameObject bulletPrefab;

    public override string Name => gunName;
    [Header("총기 속성")]
    [SerializeField] protected string gunName;

    public int MaxAmmo => maxAmmo;
    [SerializeField] protected int maxAmmo;

    public int CurrentAmmo => currentAmmo;
    protected int currentAmmo;

    public float Damage => damage;
    [SerializeField] protected float damage;

    public float ShotRate => shotRate;
    [SerializeField] protected float shotRate = 0.75f;

    public float ShotRateTimer => shotRateTimer;
    protected float shotRateTimer;

    public float ReloadTime => reloadTime;
    [SerializeField] protected float reloadTime = 1.5f;

    public float ReloadTimer => reloadTimer;
    protected float reloadTimer;

    GunFireType IGun.FireType { get => fireType; }
    [SerializeField] protected GunFireType fireType;

    GunState IGun.State { get => state; }
    protected GunState state;

    public abstract void Fire();

    public abstract void Reload();

    protected void ChangeState(GunState state)
    {
        this.state = state;
    }
}
