using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBall : Projectile
{
    private void Awake()
    {
        float dmg = 2.0f;
        float spd = 10.0f;
        float timeDestroy = 3.0f;
        base.Init(dmg, spd, timeDestroy);
    }


}
