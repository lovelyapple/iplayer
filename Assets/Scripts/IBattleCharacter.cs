using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleCharacter
{
    public CommonBattleCharacter Target { get; set; }
    public CommonWeaponController WeaponController { get; set; }
    public void Init(WeaponData weaponData);
    public void OnUpdate();
    public void OnMove();
    public void SearchTarget();
    public void RequestFire();
}
