using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [SerializeField] private float FirePosHeight = 1.5f;

    [SerializeField] private float FirePosFront = 0.5f;
    [SerializeField] private Transform FireForwadPosTra;

    // とりあえずこの辺は発射の位置の初期化だけしとく
    public void Initialize(Transform characterModelTran)
    {
        transform.localPosition = new Vector3()
        {
            x = 0,
            y = FirePosHeight,
            z = FirePosFront,
        };
        
        transform.SetParent(characterModelTran);
    }

    public Vector2 GetTarget()
    {
        return FireForwadPosTra.position;
    }
}
