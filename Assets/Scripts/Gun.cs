using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : Weapon, IGun
{
    // TO DO
    // Gun �θ� Ŭ���� �����
    // ���� ���� ����� �����ؼ� Weapon Ŭ������ �������̽� �����ϱ�
    public GameObject BulletPrefab => bulletPrefab;
    protected GameObject bulletPrefab;

    public int MaxAmmo => maxAmmo;
    protected int maxAmmo;

    public int CurrentAmmo => currentAmmo;
    protected int currentAmmo;

    public float Damage => damage;
    protected float damage;

    public float ShotRate => shotRate;
    protected float shotRate = 0.75f;
    public float LastShotTime => lastShotTime;
    protected float lastShotTime;

    public float ShotRateTimer => shotRateTimer;
    protected float shotRateTimer;

    public float ReloadTime => reloadTime;
    protected float reloadTime = 1.5f;

    public float ReloadTimer => reloadTimer;
    protected float reloadTimer;

    GunFireType IGun.FireType { get => fireType; }
    protected GunFireType fireType;

    GunState IGun.State { get => state; }
    protected GunState state;

    public abstract void Fire();

    public abstract void Reload();
}
