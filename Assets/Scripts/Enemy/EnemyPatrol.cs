using UnityEngine;

public class EnemyPatrol : EnemyState
{
    public Transform[] patrolPoints;
    public float patrolSpeed = 2f;
    private int _currentPatrolPointIndex = 0;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public override void EnterState()
    {
        Debug.Log("Patrol State Entered");
        SetNextPatrolPoint();
    }

    public override void UpdateState()
    {
        Vector3 direction = (patrolPoints[_currentPatrolPointIndex].position - _transform.position).normalized;
        _transform.Translate(direction * patrolSpeed * Time.deltaTime);

        float distanceToTarget = Vector3.Distance(_transform.position, patrolPoints[_currentPatrolPointIndex].position);
        if (distanceToTarget < 0.1f)
        {
            SetNextPatrolPoint();
        }


        if (enemyController.player == null)
            return;

        if (Vector3.Distance(transform.position, enemyController.player.transform.position) <= enemyController.enemyData.attackRange)
        {
            enemyController.ChangeState(EnemyStateType.Attack);
        }
    }

    public override void ExitState()
    {
    }

    private void SetNextPatrolPoint()
    {
        _currentPatrolPointIndex = (_currentPatrolPointIndex + 1) % patrolPoints.Length;
    }
}
