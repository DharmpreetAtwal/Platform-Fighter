using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Element
{
    public GameObject airBall;

    public void Awake()
    {
        this.speed = 2.0f;
        this.attack = 1.0f;
        this.defence = 0.5f;
        this.endurance = 1.5f;
    }

    public override void MoveA(float x, float y)
    {
        throw new System.NotImplementedException();
    }

    public override void MoveB(float x, float y)
    {
        throw new System.NotImplementedException();
    }
}
