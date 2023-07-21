using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : Projectile
{
    private void Awake()
    {
        float dmg = 2.0f;
        float spd = 10.0f;
        float timeDestroy = 6.0f;
        float knockb = 1.0f;
        base.Init(dmg, spd, timeDestroy, knockb);
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Character enemy = collision.collider.gameObject.GetComponent<Character>();
        Projectile proj = collision.collider.gameObject.GetComponent<Projectile>();
        if (enemy != null && enemy != Owner)
        {
            if (enemy.Element.GetType() == typeof(Fire)) { Damage *= 2.0f; }
            enemy.TakeDamage(Damage);
            enemy.ApplyForce(Velocity.x * Knockback, Velocity.y * Knockback);
            Destroy(gameObject);
        } else if(proj != null)
        {
            if (proj.GetType() != typeof(FireBall) ||
                proj.GetType() == typeof(AirBall))
            { Destroy(gameObject); }
        }
    }
}