using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : Projectile
{
    // Start is called before the first frame update
    private void Awake()
    {
        float dmg = 2.0f;
        float spd = 10.0f;
        float timeDestroy = 6.0f;
        float knockb = 1.0f;
        base.Init(dmg, spd, timeDestroy, knockb);
    }

}