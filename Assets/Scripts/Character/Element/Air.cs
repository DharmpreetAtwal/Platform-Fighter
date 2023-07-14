using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Element
{
    private void Start()
    {
        float spd = 2.0f;
        float atk = 1.0f;
        float def = 0.75f;
        float end = 1.5f;

        float coolADur = 1.0f;
        float coolBDur = 1.0f;
        float moveACost = 20;
        float moveBCost = 20;
        float moveAK = 1.0f;
        float moveBK = 10.0f;

        GameObject pref = GameManager.Instance.airBallPrefab;

        base.Init(spd, atk, def, end, coolADur, coolBDur,
            moveACost, moveBCost, pref, moveAK, moveBK);
    }
}
