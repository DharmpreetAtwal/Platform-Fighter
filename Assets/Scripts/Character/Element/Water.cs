using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Element
{
    void Start()
    {
        float spd = 1.0f;
        float atk = 0.75f;
        float def = 1.5f;
        float end = 2.0f;

        float coolADur = 0.0f;
        float coolBDur = 1.0f;
        float moveACost = 20;
        float moveBCost = 20;
        float moveAK = 1.0f;
        float moveBK = 10.0f;

        GameObject pref = GameManager.Instance.waterBallPrefab;

        base.Init(spd, atk, def, end, coolADur, coolBDur,
            moveACost, moveBCost, pref, moveAK, moveBK);
    }

}
