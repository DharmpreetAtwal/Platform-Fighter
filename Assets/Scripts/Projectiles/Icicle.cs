using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : Projectile
{
    // Start is called before the first frame update
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
        if (enemy != null)
        {
            if (enemy.Element.GetType() == typeof(Fire) ||
                enemy.Element.GetType() == typeof(Earth))
            { Damage *= 2.0f; }

            enemy.TakeDamage(Damage);
            enemy.ApplyForce(Velocity.x * Knockback, Velocity.y * Knockback);
            Destroy(gameObject);
        }
    }

}
