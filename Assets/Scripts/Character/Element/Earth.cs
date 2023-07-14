using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : Element
{
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

        base.Init(spd, atk, def, end, coolADur, coolBDur,
            moveACost, moveBCost, pref, moveAK, moveBK);
    }

}
