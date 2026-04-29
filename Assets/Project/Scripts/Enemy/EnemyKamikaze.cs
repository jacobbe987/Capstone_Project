using UnityEngine;

public class EnemyKamikaze : EnemyController
{
    [SerializeField] protected Transform[] _patrolPoints;

    protected int _arrIndex;

    protected override void Start()
    {
        base.Start();
        _currentState = EnemyState.State.Patrol;

        if (!_agent.isOnNavMesh)
        _agent.SetDestination(_patrolPoints[_arrIndex].position);
    }
    protected override void Attack()
    {
        _agent.speed = _enemyInfo._attackSpeed;
        _agent.SetDestination(_player.position);
    }

    protected override void Patrol()
    {
        if(!_agent.pathPending && _agent.remainingDistance < 1)
        {
            _arrIndex = (_arrIndex +1)%_patrolPoints.Length;
            _agent.SetDestination(_patrolPoints[_arrIndex].position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<LifeController>(out var life))
        {
            life.RemoveHp(_enemyInfo._damage);
            Deactive();
        }
    }
}
