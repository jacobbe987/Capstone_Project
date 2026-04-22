using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] protected float _bulletSpeed;
    [SerializeField] protected Transform _bulletSpawnPos;
    [SerializeField] protected float _rof;
    [SerializeField] protected float _nextShot;

    //obj pooling
    protected IObjectPool<Bullet> _objPool;
    protected bool _collectionCheck;
    [SerializeField] protected int _capacity;
    [SerializeField] protected int _maxCapacity;

    protected void Awake()
    {
        _objPool=new ObjectPool<Bullet>(CreateBullet, OnGetFromPool, OnReleaseToPool,OnDestroyPooled, _collectionCheck, _capacity, _maxCapacity);
    }

    protected Bullet CreateBullet()
    {
        Bullet objBullet = Instantiate(_bulletPrefab);
        objBullet.gameObject.SetActive(false);
        objBullet.transform.SetParent(this.transform);
        objBullet.SetObjPool(_objPool);
        return objBullet;
    }

    protected void OnGetFromPool(Bullet pooledBullet)
    {
        pooledBullet.gameObject.SetActive(true);
    }

    protected void OnReleaseToPool(Bullet pooledBullet)
    {
        pooledBullet.gameObject.SetActive(false);
    }

    protected void OnDestroyPooled(Bullet pooledBullet)
    {
        Destroy(pooledBullet.gameObject);
    }
    public abstract void Shoot();

    protected void Update()
    {
        Shoot();
    }
}
