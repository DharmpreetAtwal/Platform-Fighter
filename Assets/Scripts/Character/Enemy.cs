using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    public new void Init(Element elem, float health, float stamina)
    {
        base.Init(elem, health, stamina);
    }

}
