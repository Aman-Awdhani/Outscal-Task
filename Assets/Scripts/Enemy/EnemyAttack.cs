using UnityEngine;
using TMPro;

public class EnemyAttack : EnemyState
{
    public float attackCooldown = 2f;
    public float attackCooldownCounter;

    private bool _canAttack = true;

    [SerializeField] private TextMeshPro _coolDownText;

    public override void EnterState()
    {
        Debug.Log("Attack State Entered");
    }

    public override void UpdateState()
    {
        if (_canAttack)
        {
            _canAttack = false;
            Attack();

            attackCooldownCounter = attackCooldown;
            _coolDownText.text = attackCooldownCounter.ToString();
            InvokeRepeating(nameof(CooldownTextUpdate), 1 , attackCooldown);

            Invoke(nameof(ResetAttackCooldown), attackCooldown + 1);
        }

        if (enemyController.player == null)
        {
            enemyController.ChangeState(EnemyStateType.Patrol);
            return;
        }

        if (Vector3.Distance(transform.position, enemyController.player.transform.position) > enemyController.enemyData.attackRange )
        {
            enemyController.ChangeState(EnemyStateType.Patrol);
        }
    }

    public override void ExitState()
    {
        _coolDownText.text = "";
    }

    private void ResetAttackCooldown()
    {
        Debug.Log("Attack Cooldown 2 sec");
        _canAttack = true;
    }

    private void CooldownTextUpdate()
    {
        attackCooldownCounter--;
        _coolDownText.text = (attackCooldownCounter).ToString();
    }

    private void Attack()
    {
        CancelInvoke();
        enemyController.player.playerHealth.TakeDamage(enemyController.enemyData.attackDamage);
    }
}