using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponController
{
    public WeaponData WeaponData { get; set; }
    public int CurrentMagazine { get; set; }
    public bool IsRequringReload { get; set; }
    public bool IsReloading { get; set; }
    public void OnFire();
    public void StartReload();
}
