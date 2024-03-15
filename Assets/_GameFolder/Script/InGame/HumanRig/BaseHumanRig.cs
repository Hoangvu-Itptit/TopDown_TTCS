using System;
using System.Collections;
using UnityEngine;

public abstract class BaseHumanRig : MonoBehaviour, IGetDamage
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Collider col;
    protected float moveSpeed;
    protected float maxHp;
    protected Sprite avatar;
    protected float curHp;
    protected bool isDead;

    public Sprite GetAvatar => avatar;

    public float GetCurHpPercent => curHp / maxHp;

    protected void Init(float speed, float hp, Sprite ava)
    {
        moveSpeed = speed;
        maxHp = hp;
        avatar = ava;
    }

    public virtual void Start()
    {
        curHp = maxHp;
    }

    public abstract void Move();

    public abstract void Attack();

    public abstract void Animate();

    public abstract void GetDamage(float damage);

    public abstract IEnumerator Die();

    public virtual void Heal(float heal)
    {
        curHp += heal;
        if (curHp > maxHp)
        {
            curHp = maxHp;
        }
    }
}