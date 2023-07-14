using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Element
{
    void Start()
    {
        float spd = 2.0f;
        float atk = 5.0f;
        float def = 5.0f;
        float end = 10.0f;

        float coolADur = 0.0f;
        float coolBDur = 1.0f;
        float moveACost = 20;
        float moveBCost = 20;

        GameObject pref = GameManager.Instance.waterBallPrefab;

        base.Init(spd, atk, def, end, coolADur, coolBDur,
            moveACost, moveBCost, pref);
    }

    public override void MoveB(Transform trans)
    {
        throw new System.NotImplementedException();
    }

}
