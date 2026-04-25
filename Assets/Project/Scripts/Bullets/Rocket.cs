using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    [SerializeField] private float _speed;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _explosionForce = 700f;
    [SerializeField] private float _dmg = 100f;
    [SerializeField] private LayerMask _hitMask;
    public override void BulletPhysic()
    {
        Vector3 direction = transform.forward;
        direction.Normalize();
        _rb.velocity = direction * _speed;
        Deactive();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    private void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius, _hitMask);

        foreach (Collider hit in hits)
        {
            LifeController life = hit.GetComponentInParent<LifeController>();
            if (life != null)
            {
                float distance = Vector3.Distance(transform.position, hit.transform.position);
                float damagePercent = 1f - (distance / _explosionRadius);
                float finalDamage = _dmg * Mathf.Clamp01(damagePercent);
                int dmg = Mathf.RoundToInt(finalDamage);
                life.RemoveHp(dmg);
            }


            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, 0f, ForceMode.Impulse);

                Vector3 vel = rb.velocity;
                Vector3 horizontal = new Vector3(vel.x, 0, vel.z);
                horizontal = Vector3.ClampMagnitude(horizontal, 1.5f);

                rb.velocity = new Vector3(horizontal.x, vel.y, horizontal.z);
                //vel.x *= 0.3f;
                //vel.z *= 0.3f;
                //rb.velocity = vel;
            }
        }

        // Instantiate(explosionFX, transform.position, Quaternion.identity);

        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _bulletsPool.Release(this);
    }
}
