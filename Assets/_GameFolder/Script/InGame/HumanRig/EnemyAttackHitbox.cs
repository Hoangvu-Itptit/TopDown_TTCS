using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHitbox : MonoBehaviour
{
    private float _damage;

    public float SetDamage
    {
        set => _damage = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<IGetDamage>();
            player.GetDamage(_damage);
        }
    }

    public void ActiveHitBox(bool active)
    {
        gameObject.SetActive(active);
    }
}