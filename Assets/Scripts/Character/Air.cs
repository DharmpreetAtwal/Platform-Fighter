using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Element
{
    public void Awake()
    {
        this.speed = 2.0f;
        this.attack = 1.0f;
        this.defence = 0.5f;
        this.endurance = 1.5f;
    }

    public override void MoveA()
    {
        throw new System.NotImplementedException();
    }

    public override void MoveB()
    {
        throw new System.NotImplementedException();
    }
}
