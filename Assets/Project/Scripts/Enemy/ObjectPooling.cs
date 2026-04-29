using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private EnemyController _objPrefab;
    [SerializeField] private Transform[] spawnpoints;
    private IObjectPool<EnemyController> _objPool;
    private bool _collectionCheck;
    private int _poolCapacity = 20;
    private int _poolMaxSize = 50;

    private void Awake()
    {
        _objPool = new ObjectPool<EnemyController>(Create, OnGetFromPool, OnRealeseToPool, OnDestroyPooledObj, _collectionCheck, _poolCapacity, _poolMaxSize);
    }

    private EnemyController Create()
    {
        EnemyController obj = Instantiate(_objPrefab);
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        obj.SetObjPool(_objPool);
        return obj;
    }

    private void OnGetFromPool(EnemyController pooledObj)
    {
        pooledObj.gameObject.SetActive(true);
    }

    private void OnRealeseToPool(EnemyController pooledObj)
    {
        pooledObj.gameObject.SetActive(false);
    }

    private void OnDestroyPooledObj(EnemyController pooledObj)
    {
        Destroy(pooledObj.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ActivateEnemy();
        }
    }

    // test spawn e despawn enemies
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        EnemyController enemyObj = _objPool.Get();
    //        enemyObj.transform.SetPositionAndRotation(new Vector3(Random.Range(0, 20), Random.Range(0, 20)), Quaternion.identity);

    //    }

    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        EnemyController enemyObj = FindFirstObjectByType<EnemyController>();
    //        enemyObj.Deactive();
    //    }
    //}

    //Disattiva tutti i gameobjects con la componente EnemyController che trova in scena
    public void DeactiveEnemy()
    {
        EnemyController[] enemyObj = GameObject.FindObjectsOfType<EnemyController>();

        foreach (EnemyController enemy in enemyObj)
        {
            enemy.Deactive();
        }
    }

    //Spawna tutti i Gameobjects che si trovano nella pool
    public void ActivateEnemy()
    {
        for (int i = 0; i <= _poolCapacity && i < spawnpoints.Length; i++)
        {
            EnemyController enemyObj = _objPool.Get();
            //settare la posizione random nelle dimensioni della mappa
            enemyObj.GetComponent<NavMeshAgent>().Warp(spawnpoints[i].position);
        }
    }
}