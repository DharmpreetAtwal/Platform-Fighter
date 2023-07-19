using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Element
{
    private float _aShockCooldownDur;
    public float AShockCooldownDur
    {
        get { return _aShockCooldownDur; }
        private set { _aShockCooldownDur = value; }
    }
    public float _aShockStaminaCost;
    public float AShockStaminaCost
    {
        get { return _aShockStaminaCost; }
        private set { _aShockStaminaCost = value; }
    }

    private void Start()
    {
        float spd = 2.0f;
        float atk = 1.0f;
        float def = 0.75f;
        float end = 1.5f;

        float coolADur = 0.25f;
        float coolBDur = 1.0f;
        float moveACost = 20;
        float moveBCost = 20;
        float moveAK = 10.0f;
        float moveBK = 100.0f;

        GameObject pref = GameManager.Instance.airBallPrefab;
        _aShockCooldownDur = 3.0f;
        _aShockStaminaCost = 50;

        base.Init(spd, atk, def, end, coolADur, coolBDur,
            moveACost, moveBCost, pref, moveAK, moveBK);
    }

    public override IEnumerator MoveMouseOne(Transform trans, int index)
    {
        trans.gameObject.GetComponent<Character>().IsMovementEnabled = false;
        yield return new WaitForSeconds(0.12f);
        trans.gameObject.GetComponent<Character>().IsMovementEnabled = true;
        MoveA(trans);
    }

    public override IEnumerator MoveMouseTwo(Transform trans, int index)
    {
        trans.gameObject.GetComponent<Character>().IsMovementEnabled = false;
        yield return new WaitForSeconds(0.12f);
        trans.gameObject.GetComponent<Character>().IsMovementEnabled = true;
        MoveB(trans);
    }

    public override void MoveShift(Transform trans, int index)
    {
        CooldownSDuration = _aShockCooldownDur;
        MoveSStaminaCost = _aShockStaminaCost;
        AirShockwave(trans);
    }

    private void AirShockwave(Transform trans)
    {
        Character shooter = trans.gameObject.GetComponent<Character>();
        shooter.Stamina -= _aShockStaminaCost;

        Instantiate(GameManager.Instance.airShockwave, trans.position,
            trans.rotation);

        Character chr = trans.gameObject.GetComponent<Character>();
        float x = chr.GetDirectionX();
        float y = chr.GetDirectionY();
        chr.ApplyForce(100 * x, 100 * y);
    }


}
