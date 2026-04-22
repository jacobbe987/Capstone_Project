using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float _lifeTime;
    [SerializeField] protected Rigidbody _rb;
    protected IObjectPool<Bullet> _bulletsPool;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void SetObjPool(IObjectPool<Bullet> bulletPool)
    {
        _bulletsPool = bulletPool;
    }
    public void Deactive()
    {
        StartCoroutine(DeactiveCoroutine(_lifeTime));
    }

    public virtual IEnumerator DeactiveCoroutine(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _bulletsPool.Release(this);
    }

    public abstract void BulletPhysic();
}
