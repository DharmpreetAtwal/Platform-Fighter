using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Enemy
{
    private void Awake()
    {
        //Element elem = gameObject.AddComponent<Air>();
        Element elem = gameObject.GetComponent<Element>();

        float health = 10;
        float stamina = 100;

        base.Init(elem, health, stamina);
    }

    public override void Jump()
    {
        throw new System.NotImplementedException();
    }

}
