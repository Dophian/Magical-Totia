using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Gun
{
    // Components
    [SerializeField] private Player player;

    [Header("디버깅")]
    [SerializeField]
    [TextArea(15, 20)]
    private string debugText;

    private void Start()
    {
        // 임시 초기화
        currentAmmo = maxAmmo;
    }

    public void Update()
    {
        // TO DO
        // 상태 관리 기능, Update에서 매 프레임 확인하는 것이 좋을 것 같음

        switch (state)
        {
            case GunState.ReadyToShot:
                break;
            case GunState.WaitForFireRate:
                shotRateTimer -= Time.deltaTime;
                bool isReadyToShot = shotRateTimer <= 0;

                if (isReadyToShot)
                {
                    shotRateTimer= shotRate;
                    state = GunState.ReadyToShot;
                }
                break;
            case GunState.Reload:
                reloadTimer -= Time.deltaTime;
                bool isReloadTimerDone = reloadTimer <= 0;

                if (isReloadTimerDone)
                {
                    Reload();
                }
                break;
        }

        // 장비 중이라면
        FollowGrabPoint(player.GrabPoint.position);

        UpdateDebugText();
    }

    public override void Fire()
    {
        if (state != GunState.ReadyToShot)
        {
            return;
        }

        if (currentAmmo > 0)
        {
            currentAmmo--;
            ChangeState(GunState.Shot);
            ChangeState(GunState.WaitForFireRate);

            if (currentAmmo <= 0)
            {
                ChangeState(GunState.Reload);
            }
        }
        else
        {
            ChangeState(GunState.Reload);
        }
    }

    public override void Reload()
    {
        currentAmmo = MaxAmmo;
        reloadTimer = reloadTime;
        state = GunState.ReadyToShot;
    }

    private void UpdateDebugText()
    {
        debugText = string.Empty;

        debugText += $"이름 : {Name}\n";
        debugText += "상태 : ";
        switch (state)
        {
            case GunState.ReadyToShot:
                debugText += "발사 준비 됨";
                break;
            case GunState.Shot:
                debugText += "발사 중";
                break;
            case GunState.WaitForFireRate:
                debugText += "발사 대기 중 (발사 속도 제한)";
                break;
            case GunState.AmmoEmpty:
                debugText += "장전된 탄약 없음";
                break;
            case GunState.Reload:
                debugText += "재장전 중";
                break;
        }
        debugText += "\n";

        debugText +=
            $"피해량 : {Damage}\n" +
            $"\n" +
            $"최대 탄약 : {MaxAmmo}\n" +
            $"현재 탄약 : {CurrentAmmo}\n" +
            $"\n" +
            $"연사 속도 : {ShotRate}\n" +
            $"연사 대기 시간 : {ShotRateTimer}\n" +
            $"\n" +
            $"재장전 시간 : {ReloadTime}\n" +
            $"재장전 타이머 : {ReloadTimer}";
    }
}
