using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Magazine 
{
    public int MaxMag;
    public int CurrentMag;
    public bool IsEmpty => CurrentMag > 0;
    public void DecreaseMag()
    {
        if (IsEmpty)
        {
            return;
        }
        
        CurrentMag--;
    }
}
public class WeaponBase : MonoBehaviour
{
    [SerializeField] private Magazine Magazine = new Magazine();
    [SerializeField] private float FireRate = 1f;
    [SerializeField] private float NextFireTimeLeft = 0f;

    [SerializeField] private float ReloadTime = 3f;
    [SerializeField] private float ReloadTimeLeft = 0;
    [SerializeField] private BulletBase BulletPrefab;

    private bool CanFire => NextFireTimeLeft <= 0f && !Magazine.IsEmpty && ReloadTimeLeft <= 0f;
    private AimController _aimController;
    public void Initialize(AimController aimController)
    {
        _aimController = aimController;
    }
    public void Update() 
    {
        if (NextFireTimeLeft > 0)
        {
            NextFireTimeLeft -= Time.deltaTime;
        }

        if (ReloadTimeLeft > 0)
        {
            ReloadTimeLeft -= Time.deltaTime;
        }
    }

    public void RequestFire()
    {
        if (!CanFire)
        {
            return;
        }
        
        Magazine.DecreaseMag();

        var bullet = BulletPool.Instance.PickOne(BulletPrefab);
        bullet.InitializeBullet(_aimController.transform.position,_aimController.GetTarget(), BattleTeam.AlphaTeam);
        
        if (Magazine.IsEmpty)
        {
            ReloadTime += ReloadTime;
        }

        NextFireTimeLeft += FireRate;
    }
}
