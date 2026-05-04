using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGBullet : Bullet
{
    [SerializeField] private float _speed;
    [SerializeField] private int _dmg;
    public override void BulletPhysic()
    {
        SoundFxManager._instance.PlayFxSound("ShotMG");
        Vector3 direction = transform.forward;
        direction.Normalize();
        _rb.velocity = direction * _speed;
        Deactive();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<LifeController>(out var life))
        {
            life.RemoveHp(_dmg);
        }

        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _bulletsPool.Release(this);

        
    }
}
