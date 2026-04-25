using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGBullet : Bullet
{
    [SerializeField] private float _speed;
    public override void BulletPhysic()
    {
        Vector3 direction = transform.forward;
        direction.Normalize();
        _rb.velocity = direction * _speed;
        Deactive();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _bulletsPool.Release(this);
    }
}
