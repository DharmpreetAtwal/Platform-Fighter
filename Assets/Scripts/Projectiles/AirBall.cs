using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBall : Projectile
{
    private Character _owner { get; set; }
    public Character Owner;

    public new void Awake()
    {
        Speed = 10.0f;
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
