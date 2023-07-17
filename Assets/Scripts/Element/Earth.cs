using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : Element
{
    public float _flingCooldownDur;
    public float FlingCooldownDur
    {
        get { return _flingCooldownDur; }
        private set { _flingCooldownDur = value; }
    }
    public float _flingStaminaCost;
    public float FlingStaminaCost
    {
        get { return _flingStaminaCost; }
        private set { _flingStaminaCost = value; }
    }

    // Awake is called before the first frame update
    void Start()
    {
        float spd = 0.75f;
        float atk = 1.0f;
        float def = 2.0f;
        float end = 1.5f;

        float coolADur = 0.0f;
        float coolBDur = 1.0f;
        float moveACost = 20;
        float moveBCost = 20;
        float moveAK = 1.0f;
        float moveBK = 10.0f;

        GameObject pref = GameManager.Instance.earthBallPrefab;
        _flingCooldownDur = 4;
        _flingStaminaCost = 30;

        base.Init(spd, atk, def, end, coolADur, coolBDur,
            moveACost, moveBCost, pref, moveAK, moveBK);
    }

    public override void MoveMouseOne(Transform trans, int index)
    {
        MoveA(trans);
    }

    public override void MoveMouseTwo(Transform trans, int index)
    {
        MoveB(trans);
    }

    public override void MoveShift(Transform trans, int index)
    {
        CooldownSDuration = _flingCooldownDur;
        MoveSStaminaCost = _flingStaminaCost;
        Fling(trans);
    }

    private void Fling(Transform trans)
    {
        // If raising platform up, scale +1 = y + (1/2) 
        // If raising pltform sideways, sclae + 1 = y + cos(angle) / 2
    }
}
