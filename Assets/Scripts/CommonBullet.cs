using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IBullet
{
    public bool IsPlaying { get; set; }
    public float LifeTime { get; set; }
    public void Init(Vector3 startPos, Vector3 moveSpeed);
}
public class CommonBullet : MonoBehaviour, IBullet
{
    private const float BulletLifeTime = 3;
    public bool IsPlaying { get; set; }
    public float LifeTime { get; set; }
    public Vector3 MoveSpeed { get; set; }
    public void Init(Vector3 startPos, Vector3 moveSpeed)
    {
        IsPlaying = true;
        MoveSpeed = moveSpeed;
        transform.position = startPos;
        gameObject.SetActive(true);
        LifeTime = BulletLifeTime;
    }
    void Update()
    {
        if (!IsPlaying)
        {
            return;
        }
        var distance = (MoveSpeed * Time.deltaTime).magnitude;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, MoveSpeed, out hit, distance))
        {
            OnHit(hit);
            LifeTime = 0;
        }

        LifeTime -= Time.deltaTime;

        if (LifeTime < 0)
        {
            IsPlaying = false;
            gameObject.SetActive(false);
            return;
        }

        transform.position += transform.forward * distance;
    }
    private void OnHit(RaycastHit hit)
    {
        transform.position = Vector3.zero;
        gameObject.SetActive(false);
    }
}
