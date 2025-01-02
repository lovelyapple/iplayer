using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBattleCharacter : MonoBehaviour, IBattleCharacter
{
    public CommonBattleCharacter Target { get; set; }
    public CommonWeaponController WeaponController { get; set; }
    public void Init(WeaponData weaponData)
    {
        WeaponController = new CommonWeaponController(weaponData);
    }
    public void OnUpdate()
    {

    }
    public void OnMove()
    {

    }
    public void SearchTarget()
    {

    }
    public void RequestFire()
    {
        if (WeaponController.IsRequringReload)
        {
            if (!WeaponController.IsReloading)
            {
                StartReload();
            }
        }
        else if (!WeaponController.CanFireRate())
        {
            return;
        }

        WeaponController.OnFire();
    }
    public void StartReload()
    {
        WeaponController.StartReload();
    }
}
