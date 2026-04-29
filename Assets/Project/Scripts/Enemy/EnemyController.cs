using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public abstract class EnemyController : MonoBehaviour
{
    [SerializeField] protected SO_Enemies _enemyInfo;

    protected EnemyState.State _currentState;
    protected NavMeshAgent _agent;
    protected Transform _player;
    protected LifeController _lifeController;

    private IObjectPool<EnemyController> _objPool;

    public void SetObjPool(IObjectPool<EnemyController> pool)
    {
        _objPool = pool;
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _lifeController = GetComponent<LifeController>();
    }

    protected virtual void Start()
    {
        _agent.speed = _enemyInfo._speed;
    }
    protected bool CanSeePlayer()
    {
        return Vector3.Distance(transform.position, _player.position) < _enemyInfo._triggerDistance;
    }

    protected void CheckPlayer()
    {
        if (CanSeePlayer())
        {
            _currentState = EnemyState.State.Attack;
        }
    }

    protected virtual void Update()
    {
        CheckPlayer();

        switch (_currentState)
        {
            case EnemyState.State.Patrol:
                Patrol();
                break;

            case EnemyState.State.Attack:
                Attack();
                break;
        }
    }

    public void Deactive()
    {
        _objPool.Release(this);
    }

    protected abstract void Patrol();
    protected abstract void Attack();
}
