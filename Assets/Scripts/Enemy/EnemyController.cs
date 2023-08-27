using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyState _currentState;

    [SerializeField] internal EnemyData enemyData;
    [SerializeField] private EnemyState _enemyIdleState;
    [SerializeField] private EnemyState _enemyPatrolState;
    [SerializeField] private EnemyState _enemyAttackState;

    internal PlayerManager player;

    private void Start()
    {
        player = FindObjectOfType<PlayerManager>();

        TransitionToState(EnemyStateType.Patrol);
    }

    private void Update()
    {
        if(_currentState)
            _currentState.UpdateState();
    }

    public void ChangeState(EnemyStateType newState)
    {
        _currentState.ExitState();
        TransitionToState(newState);
        _currentState.EnterState();
    }

    private void TransitionToState(EnemyStateType newState)
    {
        switch (newState)
        {
            case EnemyStateType.Idle:
                _currentState = _enemyIdleState;
                break;
            case EnemyStateType.Patrol:
                _currentState = _enemyPatrolState;
                break;

            case EnemyStateType.Attack:
                _currentState = _enemyAttackState;
                break;
        }

        _currentState.InitializeState(this);
    }
}