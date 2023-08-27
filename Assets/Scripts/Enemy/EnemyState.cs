using UnityEngine;

public enum EnemyStateType
{
    Idle,
    Patrol,
    Attack
}

public abstract class EnemyState : MonoBehaviour
{
    protected EnemyController enemyController;

    public void InitializeState(EnemyController controller)
    {
        enemyController = controller;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}