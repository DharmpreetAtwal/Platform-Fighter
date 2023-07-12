using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBall : Projectile
{
    public new void Awake()
    {
        this.Speed = 1.0f;
        base.Awake();
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        transform.position += new Vector3(this.Speed * Time.deltaTime, 0);
    }

}
