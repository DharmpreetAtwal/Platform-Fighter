using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Element
{
    // Awake is called before the first frame update
    void Start()
    {
        float spd = 1.0f;
        float atk = 2.0f;
        float def = 1.5f;
        float end = 0.75f;

        float coolADur = 0.0f;
        float coolBDur = 1.0f;
        float moveACost = 20;
        float moveBCost = 20;
        float moveAK = 1.0f;
        float moveBK = 10.0f;

        GameObject pref = GameManager.Instance.fireBallPrefab;

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
        throw new System.NotImplementedException();
    }
}
