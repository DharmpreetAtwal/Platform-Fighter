using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBall : Projectile
{
    private void Awake()
    {
        float dmg = 2.0f;
        float spd = 10.0f;
        float timeDestroy = 3.0f;
        base.Init(dmg, spd, timeDestroy);
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
