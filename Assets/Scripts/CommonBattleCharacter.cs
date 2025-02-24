using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBattleCharacter : MonoBehaviour, IBattleCharacter
{
    [SerializeField] Transform FirePositionTransform;
    public CommonBattleCharacter Target { get; set; }
    public FirePosition FirePosition { get; set; }
    public CommonWeapon Weapon { get; set; }
    private void Awake()
    {
        FirePosition = FirePositionTransform.gameObject.AddComponent<FirePosition>();
    }
    public void Init(WeaponData weaponData)
    {
        Weapon = new CommonWeapon(weaponData, FirePosition);
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
        if (Weapon.IsRequringReload)
        {
            if (!Weapon.IsReloading)
            {
                StartReload();
            }
        }
        else if (!Weapon.CanFireRate())
        {
            return;
        }

        Weapon.OnFire();
    }
    public void StartReload()
    {
        Weapon.StartReload();
    }
}
