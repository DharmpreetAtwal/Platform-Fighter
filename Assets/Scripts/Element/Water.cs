using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Element
{
    private float _iceFuryCooldownDur;
    public float IceFuryCooldownDur
    {
        get { return _iceFuryCooldownDur; }
        private set { _iceFuryCooldownDur = value; }
    }
    private float _iceFuryStaminaCost;
    public float IceFuryStaminaCost {
        get { return _iceFuryStaminaCost; }
        private set { _iceFuryStaminaCost = value; }
    }
    private float _iceFuryFireRate;
    public float IceFuryFireRate {
        get { return _iceFuryFireRate; }
        private set { _iceFuryFireRate = value; }
    }

    void Start()
    {
        float spd = 1.0f;
        float atk = 0.75f;
        float def = 1.5f;
        float end = 2.0f;

        float coolADur = 0.25f;
        float coolBDur = 1.0f;
        float moveACost = 20;
        float moveBCost = 20;
        float moveAK = 10.0f;
        float moveBK = 100.0f;

        GameObject pref = GameManager.Instance.waterBallPrefab;
        _iceFuryCooldownDur = 4.0f;
        _iceFuryStaminaCost = 10;
        _iceFuryFireRate = 0.3f;

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
        CooldownSDuration = _iceFuryCooldownDur;
        MoveSStaminaCost = _iceFuryStaminaCost;
        StartCoroutine(IcicleFury(trans));
    }

    private IEnumerator IcicleFury(Transform trans)
    {
        for(int i=0; i < 4; i++)
        {
            Character shooter = trans.gameObject.GetComponent<Character>();
            float x = 2 * shooter.GetDirectionX();
            float y = 2 * shooter.GetDirectionY();

            if(shooter.Stamina >= _iceFuryStaminaCost && (x!=0 || y !=0))
            {
                shooter.Stamina -= _iceFuryStaminaCost;
                Projectile.ShootProjectile(shooter,
                    GameManager.Instance.waterIcicle, x, y);

                yield return new WaitForSeconds(_iceFuryFireRate);
            }
        }
    }

}
