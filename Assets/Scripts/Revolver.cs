using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Gun
{
    public void Update()
    {
        // TO DO
        // 상태 관리 기능, Update에서 매 프레임 확인하는 것이 좋을 것 같음

        if (Time.time >= (lastShotTime + shotRate) && state != GunState.Reload)
        {
            // TO DO
            // Switch 문으로 개선
            // 추가 예외 조건 확인
            state = GunState.ReadyToShot;
        }

        if (state == GunState.Reload)
        {
            reloadTimer -= Time.deltaTime;

            // TO DO
            // 재장전 로직 작성
            // Update가 아닌 함수로 빼기
            // Switch 문으로 개선
        }
    }

    public override void Fire()
    {
        // 플레이어가 원거리 무기를 든 상태에서 발사 버튼을 누를 경우 트리거
        // 쏠 수 있는 상태일 때
        // ㄴ 재장전 상태가 아님, FireRate가 쏠 수 있는 상태
        // 탄약이 1이상 있다면 발사, 탄약 -1, 투사체 생성
        // ㄴ 만약 탄약이 0이하라면 재장전 상태로 자동 진입

        if (state != GunState.ReadyToShot)
        {
            return;
        }

        if (currentAmmo > 0)
        {
            Debug.Log("Revolver Fire!");
            currentAmmo--;
            lastShotTime = Time.time;
            state = GunState.Shot;

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

    public override void Reload()
    {
        // ReloadTime을 흘려보냄
        // 전부 다 되면 현재 탄약 = 최대 탄약 대입
        // 쏠 수 있는 상태로 변경

        state = GunState.Reload;
        Debug.Log("Revolver Reloading!");
    }
}
