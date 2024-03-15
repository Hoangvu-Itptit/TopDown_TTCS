using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Thomson : BaseBullet
{
    private Vector3 _oldPos;

    public override void OnEnable()
    {
        base.OnEnable();
        _oldPos = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _oldPos) > length)
        {
            trailRenderer.enabled = false;
            gameObject.SetActive(false);
        }
    }
}