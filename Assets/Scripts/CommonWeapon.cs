using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// なるべくメソッドの中に他のパラメータの状態を見ないでほしい
/// </summary>
public class CommonWeapon : IWeapon
{
    public WeaponFireMode CurrentFireMode;
    public WeaponData WeaponData { get; set; }
    public int CurrentMagazine { get; set; }
    public bool IsRequringReload { get; set; }
    public bool IsReloading { get; set; }
    public DateTime ReloadCompleteTime { get; set; }
    public DateTime NextRateTime { get; set; }
    public bool IsCycling { get; set; }
    private const int SemiAutoCost = 3;
    FirePosition _firePositionTran;
    public CommonWeapon(WeaponData weaponData, FirePosition firePosition)
    {
        WeaponData = weaponData;
        CurrentMagazine = weaponData.MaxMagazine;
        _firePositionTran = firePosition;
        CurrentFireMode = weaponData.WeaponFireModes.First();
    }
    public bool CanFireRate()
    {
        return DateTime.Now >= NextRateTime;
    }
    public void OnFire()
    {
        if (CurrentFireMode == WeaponFireMode.FullAuto)
        {
            CurrentMagazine--;

            if (CurrentMagazine <= 0)
            {
                IsRequringReload = true;
                return;
            }

            var now = DateTime.Now;
            NextRateTime = now.AddMilliseconds(WeaponData.FireRateMilSec);

            var bullet = BulletManager.CreateBullet();
            bullet.Init(_firePositionTran.transform.position, _firePositionTran.transform.forward);
        }
        else
        {
            throw new Exception("他のファイアーモードまた作っていない");
        }
    }
    public void StartReload()
    {
        DateTime now = DateTime.Now;
        ReloadCompleteTime = now.AddMilliseconds(WeaponData.ReloadSpeedMilSec);
        IsReloading = true;
    }
    public bool IsReloadCompleted()
    {
        if (DateTime.Now < ReloadCompleteTime)
        {
            return false;
        }

        ReloadCompleteTime = DateTime.MinValue;
        IsRequringReload = false;
        IsReloading = false;
        return true;
    }
}
