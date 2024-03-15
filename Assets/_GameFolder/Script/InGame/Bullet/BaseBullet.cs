using System;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    protected float damage;
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected float length;
    [SerializeField] protected TrailRenderer trailRenderer;

    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    public float Length
    {
        get => length;
        set => length = value;
    }

    public void ActiveTrailRenderer(bool isActive)
    {
        trailRenderer.enabled = isActive;
    }

    public void SetVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }

    public virtual void OnEnable()
    {
        trailRenderer.Clear();
        ActiveTrailRenderer(true);
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<BaseEnemy>();
            enemy.GetDamage(damage);
        }

        if (!collision.gameObject.CompareTag("Bullet"))
        {
            trailRenderer.enabled = false;
            gameObject.SetActive(false);
        }
    }

    public void AddForce(Vector3 force, ForceMode forceMode = ForceMode.Impulse)
    {
        rb.AddForce(force, forceMode);
    }
}