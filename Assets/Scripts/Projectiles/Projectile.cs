using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private float _damage;
    public float Damage
    {
        get { return this._damage; }
        protected set
        {
            if (value > -1) { _damage = value; }
            else { this._damage = 0; }
        }
    }
    private float _speed;
    public float Speed { get; set; }

    public SpriteRenderer spriteRen { get; protected set; }

    public void Awake()
    {
        this.spriteRen = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public abstract void OnCollisionEnter2D(Collision2D collision);

}
