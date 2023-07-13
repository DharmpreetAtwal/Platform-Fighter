using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBall : Projectile
{

    public new void Awake()
    {
        Damage = 2.0f;
        Speed = 10.0f;
        TimeDestroy = 3.0f;
        base.Awake();
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(Damage);
        }
    }

    public void Update()
    {
        transform.position += new Vector3(Speed * Time.deltaTime, 0);
    }

}
