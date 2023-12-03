using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    [SerializeField] private List<BulletBase> BulletPools;
    private List<BulletBase> BulletPoolsRequest = new List<BulletBase>();
    public void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        if (BulletPoolsRequest.Any())
        {
            BulletPools.AddRange(BulletPoolsRequest);
            BulletPoolsRequest.Clear();
        }
    }

    public void AddToPools(BulletBase bulletBase)
    {
        BulletPoolsRequest.Add(bulletBase);
    }

    // TODO 個々の辺はBulletの種類によって分かれて管理する
    public BulletBase PickOne(BulletBase prefab)
    {
        if (BulletPools.Any())
        {
            var bullet = BulletPools.First();
            BulletPools.Remove(bullet);
            return bullet;
        }

        return GameObject.Instantiate(prefab.gameObject).GetComponent<BulletBase>();
    }
}
