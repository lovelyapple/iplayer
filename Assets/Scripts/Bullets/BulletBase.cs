using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    private float _speed;
    private float _lifeTime;
    private BattleTeam _ownerTeam;
    private bool _isAlive = false;

    public void InitializeBullet(Vector3 targetPos, BattleTeam ownerTeam, float speedAdd = 0)
    {
       transform.LookAt(targetPos);
        _speed = GameConstantDefine.BulletBaseSpeed + speedAdd;
        _lifeTime = GameConstantDefine.BulletLifeTime;
        _ownerTeam = ownerTeam;
        _isAlive = true;
    }

    public void Update()
    {
        if (!_isAlive)
        {
            return;
        }
        
        _lifeTime -= Time.deltaTime;
        transform.position = transform.forward * _speed * Time.deltaTime;

        if (_lifeTime <= 0)
        {
            _isAlive = false;
            BulletPool.Instance.AddToPools(this);
            return;
        }
    }
}
