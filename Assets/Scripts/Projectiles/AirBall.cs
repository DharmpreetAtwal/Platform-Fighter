using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBall : Projectile
{
    public new void Awake()
    {
        base.Awake();
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        throw new System.NotImplementedException();
    }

    //public void Update()
    //{
    //    transform.position += new Vector3(speed * Time.deltaTime, 0);
    //}

}
