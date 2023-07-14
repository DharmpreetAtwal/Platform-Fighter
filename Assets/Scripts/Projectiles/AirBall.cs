﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBall : Projectile
{
    private void Awake()
    {
        float dmg = 2.0f;
        float spd = 10.0f;
        float timeDestroy = 3.0f;
        float knockb = 1.0f;
        base.Init(dmg, spd, timeDestroy, knockb);
    }

}
