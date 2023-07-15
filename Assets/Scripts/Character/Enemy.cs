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
        noneXInput = false;
        noneYInput = true;
        Element.MoveA(transform);
    }
}
