using System;
using System.Collections;
using UnityEngine;

public class PlayerController : BaseHumanRig
{
    [SerializeField] protected Transform posGunParent;
    private BaseGun _gunMain;

    public void Init(PlayerData playerData)
    {
        moveSpeed = playerData.moveSpeed;
        maxHp = playerData.hp;
        avatar = playerData.avatar;
        var gunData = GameController.Instance.gunData.listGunData[PrefData.gun_type];
        _gunMain = Instantiate(gunData.model, posGunParent).GetComponent<BaseGun>();
    }

    public override void Start()
    {
        base.Start();
        UiController.Instance.playerHealthBar.UpdateUI(this);
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Attack();
    }

    public override void Move()
    {
        var uiIns = UiController.Instance;
        var moveDir = uiIns.moveDirJst.Direction;
        Animate();
        rb.velocity = new Vector3(moveDir.x, 0, moveDir.y) * moveSpeed + new Vector3(0, rb.velocity.y, 0);
    }

    public override void Attack()
    {
        var uiIns = UiController.Instance;
        var shootDir = uiIns.shootDirJst.Direction;
        if (shootDir == Vector2.zero) return;
        transform.rotation = Quaternion.LookRotation(new Vector3(shootDir.x, 0, shootDir.y));
        _gunMain.GunShoot(shootDir);
    }

    public override void Animate()
    {
        if (isDead) return;
        var uiIns = UiController.Instance;
        var moveDir = uiIns.moveDirJst.Direction.normalized;
        var rot = (transform.rotation.eulerAngles.y + 90) * Math.PI / 180.0f;
        var shootDirRot = new Vector2((float)-Math.Cos(rot), (float)Math.Sin(rot)).normalized;

        if (moveDir == Vector2.zero)
        {
            animator.Play(CONST.HUMAN_ANIMATION_IDLE);
        }
        else
        {
            var angle = Vector2.Angle(moveDir, shootDirRot);
            switch (angle)
            {
                case < 45f:
                    animator.Play(CONST.HUMAN_ANIMATION_RUN_FORWARD);
                    break;
                case > 135f:
                    animator.Play(CONST.HUMAN_ANIMATION_RUN_BACKWARD);
                    break;
                default:
                {
                    animator.Play(moveDir.x < shootDirRot.x
                        ? CONST.HUMAN_ANIMATION_RUN_LEFT
                        : CONST.HUMAN_ANIMATION_RUN_RIGHT);
                    break;
                }
            }
        }
    }

    public override void GetDamage(float damage)
    {
        if (curHp <= 0) return;
        curHp -= damage;
        UiController.Instance.UpdatePlayerHealthBar(curHp / maxHp);
        if (curHp <= 0)
        {
            curHp = 0;
            StartCoroutine(Die());
        }
    }

    public override IEnumerator Die()
    {
        isDead = true;
        animator.Play(CONST.HUMAN_ANIMATION_DIE);
        yield return new WaitForSeconds(2f);
    }

    public void ReloadBullet(Action<float> timeRecovery)
    {
        StartCoroutine(_gunMain.Reload());
        timeRecovery?.Invoke(_gunMain.GetGunData.bulletReloadTime);
    }

    public override void Heal(float heal)
    {
        base.Heal(heal);
        UiController.Instance.UpdatePlayerHealthBar(curHp / maxHp);
    }
}