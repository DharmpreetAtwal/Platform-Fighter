using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Projectile
{
    // Start is called before the first frame update
    private void Awake()
    {
        float dmg = 80;
        float spd = 100;
        float timeDestroy = 5;
        float knockb = 10;
        base.Init(dmg, spd, timeDestroy, knockb);
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Character enemy = collision.collider.gameObject.GetComponent<Character>();
        if (enemy != null && enemy != Owner)
        {
            enemy.TakeDamage(Damage);
            enemy.ApplyForce(Velocity.x * Knockback, Velocity.y * Knockback);
        }
    }
}
