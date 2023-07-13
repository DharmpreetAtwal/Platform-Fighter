using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBall : Projectile
{
    private Character _owner;
    public Character Owner
    {
        get { return _owner; }
        set { _owner = value; }
    }

    public new void Awake()
    {
        Damage = 2.0f;
        Speed = 10.0f;
        TimeDestroy = 3.0f;
        base.Awake();
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        transform.position += new Vector3(Speed * Time.deltaTime, 0);
    }

}
