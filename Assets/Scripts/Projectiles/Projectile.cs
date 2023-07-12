using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float damage
    {
        get { return this.damage; }
        protected set
        {
            if (value > -1) { damage = value; }
            else { this.damage = 0; }
        }
    }
    public float speed
    {
        get { return this.speed; }
        protected set
        {
            if (value < -1) { this.speed = 0; } else { speed = value; }
        }
    }
    public SpriteRenderer spriteRen { get; protected set; }

    public void Awake()
    {
        this.spriteRen = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public abstract void OnCollisionEnter2D(Collision2D collision);

}
