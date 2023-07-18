using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Element
{
    private float _lightningCooldownDur;
    public float LightningCooldownDur
    {
        get { return _lightningCooldownDur; }
        private set { _lightningCooldownDur = value; }
    }
    private float _lightningStaminaCost;
    public float LightningStaminaCost
    {
        get { return _lightningStaminaCost; }
        private set { _lightningStaminaCost = value; }
    }
    private float _lightningChargeDur;
    public float LightningChargeDur
    {
        get { return _lightningChargeDur; }
        private set { _lightningChargeDur = value; }
    }

    // Awake is called before the first frame update
    void Start()
    {
        float spd = 1.0f;
        float atk = 2.0f;
        float def = 1.5f;
        float end = 0.75f;

        float coolADur = 0.25f;
        float coolBDur = 1.0f;
        float moveACost = 20;
        float moveBCost = 20;
        float moveAK = 10.0f;
        float moveBK = 100.0f;

        GameObject pref = GameManager.Instance.fireBallPrefab;
        _lightningCooldownDur = 1;
        _lightningStaminaCost = 1;
        _lightningChargeDur = 3;

        base.Init(spd, atk, def, end, coolADur, coolBDur,
            moveACost, moveBCost, pref, moveAK, moveBK);
    }

    public override IEnumerator MoveMouseOne(Transform trans, int index)
    {
        yield return new WaitForSeconds(0.12f);
        MoveA(trans);
    }

    public override IEnumerator MoveMouseTwo(Transform trans, int index)
    {
        yield return new WaitForSeconds(0.12f);
        MoveB(trans);
    }

    public override void MoveShift(Transform trans, int index)
    {
        CooldownSDuration = _lightningCooldownDur;
        MoveSStaminaCost = _lightningStaminaCost;
        StartCoroutine(Lightning(trans));
    }

    private IEnumerator Lightning(Transform trans)
    {
        Character shooter = trans.gameObject.GetComponent<Character>();
        shooter.IsMovementEnabled = false;

        yield return new WaitForSeconds(_lightningChargeDur);

        float x = 2 * shooter.GetDirectionX();
        float y = 2 * shooter.GetDirectionY();

        if(shooter.Stamina >= _lightningStaminaCost && (x!=0 || y!=0))
        {
            shooter.Stamina -= _lightningStaminaCost;
            Projectile.ShootProjectile(shooter, GameManager.Instance.lightning, x, y);
        }

        shooter.IsMovementEnabled = true;
    }
}
