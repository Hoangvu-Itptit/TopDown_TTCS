using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseEnemy : BaseHumanRig
{
    [SerializeField] protected NavMeshAgent navMeshAgent;
    [SerializeField] protected EnemyAttackHitbox hitBox;
    protected float damage;
    protected bool isInAttack;

    public void Init(float speed, float hp, Sprite ava, float dmg)
    {
        base.Init(speed, hp, ava);
        damage = dmg;
    }

    public void Init(EnemyData enemy)
    {
        base.Init(enemy.moveSpeed, enemy.hp, enemy.avatar);
        damage = enemy.damage;
    }

    public override void Start()
    {
        base.Start();
        navMeshAgent.speed = moveSpeed;
        hitBox.SetDamage = damage;
    }

    private void OnEnable()
    {
        navMeshAgent.enabled = true;
        isInAttack = false;
        isDead = false;
        col.enabled = true;
        curHp = maxHp;
    }
}