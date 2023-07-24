using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Enemy
{
    private void Awake()
    {
        Element elem = gameObject.GetComponent<Element>();
        float maxHealth = 100;
        float health = 10;
        float maxStam = 100;
        float stamina = 100;

        base.Init(elem, maxHealth, health, maxStam, stamina);
        InvokeRepeating(nameof(Shoot), 3.0f, 2.0f);
    }

    public override void Jump()
    {
        throw new System.NotImplementedException();
    }

}
