using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour, IGun
{
    // TO DO
    // Gun 부모 클래스 만들기
    // 근접 무기 만들거 생각해서 Weapon 클래스나 인터페이스 생각하기
    public GameObject BulletPrefab => bulletPrefab;
    private GameObject bulletPrefab;

    public int MaxAmmo => maxAmmo;
    private int maxAmmo;

    public int CurrentAmmo => currentAmmo;
    private int currentAmmo;

    public float Damage => damage;
    private float damage;

    public float ShotRate => shotRate;
    private float shotRate = 0.75f;
    public float LastShotTime => lastShotTime;
    private float lastShotTime;

    public float ShotRateTimer => shotRateTimer;
    private float shotRateTimer;

    public float ReloadTime => reloadTime;
    private float reloadTime = 1.5f;

    public float ReloadTimer => reloadTimer;
    private float reloadTimer;

    IGun.EFireType IGun.FireType { get => fireType; }
    IGun.EFireType fireType;

    IGun.EState IGun.State { get => state; }
    public IGun.EState state;

    public void Update()
    {
        if (Time.time >= lastShotTime && state != IGun.EState.Reload)
        {
            // TO DO
            // Switch 문으로 개선
            // 추가 예외 조건 확인
            state = IGun.EState.ReadyToShot;
        }

        if (state == IGun.EState.Reload)
        {
            reloadTimer -= Time.deltaTime;

            // TO DO
            // 재장전 로직 작성
            // Update가 아닌 함수로 빼기
            // Switch 문으로 개선
        }
    }

    public void Fire()
    {
        // 쏠 수 있는 상태일 때
        // ㄴ 재장전 상태가 아님, FireRate가 쏠 수 있는 상태
        // 탄약이 1이상 있다면 발사, 탄약 -1, 투사체 생성
        // ㄴ 만약 탄약이 0이하라면 재장전 상태로 자동 진입

        if (state == IGun.EState.ReadyToShot)
        {
            if (currentAmmo > 0)
            {
                Debug.Log("Revolver Fire!");
                currentAmmo--;
                lastShotTime = Time.time;

                if (currentAmmo <= 0)
                {
                    Reload();
                }
            }
            else
            {
                Reload();
            }
        }
    }

    public void Reload()
    {
        // ReloadTime을 흘려보냄
        // 전부 다 되면 현재 탄약 = 최대 탄약 대입
        // 쏠 수 있는 상태로 변경

        state = IGun.EState.Reload;
        Debug.Log("Revolver Reloading!");
    }
}
