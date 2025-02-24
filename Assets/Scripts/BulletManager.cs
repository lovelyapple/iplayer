using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public CommonBullet BulletPrefab;
    public Transform PoolRootTransform;
    public List<IBullet> BulletsCache = new List<IBullet>();
    private static BulletManager _instance;
    public static BulletManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<BulletManager>();
            }

            return _instance;
        }
    }
    public static IBullet CreateBullet()
    {
        return Instance.TryCreateBullet();
    }
    public IBullet TryCreateBullet()
    {
        var bullet = BulletsCache.FirstOrDefault(x => x.IsPlaying == false);

        if (bullet == null)
        {
            bullet = Instantiate(BulletPrefab, PoolRootTransform);
            BulletsCache.Add(bullet);
        }

        return bullet;
    }
}
