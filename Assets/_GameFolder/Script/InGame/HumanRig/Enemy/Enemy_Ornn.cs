using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ornn : BaseEnemy
{
    public override void Move()
    {
        if (isInAttack || isDead) return;
        var player = GameController.Instance.player;
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
            isInAttack = true;
            Attack();
        }

        navMeshAgent.destination = player.transform.position;
        // transform.rotation = Quaternion.LookRotation();
    }

    public override void Attack()
    {
        StartCoroutine(ActiveAttack());
    }

    IEnumerator ActiveAttack()
    {
        isInAttack = true;
        animator.Play(CONST.ENEMY_ANIMATION_ATTACK);
        var timer = 2f + 2.0 / 3.0;
        hitBox.ActiveHitBox(false);
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            if (navMeshAgent.enabled == false || navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
            {
                hitBox.ActiveHitBox(false);
                isInAttack = false;
                yield break;
            }

            if (timer < 1.4f) hitBox.ActiveHitBox(true);
            if (timer < 1.16f) hitBox.ActiveHitBox(false);
            yield return null;
        }

        hitBox.ActiveHitBox(false);
        isInAttack = false;
    }

    public override void Animate()
    {
        if (isDead) return;
        if (isInAttack)
        {
            // Đã set Anim trong ActiveAttack()
            return;
        }

        animator.Play(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance
            ? CONST.ENEMY_ORNN_ANIMATION_IDLE
            : CONST.ENEMY_ORNN_ANIMATION_WALK);
    }

    public override void GetDamage(float damage)
    {
        if (curHp <= 0) return;
        curHp -= damage;
        var uiIns = UiController.Instance;
        uiIns.ActiveEnemyHeathBar(true);
        uiIns.UpdateUIEnemy(this);
        if (curHp <= 0)
        {
            StartCoroutine(Die());
        }
    }

    public override IEnumerator Die()
    {
        isDead = true;
        navMeshAgent.enabled = false;
        UiController.Instance.ActiveEnemyHeathBar(false);
        col.enabled = false;
        animator.Play(CONST.ENEMY_ANIMATION_DIE);
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Move();

        Animate();
    }
}