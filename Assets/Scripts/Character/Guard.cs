using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Enemy
{

    // Start is called before the first frame update
    public new void Awake()
    {
        element = gameObject.AddComponent<Air>();
        Health = 10;
        base.Awake();
    }

    public override void Jump()
    {
        throw new System.NotImplementedException();
    }

}
