using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    public new void Init(Element elem, float maxHealth, float health,
        float maxStam, float stamina)
    {
        base.Init(elem, maxHealth, health, maxStam, stamina);
    }

    public void Shoot()
    {
        IsLookingRight = true;
        NoneXInput = false;
        NoneYInput = true;
        StartCoroutine(Element.MoveMouseOne(transform, 0));
    }

    public void Update()
    {
        CheckBounds();
    }

}
